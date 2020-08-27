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
        public void SumDoesExist(int sum)
        {
            Assert.True(SumExists.Check(numbers, sum));
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(50)]
        [InlineData(100)]
        public void SumDoesNotExist(int sum)
        {
            Assert.False(SumExists.Check(numbers, sum));
        }

        [Theory]
        [InlineData(10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0)]
        public void IntStackPushMin(params int[] numbers)
        {
            IntStack stack = new IntStack();
            for(int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
                Assert.Equal((numbers.Length - 1) - i, stack.Min());
            }
        }

        [Theory]
        [InlineData(10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0)]
        public void IntStackPopMin(params int[] numbers)
        {
            IntStack stack = new IntStack();
            for(int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                stack.Pop();
                Assert.Equal(i + 1, stack.Min());
            }
        }

        [Theory]
        [InlineData(10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0)]
        public void StackPushMin(params int[] numbers)
        {
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
                Assert.Equal((numbers.Length - 1) - i, stack.Min());
            }
        }

        [Theory]
        [InlineData(10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0)]
        public void StackPopMin(params int[] numbers)
        {
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                stack.Pop();
                Assert.Equal(i + 1, stack.Min());
            }
        }
    }
}
