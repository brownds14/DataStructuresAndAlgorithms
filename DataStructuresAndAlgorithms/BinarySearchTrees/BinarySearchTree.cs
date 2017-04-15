using System;

namespace DataStructuresAndAlgorithms.BinarySearchTrees
{
    public class BinarySearchTree
    {
        private Node _root = null;

        private bool NodesEqual(Node n1, Node n2)
        {
            return Object.ReferenceEquals(n1, n2);
        }

        public void Add(int value)
        {
            Node n = new Node(value);

            if (_root == null)
                _root = n;
            else
            {
                Node curr = _root;
                Node tmp;

                while (curr != null)
                {
                    if (n >= curr)
                    {
                        tmp = curr.Right;
                        if (tmp == null)
                        {
                            curr.Right = n;
                            curr = null;
                        }
                        else
                            curr = tmp;
                    }
                    else
                    {
                        tmp = curr.Left;
                        if (tmp == null)
                        {
                            curr.Left = n;
                            curr = null;
                        }
                        else
                            curr = tmp;
                    }
                }
            }
        }

        public void Remove(int value)
        {
            _root = RemoveRecursive(_root, value);
        }

        private Node RemoveRecursive(Node n, int value)
        {
            if (n == null) return n;

            if (n.Value > value)
                n.Left = RemoveRecursive(n.Left, value);
            else if (n.Value < value)
                n.Right = RemoveRecursive(n.Right, value);
            else
            {
                if (n.Left == null && n.Right == null)
                    return null;
                else if (n.Left == null)
                    return n.Right;
                else if (n.Right == null)
                    return n.Left;
                else
                {
                    Node minValue = n.Right;

                    while (minValue.Left != null)
                        minValue = minValue.Left;

                    n.Value = minValue.Value;

                    n.Right = RemoveRecursive(n.Right, minValue.Value);
                }
            }

            return n;
        }

        public bool NodeExists(int value)
        {
            return ExistsRecursive(_root, value);
        }

        private bool ExistsRecursive(Node n, int value)
        {
            if (n == null) return false;

            if (n.Value > value)
                return ExistsRecursive(n.Left, value);
            else if (n.Value < value)
                return ExistsRecursive(n.Right, value);
            else
                return true;
        }

        public override string ToString()
        {
            return PrintTree(_root);
        }

        private string PrintTree(Node n)
        {
            string treeString = String.Empty;

            if (n != null)
            {
                
                if (n.Left != null)
                    treeString = String.Concat(treeString, PrintTree(n.Left));
                treeString = String.Concat(treeString, n.Value, ",");
                if (n.Right != null)
                    treeString = String.Concat(treeString, PrintTree(n.Right));

                //Trim last comma
                if (Object.ReferenceEquals(n, _root))
                    treeString = treeString.Substring(0, treeString.Length - 1);
            }

            return treeString;
        }
    }
}
