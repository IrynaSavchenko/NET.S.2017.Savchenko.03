using System;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class CalculationTests
    {
        #region Even Index

        private static int[] beyondMaxSizeArray;

        public CalculationTests()
        {
            beyondMaxSizeArray = new int[Calculation.MaxArraySize];
        }

        [TestCase(new [] { 1, 2, 3, 4, 3, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new [] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new [] {-5, 3, 1}, ExpectedResult = -1)]
        public int FindEvenIndex_ValidInputArray_EvenIndex(int[] array)
        {
            return Calculation.FindEvenIndex(array);
        }

        [TestCase(new int[] {})]
        [Test, TestCaseSource(nameof(beyondMaxSizeArray))]
        public void FindEvenIndex_InvalidInputArray_ThrowsArgumentException(int[] array)
        {
            Assert.Throws<ArgumentException>(() => Calculation.FindEvenIndex(array));
        }

        [TestCase(null)]
        public void FindEvenIndex_NullInputArray_ThrowsArgumentNullException(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => Calculation.FindEvenIndex(array));
        }

        #endregion

        #region Next Bigger Number

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public static int GetNextBiggerNumber_ValidInputNumber_NextBiggerNumber(int number)
        {
            return Calculation.GetNextBiggerNumber(number);
        }

        [TestCase(-12)]
        [TestCase(0)]
        public static void GetNextBiggerNumber_InValidInputNumber_NextBiggerNumber(int number)
        {
            Assert.Throws<ArgumentException>(() => Calculation.GetNextBiggerNumber(number));
        }

        #endregion
    }
}
