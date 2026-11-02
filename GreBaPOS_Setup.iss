#define MyAppName "GreBaPOS"
#define MyAppVersion "1.5"
#define MyAppPublisher "Greg Anderson Batestel"
#define MyAppExeName "EnterprisePOS.WinForms.exe"

[Setup]
AppId={{D7D4774A-2381-4834-8C61-2618487786B2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
PrivilegesRequired=admin
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
OutputBaseFilename=GreBaPOS_Setup
SolidCompression=yes
WizardStyle=modern dark

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Main application and database files
Source: "*"; Excludes: "GreBaPOS_Setup.iss,Output\*,*.pdb,SQLEXPR_x64_ENU.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; Embed SQL Server Express installer
Source: "SQLEXPR_x64_ENU.exe"; Flags: dontcopy

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; Database setup is fully handled in CurStepChanged via RunDatabaseSetup() to avoid duplicate execution.

[Code]

const
  SQLServiceName = 'MSSQL$SQLEXPRESS';

var
  DatabaseSetupSucceeded: Boolean;

// CHECK SQL SERVER EXPRESS INSTANCE

function IsSqlServerInstalled(): Boolean;
var
  ResultCode: Integer;
  ScPath: string;
begin
  ScPath := ExpandConstant('{sys}\sc.exe');

  Result := Exec(
    ScPath,
    'query "' + SQLServiceName + '"',
    '',
    SW_HIDE,
    ewWaitUntilTerminated,
    ResultCode
  ) and (ResultCode = 0);
end;

// INSTALL SQL SERVER EXPRESS

function InstallSQLServer(): Boolean;
var
  ResultCode: Integer;
  SQLSetupPath: string;
  Parameters: string;
begin
  Result := False;

  try
    ExtractTemporaryFile('SQLEXPR_x64_ENU.exe');
  except
    MsgBox(
      'Unable to extract the embedded SQL Server Express installer.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  SQLSetupPath := ExpandConstant('{tmp}\SQLEXPR_x64_ENU.exe');

  if not FileExists(SQLSetupPath) then
  begin
    MsgBox(
      'SQL Server Express installer was not extracted successfully.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  Parameters :=
    '/Q ' +
    '/ACTION=Install ' +
    '/FEATURES=SQLENGINE ' +
    '/INSTANCENAME=SQLEXPRESS ' +
    '/SQLSVCSTARTUPTYPE=Automatic ' +
    '/SQLSYSADMINACCOUNTS="BUILTIN\Administrators" ' +
    '/SUPPRESSPRIVACYSTATEMENTNOTICE ' +
    '/IACCEPTSQLSERVERLICENSETERMS';

  if not Exec(
    SQLSetupPath,
    Parameters,
    ExpandConstant('{tmp}'),
    SW_SHOW,
    ewWaitUntilTerminated,
    ResultCode
  ) then
  begin
    MsgBox(
      'Unable to start SQL Server Express installation.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  if (ResultCode = 3010) or (ResultCode = 1641) then
  begin
    MsgBox(
      'SQL Server Express requires a Windows restart. Restart your computer and run GreBaPOS Setup again.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  if ResultCode <> 0 then
  begin
    MsgBox(
      'GreBaPOS database setup failed.' + #13#10#13#10 +
      'Please check GreBaPOS_DatabaseSetup.log in your TEMP folder (%TEMP%).',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  if not IsSqlServerInstalled() then
  begin
    MsgBox(
      'SQL Server installation finished, but the SQLEXPRESS service was not detected.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  Result := True;
end;

// PREPARE INSTALLATION

function PrepareToInstall(var NeedsRestart: Boolean): String;
begin
  Result := '';
  NeedsRestart := False;

  if IsSqlServerInstalled() then
  begin
    Log('SQL Server Express instance already exists. Skipping installation.');
  end
  else
  begin
    Log('SQL Server Express instance not found. Installing SQL Server Express.');

    if not InstallSQLServer() then
    begin
      Result :=
        'SQL Server Express installation failed or requires a restart.' +
        ' Setup cannot continue.';
      Exit;
    end;
  end;
end;

// DATABASE SETUP

function RunDatabaseSetup(): Boolean;
var
  ResultCode: Integer;
  PowerShellPath: string;
  Parameters: string;
begin
  Result := False;

  PowerShellPath :=
    ExpandConstant('{sys}\WindowsPowerShell\v1.0\powershell.exe');

  if not FileExists(PowerShellPath) then
  begin
    MsgBox(
      'Windows PowerShell was not found.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  Parameters :=
    '-NoProfile -NonInteractive -ExecutionPolicy Bypass ' +
    '-File "' + ExpandConstant('{app}\InstallDatabase.ps1') + '"';

  if not Exec(
    PowerShellPath,
    Parameters,
    ExpandConstant('{app}'),
    SW_HIDE,
    ewWaitUntilTerminated,
    ResultCode
  ) then
  begin
    MsgBox(
      'Unable to start the database installation script.',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  if ResultCode <> 0 then
  begin
    MsgBox(
      'GreBaPOS database setup failed.' + #13#10#13#10 +
      'Please check GreBaPOS_DatabaseSetup.log in your TEMP folder (%TEMP%).',
      mbCriticalError,
      MB_OK
    );
    Exit;
  end;

  Result := True;
end;

// AFTER APPLICATION FILES ARE INSTALLED

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    DatabaseSetupSucceeded := RunDatabaseSetup();

    if not DatabaseSetupSucceeded then
    begin
      RaiseException(
        'GreBaPOS database setup failed. Application launch has been stopped.'
      );
    end;
  end;
end;