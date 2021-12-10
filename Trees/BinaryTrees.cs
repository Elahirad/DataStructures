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

        public void TraverseLevelOrder()
        {
            for (var i = 0; i <= Height(); i++)
            {
                foreach (var j in GetNodesAtDistance(i)) System.Console.WriteLine(j);
            }
        }

        public int Height()
        {
            if (_root == null) return -1;
            return Height(_root);
        }
        private int Height(Node root)
        {
            if (root.LeftChild == null && root.RightChild == null) return 0;
            return Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
        }

        public int Min()
        {
            if (_root == null) return -1;
            return Min(_root);
        }
        private int Min(Node root)
        {
            if (root == null) return 0;
            if (root.LeftChild == null && root.RightChild == null) return root.Value;
            return Math.Min(root.Value, Math.Min(Min(root.LeftChild), Min(root.RightChild)));
        }

        public int Max()
        {
            return Max(_root);
        }
        private int Max(Node root)
        {
            if (root == null) return 0;
            if (root.LeftChild == null && root.RightChild == null) return root.Value;
            return Math.Max(root.Value, Math.Max(Max(root.LeftChild), Max(root.RightChild)));
        }

        public bool Equals(BinaryTree second)
        {
            if (second == null) throw new InvalidOperationException("Second tree is null");
            return Equals(_root, second._root);
        }

        private bool Equals(Node root, Node to_check_root)
        {
            if (root == null && to_check_root == null) return true;
            if (!(root != null && to_check_root != null)) return false;
            return root.Value == to_check_root.Value
                && Equals(root.LeftChild, to_check_root.LeftChild)
                && Equals(root.RightChild, to_check_root.RightChild);
        }
        // First Implementation
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(_root);
        }
        private bool IsBinarySearchTree(Node root)
        {
            if (root.LeftChild == null || root.RightChild == null) return true;
            var left = IsBinarySearchTree(root.LeftChild);
            var right = IsBinarySearchTree(root.RightChild);
            return (root.Value > root.LeftChild.Value && root.Value < root.RightChild.Value) && left && right;
        }

        // Second Implementation
        // public bool IsBinarySearchTree()
        // {
        //     return IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
        // }

        // private bool IsBinarySearchTree(Node root, int min, int max)
        // {
        //     if (root == null) return true;
        //     if (root.Value < min || root.Value > max) return false;
        //     return IsBinarySearchTree(root.LeftChild, min, root.Value - 1)
        //         && IsBinarySearchTree(root.RightChild, root.Value + 1, max);
        // }

        public void PrintNodesAtDistance(int distance)
        {
            PrintNodeAtDistance(_root, distance);
        }

        private void PrintNodeAtDistance(Node root, int distance)
        {
            if (root == null) return;
            if (distance == 0)
            {
                System.Console.WriteLine(root.Value);
                return;
            }
            PrintNodeAtDistance(root.LeftChild, distance - 1);
            PrintNodeAtDistance(root.RightChild, distance - 1);
        }

        public List<int> GetNodesAtDistance(int distance)
        {
            var arr = new List<int>();
            GetNodesAtDistance(_root, distance, arr);
            return arr;
        }

        private void GetNodesAtDistance(Node root, int distance, List<int> arr)
        {
            if (root == null) return;
            if (distance == 0) arr.Add(root.Value);
            GetNodesAtDistance(root.LeftChild, distance - 1, arr);
            GetNodesAtDistance(root.RightChild, distance - 1, arr);
        }

        public int Size()
        {
            return Size(_root);
        }

        private int Size(Node root)
        {
            if (root == null) return 0;
            if (root.LeftChild == null && root.RightChild == null) return 1;
            return Size(root.LeftChild) + Size(root.RightChild) + 1;
        }

        public int CountLeaves()
        {
            return GetNodesAtDistance(Height()).Count;
        }

        public bool Contains(int to_search)
        {
            return Contains(_root, to_search);
        }
        private bool Contains(Node root, int to_search)
        {
            if (root == null) return false;
            if (root.Value == to_search) return true;
            return Contains(root.LeftChild, to_search) || Contains(root.RightChild, to_search);
        }

        public bool AreSibling(int first, int second)
        {
            return AreSibling(_root, first, second);
        }
        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null || root.LeftChild == null || root.RightChild == null) return false;
            if ((root.LeftChild.Value == first && root.RightChild.Value == second)
                || (root.LeftChild.Value == second && root.RightChild.Value == first))
                return true;
            return AreSibling(root.LeftChild, first, second) || AreSibling(root.RightChild, first, second);
        }

        public List<int> GetAncestors(int child) {
            var arr = new List<int>();
            GetAncestors(_root, child, arr);
            return arr;
        }
        private bool GetAncestors(Node root, int child, List<int> arr)
        {
            if (root == null) return false;
            if (root.Value == child) return true;
            if (GetAncestors(root.LeftChild, child, arr))
            {
                arr.Add(root.Value);
                return true;
            }
            if (GetAncestors(root.RightChild, child, arr))
            {
                arr.Add(root.Value);
                return true;
            }
            return false;
        }
    }
}