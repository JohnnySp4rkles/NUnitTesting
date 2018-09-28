using NUnit.Framework;

namespace Calculator.Tests {

    [TestFixture]
    internal class MemoryClaculatorDataDrivenTests {
        private MemoryCalculator sut = new MemoryCalculator();

        #region Running a Test with Multiple Test Case Data

        [Test]
        public void ShouldSubtractTwoNegativeNumbers() {
            sut.Subtract(-5);
            sut.Subtract(-10);

            Assert.That(sut.CurrentValue, Is.EqualTo(15));
        }

        [TestCase(-5, -10, 15)]
        [TestCase(-5, -5, 10)]
        [TestCase(-5, 0, 5)]
        public void ShouldSubtractTwoNegativeNumbers_DataDriven(int fNum, int sNum, int exp) {
            sut = new MemoryCalculator();
            sut.Subtract(fNum);
            sut.Subtract(sNum);

            Assert.That(sut.CurrentValue, Is.EqualTo(exp));
        }

        #endregion Running a Test with Multiple Test Case Data
    }
}