using System;
using Xunit;

namespace SIT221_Library.OrderedLinkedList.Tests
{
    public class OrderedLinkedListTests
    {
        private OrderedLinkedList<int> lst;

        public OrderedLinkedListTests()
        {
            lst = new OrderedLinkedList<int>();
        }

        [Fact]
        public void LinkedList_Exists() => Assert.NotNull(lst);

        [Fact]
        public void LinkedList_Head_IsNull() => Assert.Null(lst.Head);

        [Fact]
        public void LinkedList_Count_IsZero() => Assert.Equal(0, lst.Count);

        [Fact]
        public void LinkedList_Index_ThrowsExceptionWhenEmpty() => 
            Assert.Throws<ArgumentOutOfRangeException>(() => lst[1]);

        [Fact]
        public void LinkedList_Add_HeadOK()
        {
            lst.Add(7);
            Assert.NotNull(lst.Head);
        }

        [Fact]
        public void LinkedList_Index_HeadDataWhenPresent()
        {
            lst.Add(8);
            Assert.Equal(8, lst[0]);
        }

        [Fact]
        public void LinkedList_Head_NextIsNullWhenHeadIsTail()
        {
            lst.Add(10);
            Assert.Null(lst.Head.Next);
        }

        [Fact]
        public void LinkedList_Head_PrevIsNull()
        {
            lst.Add(9);
            Assert.Null(lst.Head.Prev);
        }

        [Fact]
        public void LinkedList_Index_ReturnsDataWhenPresent()
        {
            lst.Add(1);
            lst.Add(3);
            lst.Add(4);
            lst.Add(2);
            Assert.Equal(3, lst[2]);
        }

        [Fact]
        public void LinkedList_Clear_HeadIsNull()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Clear();
            Assert.Null(lst.Head);
        }

        [Fact]
        public void LinkedList_Clear_CountIsZero()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Clear();
            Assert.Equal(0, lst.Count);
        }

        [Fact]
        public void LinkedList_Contains_ReturnsFalseForEmptyList()
        {
            Assert.False(lst.Contains(1));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsTrueForTargetIsHead()
        {
            lst.Add(4);
            lst.Add(5);
            lst.Add(6);
            Assert.True(lst.Contains(4));
        }

        [Fact]
        public void LinkedList_Contains_ReturnsTrueForTargetInList()
        {
            lst.Add(4);
            lst.Add(5);
            lst.Add(6);
            Assert.True(lst.Contains(5));
        }

        // [Fact]
        // public void LinkedList_Contains_ReturnsTrueForTargetIsTail()
        // {
        //     lst.Add(4);
        //     lst.Add(5);
        //     lst.Add(6);
        //     Assert.True(lst.Contains(6));
        // }

        [Fact]
        public void LinkedList_Contains_ReturnsFalseWhenValueNotInList()
        {
            lst.Add(10);
            lst.Add(20);
            lst.Add(30);
            Assert.False(lst.Contains(25));
        }

        [Fact]
        public void LinkedList_Remove_ReturnsFalseForEmptyList()
        {
            Assert.False(lst.Remove(1));
            Assert.Equal(0, lst.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenHeadRemoved()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(30);
            lst.Add(4);

            Assert.True(lst.Remove(1));
            Assert.Equal(2, lst.Head.Data);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenTargetRemoved()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(30);
            lst.Add(4);
            
            Assert.True(lst.Remove(4));
            Assert.Equal(3, lst.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsTrueWhenTailRemoved()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(30);
            lst.Add(4);

            Assert.True(lst.Remove(30));
            Assert.Equal(3, lst.Count);
        }

        [Fact]
        public void LinkedList_Remove_ReturnsFalseWhenTargetNotInList()
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(30);
            lst.Add(4);

            Assert.False(lst.Remove(100));
            Assert.Equal(4, lst.Count);
        }
    }
}
