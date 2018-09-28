using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests {
    [TestFixture]
    class SpecialDateStoreTest {
        SpecialDateStore sut = new SpecialDateStore();

        [Test]
        public void ShouldHaveCorrectMilleniumDate() {
            var result = sut.DateOf(SpecialDates.NewMillenium);
            Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1, 0, 0, 0, 0)));
        }

        // Will fail because they are a milisecond apart
        //[Test]
        //public void ShouldHaveCorrectMilleniumDate_WithTolerance_A() {
        //    var result = sut.DateOf(SpecialDates.NewMillenium);
        //    Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1, 0, 0, 0, 1)));
        //}

        [Test]
        public void ShouldHaveCorrectMilleniumDate_WithTolerance_B() {
            var result = sut.DateOf(SpecialDates.NewMillenium);
            Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1, 0, 0, 0, 1))
                .Within(TimeSpan.FromMilliseconds(1)));
        }

        [Test]
        public void ShouldHaveCorrectMilleniumDate_WithTolerance_C() {
            var result = sut.DateOf(SpecialDates.NewMillenium);
            Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1, 0, 0, 0, 1))
                .Within(1).Milliseconds);
        }
    }
}
