namespace Trees
{
    public class AVLTree
    {
        private class AVLNode
        {
            public int Value { get; set; }
            public AVLNode LeftChild { get; set; }
            public AVLNode RightChild { get; set; }

            public int Height { get; set; }
        }

        private AVLNode _root;

        public void Insert(int item)
        {
            _root = Insert(_root, item);
        }

        private AVLNode Insert(AVLNode root, int item)
        {
            if (root == null) return new AVLNode() { Value = item, Height = 0 };

            if (item > root.Value)
            {
                root.RightChild = Insert(root.RightChild, item);
            }
            if (item < root.Value)
            {
                root.LeftChild = Insert(root.LeftChild, item);
            }
            root.Height = HeightCalculator(root);
            return Balance(root);
        }


        private AVLNode RightRotate(AVLNode root)
        {
            var newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;
            root.Height = HeightCalculator(root);
            newRoot.Height = HeightCalculator(newRoot);
            return newRoot;
        }

        private AVLNode LeftRotate(AVLNode root)
        {
            var newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;
            root.Height = HeightCalculator(root);
            newRoot.Height = HeightCalculator(newRoot);
            return newRoot;
        }
        private AVLNode Balance(AVLNode root)
        {
            var bf = BalanceFactor(root);
            if (bf > 1)
            {
                if (BalanceFactor(root.LeftChild) < 0) root.LeftChild = LeftRotate(root.LeftChild);
                root = RightRotate(root);
            }
            else if (bf < -1)
            {
                if (BalanceFactor(root.RightChild) > 0) root.RightChild = RightRotate(root.RightChild);
                root = LeftRotate(root);
            }
            return root;
        }
        private int BalanceFactor(AVLNode root)
        {
            var leftHeight = root.LeftChild == null ? -1 : root.LeftChild.Height;
            var rightHeight = root.RightChild == null ? -1 : root.RightChild.Height;
            return leftHeight - rightHeight;
        }

        private int HeightCalculator(AVLNode node)
        {
            var leftHeight = node.LeftChild == null ? -1 : node.LeftChild.Height;
            var rightHeight = node.RightChild == null ? -1 : node.RightChild.Height;
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}