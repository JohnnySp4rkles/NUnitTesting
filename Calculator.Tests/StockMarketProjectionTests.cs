using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests {
    [TestFixture]
    [Category("money")]

    class StockMarketProjectionTests {
        StockMarketProjection sut = new StockMarketProjection();

        [Test]
        //[Ignore("Ignore Test")]
        public void ShouldProjectShortTerm() {
            var marketValue = sut.CalculateShortTerm();
            Assert.That(marketValue, Is.EqualTo(200));
        }

        [Test]
        [Category("long")]
        [MaxTime(5500)]
        public void ShouldProjectLongTerm() {
            var marketValue = sut.CalculateLongTerm();
            Assert.That(marketValue, Is.EqualTo(50));
        }
    }
}
