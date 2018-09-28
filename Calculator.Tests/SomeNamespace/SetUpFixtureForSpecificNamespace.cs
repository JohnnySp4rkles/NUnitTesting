using NUnit.Framework;
using System;

namespace Calculator.Tests.SomeNamespace {
    [SetUpFixture]
    class SetUpFixtureForSpecificNamespace {
        [SetUp]
        public void RunBeforeAnyTestsInSomeNamespace() {
            Console.WriteLine("### Before any tests in some namespace!!");
        }
        [TearDown]
        public void RunAfterAnyTestsInSomeNamespace() {
            Console.WriteLine("### After any tests in some namespace!!");
        }
    }
}
