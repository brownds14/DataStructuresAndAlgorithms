namespace DataStructuresAndAlgorithms.BinarySearchTrees
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public static bool operator >=(Node n1, Node n2)
        {
            return n1.Value >= n2.Value;
        }

        public static bool operator <=(Node n1, Node n2)
        {
            return n1.Value <= n2.Value;
        }
    }
}
