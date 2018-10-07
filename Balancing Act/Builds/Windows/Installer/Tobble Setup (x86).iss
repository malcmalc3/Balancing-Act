; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Tobble"
#define MyAppVersion "1.0"
#define MyAppPublisher "Milton GaMMMes"
#define MyAppURL "https://github.com/malcmalc3"
#define MyAppExeName "x86.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D00E0FF8-8A61-4AFF-A0AD-D578325290B2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\Installer
OutputBaseFilename=Tobble Setup (x86)
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\x86\Tobble x86 0.11\x86.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\x86\Tobble x86 0.11\UnityCrashHandler32.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\x86\Tobble x86 0.11\UnityPlayer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\x86\Tobble x86 0.11\Mono\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\malcmalc3\Documents\Unity\Balancing-Act\Balancing Act\Builds\Windows\x86\Tobble x86 0.11\x86_Data\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
