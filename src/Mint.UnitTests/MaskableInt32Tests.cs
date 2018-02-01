using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mint.UnitTests
{
    [TestClass]
    public class MaskableInt32Tests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            MaskableInt32.SetObfuscationSalt("buysedf23d");
            MaskableInt32.SetObfuscationAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
        }

        [TestMethod]
        public void GetMaskedValue_Integer_ReturnsMaskedValue()
        {
            MaskableInt32 inputValue = 123;
            const string expectedValue = "MX12P";

            string actualValue = inputValue.GetMaskedValue();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GetUnmaskedValue_ValidStringRepresentationOfMaskedInteger_ReturnsUnderlyingIntegerValue()
        {
            const string inputValue = "MX12P";
            const int expectedValue = 123;

            int actualValue = MaskableInt32.GetUnmaskedValue(inputValue);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUnmaskedValue_InvalidStringRepresentationOfMaskedInteger_ThrowsException()
        {
            const string inputValue = "invalid";

            MaskableInt32.GetUnmaskedValue(inputValue);
        }
    }
}
