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

        [SetUp]
        public void Setup()
        {
            Console.Out.WriteLineAsync("Setup....");
        }

        [Test]
        [Category("SmokeTest")]
        [Property("Priority", 10)]
        public void TestSum()
        {
            Assert.AreEqual(7, _calculator.Sum(3, 4));
        }

        [TestCase(-1, 5, 4)]
        [TestCase(-3, -8, -11)]
        [TestCase(-3, 0, -3)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 7, 12)]
        [TestCase(6, -8, -2)]
        public void TestSumWithTestCase(int num1, int num2, int result)
        {
            var expected = result;
            var actual = _calculator.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDiv()
        {
            var a = 10;
            var b = 2;
            var zero = 0;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(5, _calculator.Div(a, b));
                Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(a, zero); });
                Assert.Greater(a,_calculator.Div(a, b));
                Assert.Less(_calculator.Div(a, b),a);
            });
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
                Assert.True(Double.IsPositiveInfinity(_calculator.Div(7d, 0d)));
                Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-7d, 0d)));
                Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
            });
        }

        [TestCaseSource(typeof(DataDiv), nameof(DataDiv.TestCases))]
        public int TestDivWithCaseSource(int num1, int num2)
        {
            return _calculator.Div(num1, num2);
        }

        [TestCaseSource(typeof(DataDiv), nameof(DataDiv.TestCases))]
        [Ignore("Ignoring TestCase")]
        public int TestDivWithCaseSourceIgnore(int num1, int num2)
        {
            return _calculator.Div(num1, num2);
        }

        [Test]
        public void Calculator_ResultOverflow_ThrowsOverflowException()
        {
            Assert.Throws(typeof(OverflowException), () => { _calculator.Div(int.MinValue, -1); });
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown...");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Calculator closing...");
        }
    }
}