@echo off
goto :TopOfCode
=======================================================================
make-plgx.bat

 Notes:
    This build file is slightly rigid and a little un-portable. I use it as a convenience
    on my own computer.

    Update %keepassDir% below to point to your installation of KeePass.
=======================================================================
:TopOfCode
@echo on

set keepassDir="C:\Program Files (x86)\KeePass"
set srcfolder=.\Salsa20Cipher
set plgx=.\Salsa20Cipher.plgx

rd %srcfolder%\bin /S /Q
rd %srcfolder%\obj /S /Q

%keepassDir%\KeePass.exe --plgx-create %srcfolder% --plgx-prereq-kp:2.18 --plgx-prereq-net:3

:: Copy the plgx into the KeePass installation directory
xcopy %plgx% %keepassDir% /Y

pause
