using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Tests.SomeNamespace {
    [TestFixture]
    public class MemoryCalculatorTests {
        MemoryCalculator sut;

        #region Running Code Before and After Each Test
        [Test]
        public void ShouldAdd() {
            sut.Add(10);
            sut.Add(5);
            Assert.That(sut.CurrentValue, Is.EqualTo(15));
        }
        
        [Test]
        public void ShouldSubstract() {
            sut.Subtract(5);
            Assert.That(sut.CurrentValue, Is.EqualTo(-5));
        }

        [SetUp] // [Setup] will do this before each test is run!
        public void BeforeEachTest() {
            Console.WriteLine("Before {0}", TestContext.CurrentContext.Test.Name);
            sut = new MemoryCalculator();
        }
        [TearDown] // This will execute after each test case.
        public void AfterEachTest() {
            Console.WriteLine("After {0}", TestContext.CurrentContext.Test.Name);
            sut = null;
        }
        #endregion
    }
}
