using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests {
    [TestFixture]
    class ClassWithBugsTests {
        [Test]
        [Repeat(10000)]
        public void ShouldDoWork() {
            ClassWithBugs sut = new ClassWithBugs();
            sut.DoWork();
        }
    }
}
