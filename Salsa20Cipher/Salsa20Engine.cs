/* 
 * Copyright (c) 2015 Scott Bennett
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * * Redistributions of source code must retain the above copyright notice, this
 *   list of conditions and the following disclaimer.
 * 
 * * Redistributions in binary form must reproduce the above copyright notice,
 *   this list of conditions and the following disclaimer in the documentation
 *   and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.IO;
using System.Security.Cryptography;

using KeePassLib;
using KeePassLib.Cryptography.Cipher;

namespace Salsa20Cipher {
    public sealed class Salsa20Engine : ICipherEngine {
        private PwUuid uuidCipher;
        private const string cipherName = "Salsa20 Cipher";

        private static readonly byte[] Salsa20UuidBytes = new byte[] {
            0xA6, 0xFF, 0x30, 0x81, 0xE9, 0x6E, 0x4F, 0xBA,
            0xAE, 0xDC, 0x98, 0xB3, 0xEA, 0x55, 0xFF, 0xFF
		};

        /// <summary>
        /// Basic constructor 
        /// </summary>
        public Salsa20Engine() {
            uuidCipher = new PwUuid(Salsa20UuidBytes);
        }

        /// <summary>
        /// Access this Cipher's UUID. 
        /// </summary>
        public PwUuid CipherUuid {
            get {
                return uuidCipher;
            }
        }

        /// <summary>
        /// Access this Cipher's name. 
        /// </summary>
        public string DisplayName {
            get {
                return cipherName;
            }
        }

        /// <summary>
        /// Encrypt the incoming plainTextStream. 
        /// </summary>
        /// <param name="plainTextStream"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns>An encrypted stream of bytes</returns>
        public Stream EncryptStream(Stream plainTextStream, byte[] key, byte[] iv) {
            ICryptoTransform iTransform = new Salsa20CryptoTransform(key, iv);

            return new CryptoStream(plainTextStream, iTransform, CryptoStreamMode.Write);
        }

        /// <summary>
        /// Decrypt the incoming encryptedStream. 
        /// </summary>
        /// <param name="encryptedStream"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns>The plaintext stream derived from encrypted stream</returns>
        public Stream DecryptStream(Stream encryptedStream, byte[] key, byte[] iv) {
            ICryptoTransform iTransform = new Salsa20CryptoTransform(key, iv);

            return new CryptoStream(encryptedStream, iTransform, CryptoStreamMode.Read);
        }
    }
}
