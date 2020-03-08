using System;
using Xunit;

namespace HomeRadar.Tests
{
    public class UnitTest1
    {
        public double SquareRoot(double input)
        {
            return input / 2;
        }

        [Fact]
        public void Test1()
        {
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            // Run the method under test:
            double actualResult = SquareRoot(input);
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
