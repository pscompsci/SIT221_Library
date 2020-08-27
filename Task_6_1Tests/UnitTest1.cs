using System;
using Xunit;
using Task_6_1;

namespace Task_6_1Tests
{
    public class UnitTest1
    {
        int[] numbers = {10, 5, 6, 8, 2, 19, 9, 11, 15, 1, -8, 50};

        [Theory]
        [InlineData(-2)]   // 6 + -8
        [InlineData(0)]    // 8 + -8
        [InlineData(1)]    // 9 + -8
        [InlineData(15)]   // 10 + 5
        [InlineData(26)]   // 15 + 11
        [InlineData(42)]   // 50 + -8
        [InlineData(69)]   // 50 + 18
        public void Test1(int sum)
        {
            Assert.True(SumExists.Check(numbers, sum));
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(50)]
        [InlineData(100)]
        public void Test2(int sum)
        {
            Assert.False(SumExists.Check(numbers, sum));
        }
    }
}
