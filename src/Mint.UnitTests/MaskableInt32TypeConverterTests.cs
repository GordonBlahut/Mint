using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mint.UnitTests
{
    [TestClass]
    public class MaskableInt32TypeConverterTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            MaskableInt32.SetObfuscationSalt("buysedf23d");
            MaskableInt32.SetObfuscationAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
        }

        [TestMethod]
        public void CanCanvertFrom_String_ReturnsTrue()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(MaskableInt32));
            Type inputValue = typeof(string);
            const bool expectedResult = true;

            bool actualResult = converter.CanConvertFrom(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanvertFrom_IntegerString_ReturnsMaskableInt32()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(MaskableInt32));
            const string inputValue = "1";
            MaskableInt32 expectedResult = 1;

            MaskableInt32 actualResult = (MaskableInt32) converter.ConvertFrom(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CanvertFrom_ValidStringRepresentationOfMaskedInteger_ReturnsMaskableInt32()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(MaskableInt32));
            const string inputValue = "MX12P";
            MaskableInt32 expectedResult = 123;

            MaskableInt32 actualResult = (MaskableInt32) converter.ConvertFrom(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}