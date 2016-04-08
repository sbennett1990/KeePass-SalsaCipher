using System;

using NUnit.Framework;

using Salsa20Cipher;

namespace Tests {
    [TestFixture]
    public class BitTwiddleTest {
        [Test]
        public void Add_TwoUints_ReturnsSum() {
            uint a = 256;
            uint b = 256;
            uint expected = 512;

            uint sum = bits.Add(a, b);

            Assert.That(sum, Is.EqualTo(expected));
        }


        public void Add_TwoBigUints_ReturnsOverflowSum() {

        }
    }
}
