
using System.Xml;

public class Avlnode
{
    public int Value { get; set; } 

    public Avlnode Left { get; set; }    
    public Avlnode Right { get; set; }
    
    public int Hight { get; set; }

    public Avlnode(int value)
    {
        Value = value;
        Hight = 0; 
    }

}

public class AvlTree
{
    public Avlnode Root { get; set; }


    private Avlnode Insert(Avlnode node,int value)
    {
        if (node == null) return new Avlnode(value);


        if(value <node.Value)
            node.Left= Insert(node.Left, value);
        else if (value >node.Value)
            node.Right= Insert(node.Right,value);
        else 
            return node;

        UpdateHeight(node);

        return Balance(node);
    }

    private Avlnode Balance(Avlnode node)
    {
        int balanceFactor = GetBalanceFactor(node);

        // LL - Right Rotation Case : Parent BF=-2 , Child BF for right child = -1 or 0
        // Right Heavy 
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
            return LeftRotate(node);

        // RR Case: Parent BF=+2 , Child BF for left child = +1 or 0
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
            return RightRotate(node);


        //Double Rotation // 

        if(balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);

        }

        //RL Rotaion 

        if (balanceFactor < -1 && GetBalanceFactor(node.Left) > 0)
        {
            node.Right = RightRotate(node.Left);
            return LeftRotate(node);

        }

        return node;

    }

    private Avlnode RightRotate(Avlnode OriginalRoot)
    {
        //1- Make the Right SubTree are the new Root 

        Avlnode newRoot = OriginalRoot.Left;

        Avlnode OriginalRightChild = newRoot.Right; // My be null

        //2- The Original Root Been the left chilf of the new Root 
        newRoot.Left = OriginalRoot;

        //3- if the new Root Already has a left child We Put the left node on the newLeftNode.Left 

        //because the Original root been the right child of the new Node (the Current root)
        OriginalRoot.Left = OriginalRightChild;
            

        UpdateHeight(OriginalRoot);
        UpdateHeight(newRoot);


        return newRoot;

    }

    private Avlnode LeftRotate(Avlnode OriginalRoot)
    {
        //1- Make the Right SubTree are the new Root 

        Avlnode newRoot = OriginalRoot.Right;

        Avlnode OriginalLeftChild = newRoot.Left; // My be null

        //2- The Original Root Been the left chilf of the new Root 
        newRoot.Left = OriginalRoot;

        //3- if the new Root Already has a left child We Put the left node on the newLeftNode.Left 

        //because the Original root been the right child of the new Node (the Current root)
        OriginalRoot.Right = OriginalLeftChild;


        UpdateHeight(OriginalRoot);  
        UpdateHeight(newRoot);
        

        return newRoot; 
    }

    private int GetBalanceFactor(Avlnode node)
    {
        return (node != null) ? Height(node.Left) - Height(node.Right) : 0;
    }

    private void UpdateHeight(Avlnode node)
    {
        node.Hight =1 + Math.Max(Height(node.Left), Height(node.Right));   
    }

    public int BalanceFactory(Avlnode node)
    {
        return Height(node.Left)-Height(node.Right);    
    }

    public int Height(Avlnode node)
    {
        return (node != null)? node.Hight: 0; 
    }

    public Avlnode UpdateBalance(Avlnode node)
    {
        return node;
    }


    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    private void PrintTree(Avlnode node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }
            Console.WriteLine(node.Value);
            PrintTree(node.Left, indent, false);
            PrintTree(node.Right, indent, true);
        }
    }

    public void Insert(int value)
    {
        Root=Insert(Root, value);
    }

}




class Program
{
    static void Main(string[] args)
    {
        AvlTree tree = new AvlTree();

        //RR
        // int[] values = { 10, 20, 30 };

        //LL
        //  int[] values = { 30, 20, 10 };

        //LR
        // int[] values = { 30, 10, 20 };

        //RL
        //int[] values = { 10, 30, 20 };

        // Inserting values
        int[] values = { 10, 20, 30, 40, 50, 25 };
        foreach (var value in values)
        {
            Console.WriteLine($"Inserting {value} into the AVL tree.");
            tree.Insert(value);
            tree.PrintTree();
            Console.WriteLine("\n-------------------------------------------------\n");
        }
        Console.ReadKey();

    }
}