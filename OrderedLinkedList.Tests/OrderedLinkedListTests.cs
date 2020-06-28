using System;
using Xunit;

namespace SIT221_Library.OrderedLinkedList.Tests
{
    public class OrderedLinkedListTests
    {
        private OrderedLinkedList<int> intList;

        public OrderedLinkedListTests()
        {
            intList = new OrderedLinkedList<int>();
        }

        [Fact]
        public void LinkedList_Exists() => Assert.NotNull(intList);

        [Fact]
        public void LinkedList_Head_IsNull() => Assert.Null(intList.Head);

        [Fact]
        public void LinkedList_Count_IsZero() => Assert.Equal(0, intList.Count);

        [Fact]
        public void LinkedList_Index_ThrowsExceptionWhenEmpty() => 
            Assert.Throws<ArgumentOutOfRangeException>(() => intList[1]);

        [Fact]
        public void LinkedList_Add_HeadOK()
        {
            intList.Add(7);
            Assert.NotNull(intList.Head);
        }

        [Fact]
        public void LinkedList_Index_HeadDataWhenPresent()
        {
            intList.Add(8);
            Assert.Equal(8, intList[0]);
        }

        [Fact]
        public void LinkedList_Head_NextIsNullWhenHeadIsTail()
        {
            intList.Add(10);
            Assert.Null(intList.Head.Next);
        }

        [Fact]
        public void LinkedList_Head_PrevIsNull()
        {
            intList.Add(9);
            Assert.Null(intList.Head.Prev);
        }

        [Fact]
        public void LinkedList_Index_ReturnsDataWhenPresent()
        {
            intList.Add(1);
            intList.Add(3);
            intList.Add(4);
            intList.Add(2);
            Assert.Equal(3, intList[2]);
        }

        [Fact]
        public void LinkedList_Clear_HeadIsNull()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Clear();
            Assert.Null(intList.Head);
        }

        [Fact]
        public void LinkedList_Clear_CountIsZero()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Clear();
            Assert.Equal(0, intList.Count);
        }

        [Fact]
        public void LinkedList_Contains_ReturnsFalseForEmptyList()
        {
            Assert.False(intList.Contains(1));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsTrueForTargetIsHead()
        {
            intList.Add(4);
            intList.Add(5);
            intList.Add(6);
            Assert.True(intList.Contains(4));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsTrueForTargetInList()
        {
            intList.Add(4);
            intList.Add(5);
            intList.Add(6);
            Assert.True(intList.Contains(5));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsTrueForTargetIsTail()
        {
            intList.Add(4);
            intList.Add(5);
            intList.Add(6);
            Assert.True(intList.Contains(6));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsFalseWhenValueNotInList()
        {
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            Assert.False(intList.Contains(25));
        }

        [Fact]
        public void LinkedList_Remove_ReturnsFalseForEmptyList()
        {
            Assert.False(intList.Remove(1));
            Assert.Equal(0, intList.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenHeadRemoved()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(30);
            intList.Add(4);

            Assert.True(intList.Remove(1));
            Assert.Equal(2, intList.Head.Data);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenTargetRemoved()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(30);
            intList.Add(4);
            
            Assert.True(intList.Remove(4));
            Assert.Equal(3, intList.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenTailRemoved()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(30);
            intList.Add(4);

            Assert.True(intList.Remove(30));
            Assert.Equal(3, intList.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsFalseWhenTargetNotInList()
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(30);
            intList.Add(4);

            Assert.False(intList.Remove(100));
            Assert.Equal(4, intList.Count);
        }
    }
}
