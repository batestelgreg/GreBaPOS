$ErrorActionPreference = "Stop"

# Ensure System.Data assembly is loaded for SQL connection classes
Add-Type -AssemblyName System.Data

# GREBAPOS DATABASE INSTALLATION

$server = ".\SQLEXPRESS"
$database = "Batestel"

$schemaFile = Join-Path $PSScriptRoot "Database\Batestel_Schema.sql"
$seedFile = Join-Path $PSScriptRoot "Database\Batestel_Seed.sql"
$logFile = Join-Path $env:TEMP "GreBaPOS_DatabaseSetup.log"

# LOGGING

function Write-Log {
    param([string]$Message)

    $entry = "$(Get-Date -Format 'yyyy-MM-dd HH:mm:ss') - $Message"

    Add-Content -LiteralPath $logFile -Value $entry -Encoding UTF8
    Write-Host $entry
}

# SQL CONNECTION

function New-SqlConnection {
    param([string]$DatabaseName)

    $builder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder

    $builder["Data Source"] = $server
    $builder["Initial Catalog"] = $DatabaseName
    $builder["Integrated Security"] = $true
    $builder["Encrypt"] = $true
    $builder["TrustServerCertificate"] = $true
    $builder["Connect Timeout"] = 30

    return [System.Data.SqlClient.SqlConnection]::new(
        $builder.ConnectionString
    )
}

# WAIT FOR SQL SERVER EXPRESS

function Wait-ForSqlServer {

    $serviceName = 'MSSQL$SQLEXPRESS'

    Write-Log "Checking SQL Server Express..."

    $service = Get-Service -Name $serviceName -ErrorAction Stop

    if ($service.Status -ne "Running") {
        Start-Service -Name $serviceName -ErrorAction Stop
    }

    for ($i = 0; $i -lt 60; $i++) {

        $service = Get-Service -Name $serviceName

        if ($service.Status -eq "Running") {
            break
        }

        Start-Sleep -Seconds 5
    }

    $service = Get-Service -Name $serviceName

    if ($service.Status -ne "Running") {
        throw "SQL Server Express failed to start."
    }

    $connection = New-SqlConnection -DatabaseName "master"

    try {
        $connection.Open()
        Write-Log "SQL Server connection successful."
    }
    finally {
        $connection.Dispose()
    }
}

# DATABASE EXISTENCE CHECK

function Test-DatabaseExists {

    $connection = New-SqlConnection -DatabaseName "master"

    try {
        $connection.Open()

        $command = $connection.CreateCommand()

        $command.CommandText = @"
SELECT COUNT(*)
FROM sys.databases
WHERE name = @DatabaseName;
"@

        [void]$command.Parameters.AddWithValue(
            "@DatabaseName",
            $database
        )

        $exists = [int]$command.ExecuteScalar() -gt 0

        $command.Dispose()

        return $exists
    }
    finally {
        $connection.Dispose()
    }
}

# SQL SCRIPT EXECUTION

function Invoke-SqlScript {

    param(
        [string]$FilePath,
        [string]$DatabaseName
    )

    if (-not (Test-Path -LiteralPath $FilePath -PathType Leaf)) {
        throw "SQL script not found: $FilePath"
    }

    Write-Log "Executing: $FilePath"

    $scriptText = Get-Content -LiteralPath $FilePath -Raw

    if ([string]::IsNullOrWhiteSpace($scriptText)) {
        throw "SQL script is empty: $FilePath"
    }

    $batches = [regex]::Split(
        $scriptText,
        '(?im)^\s*GO\s*(?:--.*)?$'
    )

    $connection = New-SqlConnection -DatabaseName $DatabaseName

    try {
        $connection.Open()

        $batchNumber = 0

        foreach ($batch in $batches) {

            if ([string]::IsNullOrWhiteSpace($batch)) {
                continue
            }

            $batchNumber++

            $command = $connection.CreateCommand()
            $command.CommandTimeout = 180
            $command.CommandText = $batch

            try {
                [void]$command.ExecuteNonQuery()
            }
            catch {
                throw "SQL batch $batchNumber failed in $FilePath. $($_.Exception.Message)"
            }
            finally {
                $command.Dispose()
            }
        }

        Write-Log "SQL script completed successfully."
    }
    finally {
        $connection.Dispose()
    }
}

# DATABASE VERIFICATION

function Verify-DatabaseSetup {

    $connection = New-SqlConnection -DatabaseName $database

    try {
        $connection.Open()

        $command = $connection.CreateCommand()

        $command.CommandText = @"
SELECT
    (SELECT COUNT(*) FROM sys.tables WHERE is_ms_shipped = 0) AS TableCount,
    (SELECT COUNT(*) FROM sys.procedures WHERE is_ms_shipped = 0) AS ProcedureCount,
    (SELECT COUNT(*) FROM dbo.Roles) AS RoleCount,
    (SELECT COUNT(*) FROM dbo.Permissions) AS PermissionCount,
    (SELECT COUNT(*) FROM dbo.Categories) AS CategoryCount;
"@

        $reader = $command.ExecuteReader()

        try {
            if (-not $reader.Read()) {
                throw "Database verification failed."
            }

            $tableCount = [int]$reader["TableCount"]
            $procedureCount = [int]$reader["ProcedureCount"]
            $roleCount = [int]$reader["RoleCount"]
            $permissionCount = [int]$reader["PermissionCount"]
            $categoryCount = [int]$reader["CategoryCount"]
        }
        finally {
            $reader.Dispose()
        }

        $command.Dispose()

        if ($tableCount -lt 11) {
            throw "Expected at least 11 tables. Found $tableCount."
        }

        if ($procedureCount -lt 27) {
            throw "Expected at least 27 stored procedures. Found $procedureCount."
        }

        if ($roleCount -lt 3) {
            throw "Required roles are missing."
        }

        if ($permissionCount -lt 7) {
            throw "Required permissions are missing."
        }

        if ($categoryCount -lt 5) {
            throw "Required categories are missing."
        }

        $accountCommand = $connection.CreateCommand()

        $accountCommand.CommandText = @"
SELECT COUNT(*)
FROM (VALUES
    (N'admin', N'Admin'),
    (N'cashier', N'Cashier'),
    (N'manager', N'Manager')
) AS Expected(Username, RoleName)
INNER JOIN dbo.Users u
    ON u.Username = Expected.Username
INNER JOIN dbo.Roles r
    ON r.RoleId = u.RoleId
WHERE r.RoleName = Expected.RoleName
AND u.IsActive = 1;
"@

        $accountCount = [int]$accountCommand.ExecuteScalar()

        $accountCommand.Dispose()

        if ($accountCount -ne 3) {
            throw "Default account verification failed. Expected 3 active accounts, found $accountCount."
        }

        Write-Log "Database verification successful."
        Write-Log "Tables: $tableCount"
        Write-Log "Stored procedures: $procedureCount"
        Write-Log "Roles: $roleCount"
        Write-Log "Permissions: $permissionCount"
        Write-Log "Categories: $categoryCount"
        Write-Log "Default accounts: $accountCount"
    }
    finally {
        $connection.Dispose()
    }
}

# MAIN INSTALLATION

try {

    Set-Content -LiteralPath $logFile -Value "" -Encoding UTF8

    Write-Log "========================================"
    Write-Log "Starting GreBaPOS database installation."
    Write-Log "========================================"

    if (-not (Test-Path -LiteralPath $schemaFile -PathType Leaf)) {
        throw "Schema file is missing: $schemaFile"
    }

    if (-not (Test-Path -LiteralPath $seedFile -PathType Leaf)) {
        throw "Seed file is missing: $seedFile"
    }

    Write-Log "Required SQL scripts found."

    Wait-ForSqlServer

    if (Test-DatabaseExists) {
        Write-Log "Database '$database' already exists."
        Write-Log "Existing database will be preserved. No schema or seed scripts will be executed."

        Verify-DatabaseSetup

        Write-Log "Existing database passed verification."
    }
    else {
        Write-Log "Database '$database' does not exist."
        Write-Log "Creating new database."

        Invoke-SqlScript -FilePath $schemaFile -DatabaseName "master"

        if (-not (Test-DatabaseExists)) {
            throw "Database creation failed."
        }

        Write-Log "Database created successfully."

        Invoke-SqlScript -FilePath $seedFile -DatabaseName $database

        Write-Log "Initial database records inserted."

        Verify-DatabaseSetup

        Write-Log "New database passed verification."
    }

    exit 0
}
catch {

    $errorMessage = $_.Exception.Message

    try {
        Write-Log "DATABASE INSTALLATION FAILED"
        Write-Log $errorMessage
    }
    catch {
        Write-Host "Unable to write installation log."
    }

    Write-Host $errorMessage

    exit 1
}