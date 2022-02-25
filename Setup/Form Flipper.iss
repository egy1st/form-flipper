[Setup]
AppName=DynamicComponents Form Flipper v4.0
AppVerName=DC Form Flipper v4.0
AppPublisher=EgyFirst Software , Inc.
AppPublisherURL=http://www.mygoldensoft.com
AppSupportURL=support@mygoldensoft.com
DefaultDirName={pf}\Dynamic Components\Form Flipper\
DefaultGroupName=Dynamic Components\Form Flipper\
LicenseFile=License.txt
OutputBaseFilename=form_flipper
VersionInfoCompany=EgyFirst Software , Inc.
VersionInfoDescription=Dynamic Components Form Flipper
VersionInfoVersion=4.0.0.0
RestartIfNeededByRun = True
WizardImageFile = Big02.bmp
WizardSmallImageFile=logo.bmp
BackColorDirection =toptobottom
BackColor = clBlue
BackColor2= clgreen
BackSolid=false
WindowStartMaximized=yes
WindowVisible=yes
WindowShowCaption=no
AppCopyright=EgyFirst Software 2005-2012 Copyright


[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked


[Files]
Source: "DC_FormFlipper35.dll"; DestDir: "{app}"
Source: "DC Form Flipper v4.0.chm"; DestDir: "{app}"
Source: "License.txt"; DestDir: "{app}"
Source: "License Agreement.doc"; DestDir: "{app}"
Source: "DC_FormFlipper.exe"  ; DestDir: "{app}"
Source: "nWind.accdb"; DestDir: "{app}"


; Visual Studio 2008 ////////////////////////////////////////////////////////
Source: "Tutorials\Visual Studio 2008\*.*"; DestDir: "{app}\Tutorials\Visual Studio 2008\"
Source: "Tutorials\Visual Studio 2008\My Project\*.*"; DestDir: "{app}\Tutorials\Visual Studio 2008\My Project"
Source: "DC_FormFlipper35.dll"; DestDir: "{app}\Tutorials\Visual Studio 2008\bin\Debug"
Source: "nWind.accdb"; DestDir: "{app}\Tutorials\Visual Studio 2008\bin\Debug"
;////////////////////////////////////////////////////////


; Visual Studio 2010 ////////////////////////////////////////////////////////
Source: "Tutorials\Visual Studio 2010\*.*"; DestDir: "{app}\Tutorials\Visual Studio 2010\"
Source: "Tutorials\Visual Studio 2010\My Project\*.*"; DestDir: "{app}\Tutorials\Visual Studio 2010\My Project"
Source: "DC_FormFlipper35.dll"; DestDir: "{app}\Tutorials\Visual Studio 2010\bin\Debug"
Source: "nWind.accdb"; DestDir: "{app}\Tutorials\Visual Studio 2010\bin\Debug"
;////////////////////////////////////////////////////////


[LangOptions]
LanguageName=English
LanguageID=$0409
DialogFontName=
DialogFontSize=8
WelcomeFontName=Verdana
WelcomeFontSize=12
TitleFontName=Arial
TitleFontSize=29
CopyrightFontName=Arial
CopyrightFontSize=10

[Icons]
Name: "{group}\Order Now"; Filename: "{app}\Order Now.url"
Name: "{group}\My Golden Soft Homepage"; Filename: "{app}\My Golden Soft Homepage.url"
Name: "{group}\Help"; Filename: "{app}\DC Form Flipper v4.0.chm"
Name: "{group}\Tutorials"; Filename: "{app}\Tutorials\"
Name: "{group}\Register DC_FormFlipper35"; Filename: "{app}\DC_FormFlipper35_Registrar.exe"
Name: "{group}\Uninstall DC Form Flipper"; Filename: "{app}\unins000.exe"
Name: "{userdesktop}\DC Form Flipper v4.0"; Filename: "{app}"; Tasks: desktopicon

[Run]
; NOTE: The following entry contains an English phrase ("Launch"). You are free to translate it into another language if required.
Filename: "{app}\DC_FormFlipper.exe"; Description: "Activate Trial"; Flags: shellexec postinstall skipifsilent
Filename: "{app}\DC Form Flipper v4.0.chm"; Description: "Launch Help"; Flags: shellexec postinstall skipifsilent
Filename: "{app}\Tutorials\"; Description: "Tutorials"; Flags: shellexec postinstall skipifsilent
Filename: "{app}\My Golden Soft Homepage.url"; Description: "Visit Homepage"; Flags: shellexec postinstall skipifsilent
