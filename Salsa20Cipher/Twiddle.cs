/* 
 * Copyright (c) 2016 Scott Bennett
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

namespace Salsa20Cipher {
    /// <summary>
    /// Provides some bit twiddling functions needed for Salsa20.
    /// </summary>
    public static class Twiddle {
        /// <summary>
        /// Unchecked integer addition. The Salsa spec defines certain operations 
        /// to use 32-bit unsigned integer addition modulo 2^32. 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns>The result of (v + w) modulo 2^32</returns>
        public static uint Add(uint v, uint w) {
            return unchecked(v + w);
        }

        /// <summary>
        /// Add 1 to the input parameter using unchecked integer addition. The 
        /// Salsa spec defines certain operations to use 32-bit unsigned integer 
        /// addition modulo 2^32. 
        /// </summary>
        /// <param name="v"></param>
        /// <returns>The result of (v + 1) modulo 2^32</returns>
        public static uint AddOne(uint v) {
            return unchecked(v + 1);
        }

        /// <summary>
        /// n-bit left rotation operation (towards the high bits) for 32-bit 
        /// integers. 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="c"></param>
        /// <returns>The result of (v LEFTSHIFT c)</returns>
        public static uint Rotate(uint v, int c) {
            return (v << c) | (v >> (32 - c));
        }

        /// <summary>
        /// Serialize the input integer into the output buffer. The input integer 
        /// will be split into 4 bytes and put into four sequential places in the 
        /// output buffer, starting at the outputOffset. 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        /// <param name="outputOffset"></param>
        public static void ToBytes(uint input, byte[] output, int outputOffset) {
            unchecked {
                output[outputOffset] = (byte) input;
                output[outputOffset + 1] = (byte) (input >> 8);
                output[outputOffset + 2] = (byte) (input >> 16);
                output[outputOffset + 3] = (byte) (input >> 24);
            }
        }

        /// <summary>
        /// Convert four bytes of the input buffer into an unsigned 
        /// 32-bit integer, beginning at the inputOffset. 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="inputOffset"></param>
        /// <returns>An unsigned 32-bit integer</returns>
        public static uint ToUInt32(byte[] input, int inputOffset) {
            unchecked {
                return (uint) (((input[inputOffset]
                                 | (input[inputOffset + 1] << 8))
                                 | (input[inputOffset + 2] << 16))
                                 | (input[inputOffset + 3] << 24));
            }
        }
    }
}
