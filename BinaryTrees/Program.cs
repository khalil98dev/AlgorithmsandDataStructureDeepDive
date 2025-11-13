using BinaryTrees;


Console.WriteLine("Values want inserted: 5;2;4;6;7;8;9;10;20");

BinaryTree<string> mainTree = new BinaryTree<string>(null);


mainTree.Insert("50");
mainTree.Insert("40");
mainTree.Insert("45");
mainTree.Insert("60");
mainTree.Insert("55");
mainTree.Insert("52");




mainTree.Print();


mainTree.PreOrderTraversal();   

Console.WriteLine();

mainTree.PostOrderTraversal();

Console.WriteLine();

mainTree.InOrderTraversal();

Console.WriteLine();
