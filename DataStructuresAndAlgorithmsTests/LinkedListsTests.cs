using System;
using Xunit;
using DataStructuresAndAlgorithms.LinkedLists;

namespace DataStructureAndAlgorithms.Tests
{
    public class LinkedListsTests
    {
        [Fact]
        public void CreateEmptyList()
        {
            LinkedList list = new LinkedList();

            Assert.Equal(String.Empty, list.ToString());
        }

        [Fact]
        public void SingleNodeList()
        {
            int value = 10;
            LinkedList list = new LinkedList();

            list.AddAtEnd(value);

            Assert.Equal($"{value}", list.ToString());
        }

        [Fact]
        public void AddingMultipleNodesAtEnd()
        {
            int value1 = 1;
            int value2 = 2;
            int value3 = 3;
            string expected = $"{value1},{value2},{value3}";
            LinkedList list = new LinkedList();

            list.AddAtEnd(value1);
            list.AddAtEnd(value2);
            list.AddAtEnd(value3);

            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void AddingMultipleNodesAtBeginning()
        {
            int value1 = 1;
            int value2 = 2;
            int value3 = 3;
            string expected = $"{value3},{value2},{value1}";
            LinkedList list = new LinkedList();

            list.AddAtBeginning(value1);
            list.AddAtBeginning(value2);
            list.AddAtBeginning(value3);

            Assert.Equal(expected, list.ToString());
        }

        [Fact]
        public void RemoveItemFromEmptyList()
        {
            LinkedList list = new LinkedList();
            list.RemoveFirstNodeWithValue(1);

            Assert.Equal(String.Empty, list.ToString());
        }

        [Fact]
        public void RemoveItemFromListWithOneNode()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);

            list.RemoveFirstNodeWithValue(1);

            Assert.Equal(String.Empty, list.ToString());
        }

        [Fact]
        public void RemoveHeadFromListWithTwoValues()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);

            list.RemoveFirstNodeWithValue(1);

            Assert.Equal("2", list.ToString());
        }

        [Fact]
        public void RemoveNodeFromMiddleOfList()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);
            list.AddAtEnd(3);
            list.AddAtEnd(4);

            list.RemoveFirstNodeWithValue(3);

            Assert.Equal("1,2,4", list.ToString());
        }

        [Fact]
        public void RemoveAllNodesEqualToValue()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);
            list.AddAtEnd(3);
            list.AddAtEnd(2);
            list.AddAtEnd(2);
            list.AddAtEnd(4);
            list.AddAtEnd(2);

            list.RemoveAllNodesWithValue(2);

            Assert.Equal("1,3,4", list.ToString());
        }

        [Fact]
        public void RemovingAllNodesFromAList()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(2);
            list.AddAtEnd(2);
            list.AddAtEnd(2);
            list.AddAtEnd(2);
            list.AddAtEnd(2);

            list.RemoveAllNodesWithValue(2);

            Assert.Equal(String.Empty, list.ToString());
        }

        [Fact]
        public void NodeExistsOnEmptyList()
        {
            LinkedList list = new LinkedList();

            Assert.False(list.NodeExists(1));
        }

        [Fact]
        public void NodeExistsInList()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);
            list.AddAtEnd(3);
            list.AddAtEnd(4);

            Assert.True(list.NodeExists(3));
        }

        [Fact]
        public void NodeDoesNotExistInList()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);

            Assert.False(list.NodeExists(3));
        }

        [Fact]
        public void CountNodesWithValueInEmptyList()
        {
            LinkedList list = new LinkedList();

            Assert.Equal(0, list.CountNodesWithValue(1));
        }

        [Fact]
        public void CountNodesInListEqualToValue()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);
            list.AddAtEnd(1);
            list.AddAtEnd(1);
            list.AddAtEnd(3);
            list.AddAtEnd(5);

            Assert.Equal(3, list.CountNodesWithValue(1));
        }

        [Fact]
        public void FirstIndexOfValueInEmptyList()
        {
            LinkedList list = new LinkedList();

            Assert.Equal(-1, list.FirstIndexOfValue(1));
        }

        [Fact]
        public void FirstIndexWhereValueIsAtHead()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);

            Assert.Equal(0, list.FirstIndexOfValue(1));
        }

        [Fact]
        public void FirstIndexOfValue()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);
            list.AddAtEnd(3);
            list.AddAtEnd(3);
            list.AddAtEnd(5);

            Assert.Equal(2, list.FirstIndexOfValue(3));
        }

        [Fact]
        public void ClearList()
        {
            LinkedList list = new LinkedList();
            list.AddAtEnd(1);
            list.AddAtEnd(2);

            list.Clear();

            Assert.Equal(String.Empty, list.ToString());
        }
    }
}
