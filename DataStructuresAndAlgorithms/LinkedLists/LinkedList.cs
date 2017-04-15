using System;
using System.Text;

namespace DataStructuresAndAlgorithms.LinkedLists
{
    public class LinkedList
    {
        private Node _head = null;

        private bool IsHead(Node n)
        {
            return Object.ReferenceEquals(_head, n);
        }

        private bool NodesEqual(Node n1, Node n2)
        {
            return Object.ReferenceEquals(n1, n2);
        }

        public void AddAtEnd(int value)
        {
            Node n = new Node(value);
            InsertNode(n, _head?.Prev);
        }

        public void AddAtBeginning(int value)
        {
            Node n = new Node(value);
            InsertNode(n, _head?.Prev);
            _head = n;
        }

        private void InsertNode(Node n, Node before)
        {
            if (_head == null) //List is empty
                _head = n;
            else if (_head.Next == null) //List contains one node
            {
                //Update head node
                _head.Next = n;
                _head.Prev = n;

                //Update inserted node
                n.Next = _head;
                n.Prev = _head;
            }
            else
            {
                Node after = before.Next;

                //Update node before inserted node
                before.Next = n;

                //Update the inserted node
                n.Prev = before;
                n.Next = after;

                //Update the node after inserted node
                after.Prev = n;
            }
        }

        public void RemoveFirstNodeWithValue(int value)
        {
            if (_head != null)
            {
                bool removed = false;

                if (_head.Value == value)
                {
                    RemoveNode(_head);
                    removed = true;
                }

                Node curr = _head?.Next;
                while (curr != null && !removed && !IsHead(curr))
                {
                    if (curr.Value == value)
                    {
                        RemoveNode(curr);
                        removed = true;
                    }
                    curr = curr.Next;
                }
            }
        }

        public void RemoveAllNodesWithValue(int value)
        {
            if (_head != null)
            {
                Node stopPoint = null;
                Node curr = _head;

                while (curr != null && !NodesEqual(curr, stopPoint))
                {
                    if (curr.Value == value)
                    {
                        Node tmp = curr.Next;
                        RemoveNode(curr);
                        curr = tmp;
                    }
                    else
                    {
                        if (stopPoint == null)
                            stopPoint = curr;
                        curr = curr.Next;
                    }
                }
            }
        }

        private void RemoveNode(Node n)
        {
            if (n.Next == null) //One node in list
                _head = null;
            else if (NodesEqual(n.Next.Next, n)) //Two nodes in list
            {
                _head = n.Next;
                _head.Next = null;
                _head.Prev = null;
            }
            else
            {
                //Update the head if node is the head
                if (IsHead(n))
                    _head = n.Next;

                //Update node before deleted node
                n.Prev.Next = n.Next;

                //Update node after delete node
                n.Next.Prev = n.Prev;
            }
        }

        public void Clear()
        {
            _head = null;
        }

        public bool NodeExists(int value)
        {
            bool exists = false;

            if (_head != null)
            {
                if (_head.Value == value)
                    exists = true;

                Node curr = _head.Next;
                while (curr != null && !NodesEqual(curr, _head) && !exists)
                {
                    if (curr.Value == value)
                        exists = true;

                    curr = curr.Next;
                }
            }
            return exists;
        }

        public int CountNodesWithValue(int value)
        {
            int count = 0;

            if (_head != null)
            {
                if (_head.Value == value)
                    count += 1;

                Node curr = _head.Next;
                while (curr != null && !NodesEqual(curr, _head))
                {
                    if (curr.Value == value)
                        count += 1;

                    curr = curr.Next;
                }
            }

            return count;
        }

        public int FirstIndexOfValue(int value)
        {
            int index = -1;

            if (_head != null)
            {
                if (_head.Value == value)
                    index = 0;

                int pos = 1;
                Node curr = _head.Next;
                while (curr != null && !NodesEqual(curr, _head) && index == -1)
                {
                    if (curr.Value == value)
                        index = pos;

                    curr = curr.Next;
                    pos += 1;
                }
            }

            return index;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (_head != null)
            {
                sb.Append(_head.Value);
                Node curr = _head.Next;

                while (curr != null && !NodesEqual(curr, _head))
                {
                    sb.Append(",").Append(curr.Value);
                    curr = curr.Next;
                }
            }

            return sb.ToString();
        }
    }
}
