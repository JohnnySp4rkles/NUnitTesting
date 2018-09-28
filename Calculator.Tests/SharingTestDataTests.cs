using NUnit.Framework;
using System.Collections;

namespace Calculator.Tests {

    [TestFixture]
    public class SharingTestDataTests {

        [TestCaseSource(typeof(ExampleTestCaseSourse))]
        public void ShouldSubtractTwoNegativeNumbers_DataDriven(int fNum, int sNum, int exp) {
            MemoryCalculator sut = new MemoryCalculator();
            sut.Subtract(fNum);
            sut.Subtract(sNum);

            Assert.That(sut.CurrentValue, Is.EqualTo(exp));
        }
    }

    public class ExampleTestCaseSourse : IEnumerable {

        public IEnumerator GetEnumerator() {
            yield return new[] { -5, -10, 15 };
            yield return new[] { -5, -5, 10 };
            yield return new[] { -5, 0, 5 };
            yield return new[] { 0, 0, 0 };
        }
    }
}