using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mint.UnitTests
{
    [TestClass]
    public class MaskableInt32EquatableTests
    {
        [TestMethod]
        public void Equals_IntWithSameValue_ReturnsTrue()
        {
            MaskableInt32 inputValue = 2;
            const int comparisonValue = 2;
            const bool expectedResult = true;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Equals_IntWithDifferentValue_ReturnsFalse()
        {
            MaskableInt32 inputValue = 2;
            const int comparisonValue = 1;
            const bool expectedResult = false;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Equals_BoxedIntWithSameValue_ReturnsFalse()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = 2;
            const bool expectedResult = false;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Equals_BoxedIntWithDifferentValue_ReturnsFalse()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = 1;
            const bool expectedResult = false;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Equals_MaskableInt32WithSameValue_ReturnsTrue()
        {
            MaskableInt32 inputValue = 2;
            MaskableInt32 comparisonValue = 2;
            const bool expectedResult = true;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Equals_MaskableInt32WithDifferentValue_ReturnsFalse()
        {
            MaskableInt32 inputValue = 2;
            MaskableInt32 comparisonValue = 1;
            const bool expectedResult = false;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_InvalidObject_ReturnsFalse()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = new object();
            const bool expectedResult = false;

            bool actualResult = inputValue.Equals(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
