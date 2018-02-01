using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mint.UnitTests
{
    [TestClass]
    public class MaskableInt32ComparableTests
    {
        [TestMethod]
        public void CompareTo_IntWithSameValue_ReturnsZero()
        {
            MaskableInt32 inputValue = 2;
            const int comparisonValue = 2;
            const int expectedResult = 0;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_IntWithSmallerValue_ReturnsOne()
        {
            MaskableInt32 inputValue = 2;
            const int comparisonValue = 1;
            const int expectedResult = 1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_IntWithHigherValue_ReturnsMinusOne()
        {
            MaskableInt32 inputValue = 2;
            const int comparisonValue = 3;
            const int expectedResult = -1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_MaskableInt32WithSameValue_ReturnsZero()
        {
            MaskableInt32 inputValue = 2;
            MaskableInt32 comparisonValue = 2;
            const int expectedResult = 0;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_MaskableInt32WithSmallerValue_ReturnsOne()
        {
            MaskableInt32 inputValue = 2;
            MaskableInt32 comparisonValue = 1;
            const int expectedResult = 1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_MaskableInt32WithHigherValue_ReturnsMinusOne()
        {
            MaskableInt32 inputValue = 2;
            MaskableInt32 comparisonValue = 3;
            const int expectedResult = -1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_BoxedIntWithSameValue_ReturnsZero()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = 2;
            const int expectedResult = 0;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_BoxedIntWithSmallerValue_ReturnsOne()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = 1;
            const int expectedResult = 1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareTo_BoxedIntWithHigherValue_ReturnsMinusOne()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = 3;
            const int expectedResult = -1;

            int actualResult = inputValue.CompareTo(comparisonValue);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareTo_InvalidObject_ThrowsException()
        {
            MaskableInt32 inputValue = 2;
            object comparisonValue = new object();
            
            inputValue.CompareTo(comparisonValue);
        }
    }
}
