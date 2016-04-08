/* 
 * Copyright (c) 2015-2016 Scott Bennett
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

using KeePass.Plugins;

namespace Salsa20Cipher {
    public sealed class Salsa20CipherExt : Plugin {
        private const string updateUrl = 
            "https://raw.githubusercontent.com/sbennett1990/KeePass-SalsaCipher/master/version-information.txt";

        private IPluginHost pluginHost = null;
        private static Salsa20Engine salsa20CipherEngine = new Salsa20Engine();

        /// <summary>
        /// Access the URL of my version information file. (Read-Only) 
        /// </summary>
        public override string UpdateUrl {
            get {
                return updateUrl;
            }
        }

        /// <summary>
        /// Initialize the Salsa20 Cipher plugin. 
        /// </summary>
        /// <param name="host">The host application (e.g. KeePass 2.18)</param>
        /// <returns>True for successful initialization; false otherwise</returns>
        public override bool Initialize(IPluginHost host) {
            if (host == null) {
                return false;
            }

            if (salsa20CipherEngine == null) {
                return false;
            }

            this.pluginHost = host;
            this.pluginHost.CipherPool.AddCipher(salsa20CipherEngine);

            return true;
        }
    }
}
