namespace Binary_Tree.Models
{
    public class BinarySearchTree : BinaryTree
    {
        public void Insert(int data, bool recursively = true)
        {
            if (Root is null)
            {
                Root = new Node(data);
                return;
            }

            if (recursively)
                InsertNodeRecursively(Root, data);
            else
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
    }
}
