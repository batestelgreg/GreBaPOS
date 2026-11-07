; ============================================================================
;  GreBaPOS v1.5 - Single-Click Installer (Inno Setup 6)
; ============================================================================
;  Flow (standalone - 1 installation only, nothing to set up manually):
;   1. Silently installs SQL Server Express LocalDB embedded engine
;      (~65 MB, no Windows service - auto-starts on demand when app connects).
;   2. Copies application files + automatic database setup scripts (sql\).
;   3. Runs "EnterprisePOS.WinForms.exe /provision" (hidden) which creates the
;      Batestel database from Batestel_Schema.sql + Batestel_Seed.sql.
;   4. App launches; any first-launch re-provision runs automatically too.
;
;  Compile from the repository root (GreBaPOS_Setup.iss must be compiled
;  with the project files in place):
;    - EnterprisePOS.WinForms\bin\Release   (build Release first)
;    - Database\*.sql
;    - prerequisites\SqlLocalDB.msi
; ============================================================================

#define MyAppName "GreBaPOS"
#define MyAppVersion "1.5"
#define MyAppPublisher "Greg Anderson Batestel"
#define MyAppExeName "EnterprisePOS.WinForms.exe"

#define AppBinPath AddBackslash(SourcePath) + "EnterprisePOS.WinForms\bin\Release"
#define AppExePath AddBackslash(AppBinPath) + MyAppExeName

#if !FileExists(AppExePath)
  #error "Please build EnterprisePOS.WinForms in Release mode first (" + AppExePath + " not found)."
#endif

#if !FileExists(AddBackslash(SourcePath) + "prerequisites\SqlLocalDB.msi")
  #error "prerequisites\SqlLocalDB.msi is missing. Obtain it with the SQL Server Express Installer (SQL2025-SSEI-Expr.exe): /Action=Download /MediaType=LocalDB"
#endif

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
OutputDir=Output
OutputBaseFilename=GreBaPOS_Setup
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern dark

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Application files (includes all required DLLs from bin\Release)
Source: "{#AppBinPath}\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs ignoreversion
; Database setup scripts used by the built-in /provision mode
Source: "Database\Batestel_Schema.sql"; DestDir: "{app}\sql"; Flags: ignoreversion
Source: "Database\Batestel_Seed.sql"; DestDir: "{app}\sql"; Flags: ignoreversion
; Embedded LocalDB engine installer
Source: "prerequisites\SqlLocalDB.msi"; DestDir: "{tmp}"; Flags: dontcopy

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; The database setup runs automatically in CurStepChanged via the app's /provision mode.
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent

[Code]

const
  NetFx48Release = 528040;

// .NET Framework 4.8 or later must be present on the machine.
function NetFramework48Installed(): Boolean;
var
  ReleaseValue: Cardinal;
begin
  Result :=
    RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', ReleaseValue) or
    RegQueryDWordValue(HKLM, 'SOFTWARE\WOW6432Node\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', ReleaseValue);

  if Result then
    Result := ReleaseValue >= NetFx48Release;
end;

// SQL Server Express LocalDB detection.
function LocalDbInstalled(): Boolean;
begin
  Result :=
    RegKeyExists(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions') or
    RegKeyExists(HKLM, 'SOFTWARE\WOW6432Node\Microsoft\Microsoft SQL Server Local DB\Installed Versions');
end;

function InstallLocalDB(): Boolean;
var
  ResultCode: Integer;
begin
  Result := False;

  ExtractTemporaryFile('SqlLocalDB.msi');

  if Exec(
      'msiexec.exe',
      '/i "' + ExpandConstant('{tmp}\SqlLocalDB.msi') + '" /qn IACCEPTSQLLOCALDBLICENSETERMS=YES /norestart',
      '', SW_HIDE, ewWaitUntilTerminated, ResultCode)
  and ((ResultCode = 0) or (ResultCode = 3010)) then
    Result := True
  else
    MsgBox(
      'SQL Server Express LocalDB could not be installed (msiexec returned ' +
      IntToStr(ResultCode) + ').',
      mbCriticalError, MB_OK);
end;

function PrepareToInstall(var NeedsRestart: Boolean): String;
begin
  Result := '';
  NeedsRestart := False;

  if not NetFramework48Installed() then
  begin
    Result :=
      'Microsoft .NET Framework 4.8 or later is required.' + #13#10 +
      'Download it from https://go.microsoft.com/fwlink/?LinkId=2085155 and run this setup again.';
    Exit;
  end;

  if LocalDbInstalled() then
  begin
    Log('LocalDB already installed - skipping engine installation.');
  end
  else
  begin
    Log('LocalDB not found - installing silently.');
    if not InstallLocalDB() then
    begin
      Result := 'GreBaPOS requires the embedded database engine (LocalDB), but its installation failed. Setup cannot continue.';
      Exit;
    end;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
  LogPath: String;
begin
  if CurStep = ssPostInstall then
  begin
    // Configure the database automatically (creates Batestel + seed data).
    if Exec(
        ExpandConstant('{app}\{#MyAppExeName}'),
        '/provision', '', SW_HIDE, ewWaitUntilTerminated, ResultCode)
    and (ResultCode = 0) then
    begin
      Log('Database provisioned successfully.');
    end
    else
    begin
      LogPath := GetEnv('TEMP') + '\GreBaPOS_Provision.log';
      MsgBox(
        'GreBaPOS was installed, but automatic database setup returned an error.' + #13#10#13#10 +
        'Details: ' + LogPath + #13#10#13#10 +
        'Starting the application will retry the database setup automatically.',
        mbError, MB_OK);
    end;
  end;
end;
