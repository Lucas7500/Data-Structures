namespace Binary_Tree.Models
{
    public class BinaryTree
    {
        public Node? Root { get; private set; }
        public int Height { get => GetMaximumDepth(Root); }

        public void InsertRecursively(int data)
        {
            if (Root is null)
            {
                Root = new Node(data);
                return;
            }

            InsertNodeRecursively(Root, data);
        }

        public void InsertIteratively(int data)
        {
            if (Root is null)
            {
                Root = new Node(data);
                return;
            }

            InsertNodeIteratively(Root, data);
        }

        private static void InsertNodeRecursively(Node root, int data)
        {
            if (data < root.Data)
            {
                if (root.Left is null)
                {
                    root.Left = new Node(data);
                }
                else
                {
                    InsertNodeRecursively(root.Left, data);
                }
            }
            else
            {
                if (root.Right is null)
                {
                    root.Right = new Node(data);
                }
                else
                {
                    InsertNodeRecursively(root.Right, data);
                }
            }
        }

        private static void InsertNodeIteratively(Node root, int data)
        {
            while (true)
            {
                if (data < root.Data)
                {
                    if (root.Left is null)
                    {
                        root.Left = new Node(data);
                        return;
                    }
                    else
                    {
                        root = root.Left;
                    }
                }
                else
                {
                    if (root.Right is null)
                    {
                        root.Right = new Node(data);
                        return;
                    }
                    else
                    {
                        root = root.Right;
                    }
                }
            }
        }

        private static int GetMaximumDepth(Node? root)
        {
            if (root is null)
            {
                return 0;
            }
            else
            {
                var leftMaxDepth = GetMaximumDepth(root.Left);
                var rightMaxDepth = GetMaximumDepth(root.Right);

                var maxDepth = leftMaxDepth > rightMaxDepth ? leftMaxDepth : rightMaxDepth;

                return ++maxDepth;
            }
        }
    }
}
