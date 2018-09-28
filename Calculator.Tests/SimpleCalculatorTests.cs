using NUnit.Framework;
using System;

namespace Calculator.Tests {

    [TestFixture]
    public class SimpleCalculatorTests {
        private SimpleCalculator sut = new SimpleCalculator();

        #region Numerical Equality
        [Test]
        public void ShouldAddTwoNumbers() {
            var result = sut.Add(2, 1);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ShouldMultiplyTwoNumbers() {
            var result = sut.Multiply(2, 10);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void ShouldAddInts() {
            var result = sut.AddInts(2, 10);
            Assert.That(result, Is.EqualTo(12));
        }

        // This fails because of floating points have infinite decimal places.
        //[Test]
        //public void ShouldAddDoubles() {
        //    var result = sut.AddDoubles(2.1, 9.2);
        //    Assert.That(result, Is.EqualTo(11.3));
        //}

        [Test]
        public void ShouldAddDoubles_WithTolerance() {
            var result = sut.AddDoubles(2.1, 9.2);
            // adding the 'Within' states, it will be withing 11.31 and 11.29...
            Assert.That(result, Is.EqualTo(11.3).Within(0.01));
        }

        [Test]
        public void ShouldAddDoubles_WithPercentage() {
            var result = sut.AddDoubles(50, 50);
            Assert.That(result, Is.EqualTo(101).Within(1).Percent); // Tolerance of 1%!
        }

        [Test]
        public void ShouldAddDoubles_WithBadTolerance() {
            var result = sut.AddDoubles(1.1, 2.2);
            // 1.1 + 2.2 = 3.3 Tolerance between 130 and -70!
            Assert.That(result, Is.EqualTo(30).Within(100)); 
        }

        [Test]
        public void ShouldAddDoubles_IsNegative() {
            var result = sut.AddDoubles(1, -10);
            Assert.That(result, Is.Negative); 
        }


        [Test]
        public void ShouldDivide() {
            var result = sut.Divide(10, 2);
            Assert.That(result, Is.EqualTo(5));
        }
        #endregion

        #region Exception Tests
        [Test]
        public void SouldErrorWhenDividingByZero() {
            Assert.That(() => sut.Divide(200, 0), Throws.Exception);
        }

        [Test]
        public void SouldErrorWhenDividingByZero_ExplicitExceptionType() {
            Assert.That(() => sut.Divide(50, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void ShouldErrorWhenNumberTooBig() {
            Assert.That(() => sut.Divide(200, 2), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ShouldErrorWhenNumberTooBig_MoreExplicit() {
            Assert.That(() => sut.Divide(200, 2), 
                Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Matches<ArgumentOutOfRangeException>(x=>x.ParamName == "value"));
        }
        #endregion
    }
}