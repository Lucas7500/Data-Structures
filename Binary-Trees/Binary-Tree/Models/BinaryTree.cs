namespace Binary_Tree.Models
{
    public abstract class BinaryTree
    {
        public Node? Root { get; protected set; }
        public int Height { get => GetMaximumDepth(Root); }

        public IEnumerable<int> PreOrderTraversal()
        {
            return GetPreOrderTraversal(Root);
        }
        
        public IEnumerable<int> InOrderTraversal()
        {
            return GetInOrderTraversal(Root);
        }

        public IEnumerable<int> PostOrderTraversal()
        {
            return GetPostOrderTraversal(Root);
        }

        //public bool Contains(int data)
        //{
        //    if (Root is null)
        //        return false;

        //    if (Root.Data == data)
        //    {
        //        return true;
        //    }
        //    else if (Root.Data > data && Root.Left is not null)
        //    {
        //        return Contains(Root.Left.Data);
        //    }
        //    else if (Root.Data < data && Root.Right is not null)
        //    {
        //        return Contains(Root.Right.Data);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private static List<int> GetPreOrderTraversal(Node? root)
        {
            var traversal = new List<int>();

            if (root is not null)
            {
                traversal.Add(root.Data);

                if (root.Left is not null)
                {
                    traversal.AddRange(GetPreOrderTraversal(root.Left));
                }

                if (root.Right is not null)
                {
                    traversal.AddRange(GetPreOrderTraversal(root.Right));
                }
            }

            return traversal;
        }

        private static List<int> GetInOrderTraversal(Node? root)
        {
            var traversal = new List<int>();

            if (root is not null)
            {
                if (root.Left is not null)
                {
                    traversal.AddRange(GetInOrderTraversal(root.Left));
                }

                traversal.Add(root.Data);

                if (root.Right is not null)
                {
                    traversal.AddRange(GetInOrderTraversal(root.Right));
                }
            }

            return traversal;
        }

        private static List<int> GetPostOrderTraversal(Node? root)
        {
            var traversal = new List<int>();

            if (root is not null)
            {
                if (root.Left is not null)
                {
                    traversal.AddRange(GetPostOrderTraversal(root.Left));
                }

                if (root.Right is not null)
                {
                    traversal.AddRange(GetPostOrderTraversal(root.Right));
                }

                traversal.Add(root.Data);
            }

            return traversal;
        }

        private static int GetMaximumDepth(Node? root)
        {
            if (root is null)
            {
                return 0;
            }

            var leftMaxDepth = GetMaximumDepth(root.Left);
            var rightMaxDepth = GetMaximumDepth(root.Right);

            var maxDepth = leftMaxDepth > rightMaxDepth ? leftMaxDepth : rightMaxDepth;

            return ++maxDepth;
        }
    }
}
