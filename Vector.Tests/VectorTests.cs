using System;
using Xunit;

namespace SIT221_Library.Vector.Tests
{
    public class VectorTests
    {
        private Vector<int> iVec;

        public VectorTests()
        {
            iVec = new Vector<int>();
        }

        [Fact]
        public void Vector_CreatsOK() => Assert.NotNull(iVec);

        [Fact]
        public void Vector_DefaultCapacityIsFour() => Assert.Equal(4, iVec.Capacity);

        [Fact]
        public void Vector_StartCountIsZero() => Assert.Equal(0, iVec.Count);

        [Fact]
        public void Vector_CapacityTenCreatesOK()
        {
            Vector<string> sVec = new Vector<string>(10);
            Assert.Equal(10, sVec.Capacity);
        }

        [Fact]
        public void Vector_Add_AddsValueOK()
        {
            iVec.Add(1);
            Assert.Equal(1, iVec.Count);
        }

        [Fact]
        public void Vector_Index_EmptyListThrowsException() => Assert.Throws<IndexOutOfRangeException>(() => iVec[0]);

        [Fact]
        public void Vector_Index_ReturnsValueFromValidIndex()
        {
            iVec.Add(5);
            Assert.Equal(5, iVec[0]);
        }

        [Fact]
        public void Vector_Add_BeyondCapacityResizesVector()
        {
            for(int i = 0; i < 10; i++)
            {
                iVec.Add(i);
            }
            Assert.Equal(16, iVec.Capacity);
        }

        [Fact]
        public void Vector_Capacity_ResizeTooSmallThrowsException()
        {
            for(int i = 0; i < 10; i++)
            {
                iVec.Add(i);
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => iVec.Capacity = 5);
        }

        [Fact]
        public void Vector_Contains_ReturnsTrueWhenTargetPresent()
        {
            for(int i = 0; i < 10; i++)
            {
                iVec.Add(i);
            }
            Assert.True(iVec.Contains(5));
        }

        [Fact]
        public void Vector_Contains_ReturnsFalseWhenTargetNotPresent()
        {
            for(int i = 0; i < 10; i++)
            {
                iVec.Add(i);
            }
            Assert.False(iVec.Contains(50));
        }

        [Fact]
        public void Vector_Clear_CountIsZero()
        {
            for(int i = 0; i < 10; i++)
            {
                iVec.Add(i);
            }
            iVec.Clear();
            Assert.Equal(0, iVec.Count);
        }
    }
}
