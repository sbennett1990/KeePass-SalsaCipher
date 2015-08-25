# KeePass-SalsaCipher

Enables KeePass to encrypt databases using the Salsa20 cipher. Just download 
the released `Salsa20Cipher.plgx` file and put it in the KeePass installation 
folder. KeePass should automatically recognize it as an available encryption 
algorithm. 

http://keepass.info/plugins.html

### Requirements

* KeePass 2.18 or higher
* .NET framework v3.0 or higher

### Build Info

The released `Salsa20Cipher.plgx` is built using these options:

`--plgx-prereq-kp:2.18 --plgx-prereq-os:Windows --plgx-prereq-net:3`

See the [KeePass plugin development page](http://keepass.info/help/v2_dev/plg_index.html#plgx) 
for more information.

### Notes

* This project was created with Visual Studio 2010
* The plugin has only been tested on Windows 7
