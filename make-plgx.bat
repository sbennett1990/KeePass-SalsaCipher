@echo off
goto :TopOfCode

=======================================================================
make-plgx.bat

 Notes:
    This build file is very rigid and highly un-portable. I use is as a convenience on my own computer.
    
    This file should be run within the KeePass installation directory. 
    
    Update %basefolder% below to point to your development directory.
=======================================================================

:TopOfCode
@echo on
REM Note to self: Run this file within the KeePass installation directory!

set basefolder=C:\Users\%username%\Documents\Code\GitHub\KeePass-SalsaCipher
set srcfolder=%basefolder%\Salsa20Cipher
set plgx=%basefolder%\Salsa20Cipher.plgx

rd %srcfolder%\bin /S /Q
rd %srcfolder%\obj /S /Q

.\KeePass.exe --plgx-create %srcfolder% --plgx-prereq-kp:2.18 --plgx-prereq-net:3

xcopy %plgx% /Y
