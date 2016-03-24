:: This build file is very rigid and highly un-portable. I use is as a convenience on my own computer.
:: Note to self: Run this file within the KeePass directory!

SET basefolder=C:\Users\%username%\Documents\Code\GitHub\KeePass-SalsaCipher
SET srcfolder=%basefolder%\Salsa20Cipher
SET plgx=%basefolder%\Salsa20Cipher.plgx

rd %srcfolder%\bin /S /Q
rd %srcfolder%\obj /S /Q

.\KeePass.exe --plgx-create %srcfolder% --plgx-prereq-kp:2.18 --plgx-prereq-os:Windows --plgx-prereq-net:3

xcopy %plgx% /Y
