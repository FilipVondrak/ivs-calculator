#define MyAppName "ivs_calc_starymedved"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Vit Kraus <xkrausv00@vutbr.cz>"
#define MyAppExeName "ivs_calc_starymedved.exe"

[Setup]
AppId={{A1234567-B89C-4DEF-9123-4567890ABCDE}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
PrivilegesRequired=admin
OutputBaseFilename=ivs_calc_starymedved_installer
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a desktop icon"; GroupDescription: "Additional icons"; Flags: unchecked

[Files]
Source: "..\out\win-x64\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

; Use the .ico file from Assets as the installer icon
Source: "..\src\ivs_calc_proj\Assets\avalonia-logo.ico"; DestDir: "{app}"; Flags: ignoreversion

; Optional: include a license or README
Source: "..\README.md"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\avalonia-logo.ico"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\avalonia-logo.ico"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
