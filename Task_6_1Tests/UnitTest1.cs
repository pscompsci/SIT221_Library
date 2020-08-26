using System;
using Xunit;
using Task_6_1;

namespace Task_6_1Tests
{
    public class UnitTest1
    {
        int[] numbers = {10, 5, 6, 8, 2, 19, 9, 11, 15, 1, -8, 50};


        [Theory]
        [InlineData(15)]
        [InlineData(26)]
        [InlineData(-2)]
        [InlineData(0)]
        [InlineData(42)]
        [InlineData(69)]
        [InlineData(1)]
        public void Test1(int sum)
        {
            Assert.True(SumExists.Check(numbers, sum));
        }

        [Theory]
        [InlineData(50)]
        [InlineData(-100)]
        [InlineData(100)]
        public void Test2(int sum)
        {
            Assert.False(SumExists.Check(numbers, sum));
        }
    }
}
