using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator.AllClear();
        }

        [TestCase(5, 3, 8)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Addition_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        
    }
}
