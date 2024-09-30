using Binary_Tree.Models;

var bt = new BinarySearchTree();

bt.Insert(5);
bt.Insert(3);
bt.Insert(2);
bt.Insert(4);
bt.Insert(5);
bt.Insert(6);

Console.WriteLine("Pre Order Traversal: ");
foreach (var item in bt.PreOrderTraversal())
{
    Console.Write(item + " ");
}

Console.WriteLine('\n');

Console.WriteLine("In Order Traversal: ");
foreach (var item in bt.InOrderTraversal())
{
    Console.Write(item + " ");
}

Console.WriteLine('\n');

Console.WriteLine("Post Order Traversal: ");
foreach (var item in bt.PostOrderTraversal())
{
    Console.Write(item + " ");
}

Console.WriteLine('\n');

//Console.WriteLine(bt.Contains(5));
//Console.WriteLine(bt.Contains(3));
//Console.WriteLine(bt.Contains(2));
//Console.WriteLine(bt.Contains(4));
//Console.WriteLine(bt.Contains(5));
//Console.WriteLine(bt.Contains(6));
//Console.WriteLine(bt.Contains(10));
//Console.WriteLine(bt.Contains(12));
//Console.WriteLine(bt.Contains(0));