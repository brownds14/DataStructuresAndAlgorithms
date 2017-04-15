using Xunit;
using DataStructuresAndAlgorithms.BinarySearchTrees;

namespace DataStructuresAndAlgorithms.Tests
{
    public class BinarySearchTreesTests
    {
        private int[] _nodes = { 22, 10, 9, 12, 14, 13, 23, 24 };
        [Fact]
        public void AddingNode()
        {
            var tree = new BinarySearchTree();

            tree.Add(22);

            Assert.Equal("22", tree.ToString());
        }

        [Fact]
        public void AddingMultipleNodes()
        {
            var tree = new BinarySearchTree();

            tree.Add(22);
            tree.Add(10);
            tree.Add(5);

            Assert.Equal("5,10,22", tree.ToString());
        }

        [Fact]
        public void PrintEmptyTree()
        {
            var tree = new BinarySearchTree();

            Assert.Equal(string.Empty, tree.ToString());
        }

        [Fact]
        public void PrintTreeWithOneItem()
        {
            var tree = new BinarySearchTree();
            tree.Add(22);

            Assert.Equal("22", tree.ToString());
        }

        [Fact]
        public void PrintTree()
        {
            var tree = new BinarySearchTree();
            tree.Add(22);
            tree.Add(10);
            tree.Add(30);
            tree.Add(5);
            tree.Add(23);
            string expected = "5,10,22,23,30";

            Assert.Equal(expected, tree.ToString());
        }

        [Fact]
        public void RemoveWhenTreeIsEmpty()
        {
            var tree = new BinarySearchTree();

            tree.Remove(0);

            Assert.Equal(string.Empty, tree.ToString());
        }

        [Fact]
        public void RemoveRootFromSingleNodeTree()
        {
            var tree = new BinarySearchTree();
            tree.Add(1);

            tree.Remove(1);

            Assert.Equal(string.Empty, tree.ToString());
        }

        [Fact]
        public void RemoveLeafNode()
        {
            var tree = new BinarySearchTree();
            foreach (var node in _nodes)
            {
                tree.Add(node);
            }

            tree.Remove(9);

            Assert.Equal("10,12,13,14,22,23,24", tree.ToString());
        }

        [Fact]
        public void RemoveNodeWithOneChild()
        {
            var tree = new BinarySearchTree();
            foreach (var node in _nodes)
            {
                tree.Add(node);
            }

            tree.Remove(23);

            Assert.Equal("9,10,12,13,14,22,24", tree.ToString());
        }

        [Fact]
        public void RemoveNodeWithTwoChildren()
        {
            var tree = new BinarySearchTree();
            foreach (var node in _nodes)
            {
                tree.Add(node);
            }

            tree.Remove(10);

            Assert.Equal("9,12,13,14,22,23,24", tree.ToString());
        }

        [Fact]
        public void NodeExistsOnEmptyTree()
        {
            var tree = new BinarySearchTree();

            Assert.False(tree.NodeExists(0));
        }

        [Fact]
        public void NodeExists()
        {
            var tree = new BinarySearchTree();
            foreach (var node in _nodes)
            {
                tree.Add(node);
            }

            Assert.True(tree.NodeExists(13));
        }

        [Fact]
        public void NodeDoesNotExist()
        {
            var tree = new BinarySearchTree();
            foreach (var node in _nodes)
            {
                tree.Add(node);
            }

            Assert.False(tree.NodeExists(25));
        }
    }
}
