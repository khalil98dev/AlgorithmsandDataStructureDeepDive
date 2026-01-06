using Algo.RedBalcTree;

class Program
{
    static void Main(string[] args)
    {
        RedBlackTree rbTree = new RedBlackTree();


        // Test values to be inserted into the tree
        int[] values = { 10, 20, 30, 15, 25, 35, 5, 19 };
        foreach (var value in values)
        {
            Console.WriteLine($"Inserting {value} to the tree\n");
            rbTree.Insert(value);
            rbTree.Print();
            Console.WriteLine("\n--------------------------------\n");
        }
        Console.ReadKey();
    }
}