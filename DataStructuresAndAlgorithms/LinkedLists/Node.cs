namespace DataStructuresAndAlgorithms.LinkedLists
{
    public class Node
    {
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            Next = null;
            Prev = null;
            Value = value;
        }
    }
}
