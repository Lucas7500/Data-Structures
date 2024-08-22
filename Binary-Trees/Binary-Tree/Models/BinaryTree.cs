namespace Binary_Tree.Models
{
    public abstract class BinaryTree
    {
        public Node? Root { get; protected set; }
        public int Height { get => GetMaximumDepth(Root); }

        //protected IEnumerable<string> PreOrderTraversal()
        //{
        //    if (Root is null)
        //    {
        //        return [];
        //    }


        //    return GetPreOrderTraversal(Root);
        //}

        //private List<string> GetPreOrderTraversal(Node root)
        //{
        //}

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
