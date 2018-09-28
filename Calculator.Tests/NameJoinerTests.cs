using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests {
    [TestFixture]
    public class NameJoinerTests {
        NameJoiner sut = new NameJoiner();

        [Test]
        public void ShouldJoinNames() {
            var fullName = sut.Join("Sarah", "Smith");
            Assert.That(fullName, Is.EqualTo("Sarah Smith"));
        }

        [Test]
        public void ShouldJoinNames_CaseInsensitive() {
            var fullName = sut.Join("sarah", "smith");
            Assert.That(fullName, Is.EqualTo("SARAH SMITH").IgnoreCase);
        }

        [Test]
        public void ShouldJoinNames_NotEqual() {
            var fullName = sut.Join("Sarah", "Smith");
            Assert.That(fullName, Is.Not.EqualTo("Gentry Smith"));
        }
    }

}
