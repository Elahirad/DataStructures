namespace Trees
{
    public class BinaryTree
    {
        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
        }

        private Node _root;

        public void Add(int item)
        {
            if (_root == null)
            {
                _root = new Node() { Value = item };
                return;
            }
            var buffer = _root;
            while (true)
            {
                if (item > buffer.Value)
                {
                    if (buffer.RightChild == null)
                    {
                        buffer.RightChild = new Node() { Value = item };
                        break;
                    }
                    else buffer = buffer.RightChild;

                }
                else
                {
                    if (buffer.LeftChild == null)
                    {
                        buffer.LeftChild = new Node() { Value = item };
                        break;
                    }
                    else buffer = buffer.LeftChild;
                }
            }
        }
        public bool Find(int value)
        {
            var buffer = _root;
            while (buffer != null)
            {
                if (buffer.Value == value) return true;
                if (value > buffer.Value) buffer = buffer.RightChild;
                else buffer = buffer.LeftChild;
            }
            return false;

        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null) return;
            System.Console.WriteLine(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }
        private void TraverseInOrder(Node root)
        {
            if (root == null) return;
            TraverseInOrder(root.LeftChild);
            System.Console.WriteLine(root.Value);
            TraverseInOrder(root.RightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null) return;
            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            System.Console.WriteLine(root.Value);
        }
    }
}