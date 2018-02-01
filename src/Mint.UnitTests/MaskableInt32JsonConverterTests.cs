using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Mint.UnitTests
{
    [TestClass]
    public class MaskableInt32JsonConverterTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            MaskableInt32.SetObfuscationSalt("buysedf23d");
            MaskableInt32.SetObfuscationAlphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
        }

        [TestMethod]
        public void DeserializeObject_IntegerString_ReturnsMaskableInt32()
        {
            const string inputValue = "1";
            MaskableInt32 expectedResult = 1;

            MaskableInt32 actualResult = JsonConvert.DeserializeObject<MaskableInt32>(inputValue);
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeserializeObject_ValidStringRepresentationOfMaskedInteger_ReturnsMaskableInt32()
        {
            string inputValue = JsonConvert.SerializeObject("MX12P");
            MaskableInt32 expectedResult = 123;

            MaskableInt32 actualResult = JsonConvert.DeserializeObject<MaskableInt32>(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonSerializationException))]
        public void DeserializeObject_InvalidString_ThrowsError()
        {
            string inputValue = JsonConvert.SerializeObject("invalid_value");
            
            JsonConvert.DeserializeObject<MaskableInt32>(inputValue);
        }

        [TestMethod]
        public void SeserializeObject_IntegerString_ReturnsJsonWithMaskedValue()
        {
            MaskableInt32 inputValue = 123;
            string expectedResult = JsonConvert.SerializeObject("MX12P");

            string actualResult = JsonConvert.SerializeObject(inputValue);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}