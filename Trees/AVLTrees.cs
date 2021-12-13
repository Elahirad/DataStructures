namespace Trees
{
    public class AVLTree
    {
        private class AVLNode
        {
            public int Value { get; set; }
            public AVLNode LeftChild { get; set; }
            public AVLNode RightChild { get; set; }
        }

        private AVLNode _root;

        public void Insert(int item)
        {
            _root = Insert(_root, item);
        }

        private AVLNode Insert(AVLNode root, int item)
        {
            if (root == null) return new AVLNode() { Value = item };

            if (item > root.Value)
            {
                root.RightChild = Insert(root.RightChild, item);
            }
            if (item < root.Value)
            {
                root.LeftChild = Insert(root.LeftChild, item);
            }

            return root;
        }
    }
}