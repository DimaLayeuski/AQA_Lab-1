using System;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.Out.WriteLineAsync("OneTimeSetup....");
            _calculator = new Calculator();
        }

        [Test]
        [Category("SmokeTest")]
        [Property("Severity", 1)]
        public void TestSum()
        {
            Assert.AreEqual(5, _calculator.Sum(1, 4));
        }

        [Test]
        [Property("Priority", 2)]
        public void TestDiv()
        {
            Assert.AreEqual(4, _calculator.Div(8, 2));
            Assert.Throws<DivideByZeroException>(
                delegate { _calculator.Div(8, 0); });
        }

        [Test]
        public void TestDoubleDiv()
        {
            Assert.Multiple(() =>
            {
                double a = TestContext.CurrentContext.Random.NextDouble(100);
                double b = TestContext.CurrentContext.Random.NextDouble(10, 20);

                TestContext.Out.WriteLineAsync("First Double is " + a);
                TestContext.Out.WriteLineAsync($"Second Double is {b}");
                Assert.AreEqual(a / b, _calculator.Div(a, b));
                Assert.AreEqual(3.7737556561085972d, _calculator.Div(8.34, 2.21));
                Assert.True(Double.IsPositiveInfinity(_calculator.Div(8d, 0d)));
                Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-8d, 0d)));
                Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
                
            });
        }
       
    }
}