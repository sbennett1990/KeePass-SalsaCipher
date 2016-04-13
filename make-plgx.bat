@echo off
goto :TopOfCode
=======================================================================
make-plgx.bat

 Notes:
    This build file is very rigid and highly un-portable. I use it as a convenience
    on my own computer. This is because a relative path to the source code project
    folder will *not* work with the --plgx-create command.

    For more info, see: http://keepass.info/help/v2_dev/plg_index.html#plgx

    Update %srcfolder% below with your full path to the project folder
    Update %keepassDir% below to point to your installation of KeePass
=======================================================================
:TopOfCode
@echo on

set keepassDir="C:\Program Files (x86)\KeePass"
set srcfolder="C:\Users\sbennet\Documents\Code\GitHub\KeePass-SalsaCipher\Salsa20Cipher"
set plgx=Salsa20Cipher.plgx

rd %srcfolder%\bin /S /Q
rd %srcfolder%\obj /S /Q

%keepassDir%\KeePass.exe --plgx-create %srcfolder% --plgx-prereq-kp:2.18 --plgx-prereq-net:3

:: Copy the plgx into the KeePass installation directory
xcopy %plgx% %keepassDir% /Y

pause
