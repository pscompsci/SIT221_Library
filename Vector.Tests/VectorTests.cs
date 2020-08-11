using System;
using Xunit;

namespace SIT221_Library.Vector.Tests
{
    public class VectorTests
    {
        private Vector<int> vector;

        public VectorTests()
        {
            vector = new Vector<int>();
        }

        [Fact]
        public void Vector_CreatsOK() => Assert.NotNull(vector);

        [Fact]
        public void Vector_DefaultCapacityIsFour() => Assert.Equal(10, vector.Capacity);

        [Fact]
        public void Vector_StartCountIsZero() => Assert.Equal(0, vector.Count);

        [Fact]
        public void Vector_CapacityTenCreatesOK()
        {
            Vector<string> sVec = new Vector<string>(10);
            Assert.Equal(10, sVec.Capacity);
        }

        [Fact]
        public void Vector_Add_AddsValueOK()
        {
            vector.Add(1);
            Assert.Equal(1, vector.Count);
        }

        [Fact]
        public void Vector_Index_EmptyListThrowsException() => Assert.Throws<IndexOutOfRangeException>(() => vector[0]);

        [Fact]
        public void Vector_Index_ReturnsValueFromValidIndex()
        {
            vector.Add(5);
            Assert.Equal(5, vector[0]);
        }

        [Fact]
        public void Vector_Add_BeyondCapacityResizesVector()
        {
            for(int i = 0; i < 11; i++)
            {
                vector.Add(i);
            }
            Assert.Equal(20, vector.Capacity);
        }

        [Fact]
        public void Vector_Contains_ReturnsTrueWhenTargetPresent()
        {
            for(int i = 0; i < 10; i++)
            {
                vector.Add(i);
            }
            Assert.True(vector.Contains(5));
        }

        [Fact]
        public void Vector_Contains_ReturnsFalseWhenTargetNotPresent()
        {
            for(int i = 0; i < 10; i++)
            {
                vector.Add(i);
            }
            Assert.False(vector.Contains(50));
        }

        [Fact]
        public void Vector_Clear_CountIsZero()
        {
            for(int i = 0; i < 10; i++)
            {
                vector.Add(i);
            }
            vector.Clear();
            Assert.Equal(0, vector.Count);
        }

        [Fact]
        public void Vector_RemoveAt_ThrowsExceptionWhenVectorIsEmpty()
        {
            // Vector is empty at this point (ie. created but nothing added/inserted)
            Assert.Throws<IndexOutOfRangeException>(() => vector.RemoveAt(0));
        }

        [Fact]
        public void Vector_RemoveAt_ThrowsExceptionWhenIndexLessThanZero()
        {
            vector.Insert(0, 10);
            Assert.Throws<IndexOutOfRangeException>(() => vector.RemoveAt(-1));
        }

        [Fact]
        public void Vector_RemoveAt_ThrowsExceptionWhenIndexEqualsCount()
        {
            vector.Insert(0, 10);
            Assert.Throws<IndexOutOfRangeException>(() => vector.RemoveAt(vector.Count));
        }

        [Fact]
        public void Vector_RemoveAt_OK()
        {
            for(int i = 0; i < 11; i++)
            {
                vector.Insert(i, i);
            }
            vector.RemoveAt(5);
            Assert.Equal("[0, 1, 2, 3, 4, 6, 7, 8, 9, 10]", vector.ToString());
            Assert.Equal(10, vector.Count);
        }

        [Fact]
        public void Vector_RemoveAt_MultipleOK()
        {
            // Remove number at index 4, then number index 0, and then number at index 'vector.Count-1'
            for(int i = 0; i < 15; i++)
            {
                vector.Insert(i, i);
            }
            // [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
            vector.RemoveAt(4);                // removes '4'
            vector.RemoveAt(0);                // removes '0'
            vector.RemoveAt(vector.Count - 1); // removes '14'
            Assert.Equal("[1, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13]", vector.ToString());
            Assert.Equal(12, vector.Count);
        }
    }
}
