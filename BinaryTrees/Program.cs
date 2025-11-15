using BinaryTrees;


Console.WriteLine("Values want inserted: 5;3;8;1;4;6;9");

//BinaryTree<int> mainTree = new BinaryTree<int>(null);
BinarySearchTree<int> mainTree = new BinarySearchTree<int>();


mainTree.Insert(5);
mainTree.Insert(3);
mainTree.Insert(8);
mainTree.Insert(1);
mainTree.Insert(4);
mainTree.Insert(6);
mainTree.Insert(9);
mainTree.Insert(10);



mainTree.Print();


Console.WriteLine("PreOrder Root -> Left subtree - RightSub tree");
mainTree.PreOrderTraversal();   



Console.WriteLine();




Console.WriteLine("PostOrder: all Left subtree- All right sub tree root");
mainTree.PostOrderTraversal();


Console.WriteLine();


Console.WriteLine("In Order Traversal: left - root - right");
mainTree.InOrderTraversal();

Console.WriteLine();

Console.WriteLine("Level Order Traversal: Top-> Down Left-Right");
mainTree.LevelOrderTraversal();

Console.WriteLine();


Console.WriteLine($"Count Nodes in the Tree using the PreOrderTraversal: {mainTree.Count}");

Console.WriteLine($"Count leafs in the Tree using the PostOrderTraversal: {mainTree.LeafsCount}");

Console.WriteLine($"Count intyernaml ndoes in the Tree : {mainTree.InternalCount}");

Console.WriteLine($"Max Height of Tree : {mainTree.MaxHeight}");

Console.WriteLine($"Max Depth of Tree recursive: {mainTree.MaxDepthRecursive()}");


int number =6; 

Console.WriteLine($"Seraching for the number {number} :");

BTNode<int>? result = mainTree.Search(number);
if (result == null)
{
    Console.WriteLine("Not Found");
}else if(result.leftNode == null && result.rigtNode == null )
    Console.WriteLine($"Founded \nleaf node value");
else
    Console.WriteLine($"Founded \nLeft node value: {result.leftNode.Value} \nRight node value : {result.rigtNode.Value}");






