using System;
using System.Collections.Generic;
using System.Text;

using Lib1;
using NUnit.Framework;
using NUnit;

namespace Lib1.Test
{
    public class LibTest
    {
        [TestCase("1 2 4 1", 7)]
        [TestCase("2 10 43 23", 200)]
        [TestCase("3 120 43 29", 120)]
        [TestCase("4 43 0 12 3", 0)]
        public void CalculateMethodTest(string input, int expected)
        {
            Assert.AreEqual(MainLib.Calculate(input), expected);
        }
        [Test]
        public void PartAverageCalculationTest()
        {
            var values = new int[4] { 3, 5, 1, 5 };
            var expected = 3.5;
            Assert.AreEqual(MainLib.GetPartAverage(values), expected);
        }
    }
}
