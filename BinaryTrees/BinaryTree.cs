using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTrees;

public class BinaryTree<T> where T : IComparable<T>
{
    protected BTNode<T>? root { get; set; }

    public BTNode<T> Root { get => root; }

    public int Count => CountAllNodesPostOrder();

    public int LeafsCount => CountLeafNodes();

    public int InternalCount => InternalNodes();

    public int MaxHeight => MaxHeightCalc();

    public bool IsReadOnly => false;

    public BinaryTree(BTNode<T>? root)
    {
        this.root = root;
    }
    public BinaryTree()
    {
        this.root = null;
    }

    Queue<BTNode<T>> Nodes = new Queue<BTNode<T>>();


    public virtual void Insert(T value)
    {

        //root right left  

        if (root == null)
        {
            root = new BTNode<T>(value);
            return;
        }


        Nodes.Enqueue(root);

        while (Nodes.Count > 0)
        {
            var CurrentNode = Nodes.Dequeue();

            if (CurrentNode.leftNode == null)
            {
                CurrentNode.leftNode = new(value);
                return;
            }
            else
            {
                Nodes.Enqueue(CurrentNode.leftNode);
            }

            if (CurrentNode.rigtNode == null)
            {
                CurrentNode.rigtNode = new(value);
                return;
            }
            else
            {
                Nodes.Enqueue(CurrentNode.rigtNode);
            }
        }

    }



    public void Print()
    {
        PrintTree(Root, 0);
    }

    void PrintTree(BTNode<T> Node, int space)
    {
        if (Node == null)
            return;

        PrintTree(Node.rigtNode, space+10);
        Console.WriteLine($"\n{MakeSpace(space)} {Node.Value}");
        PrintTree(Node.leftNode, space+10);
    }

    string MakeSpace(int spaces)
    {
        string value = "";

        for (int i = 0; i < spaces; i++)
        {
            value += " ";
        }

        return value;
    }

    void InOrderTraversal(BTNode<T> Node)
    {
        //left-root-right

        if (Node == null) return;

        InOrderTraversal(Node.leftNode);
        Console.Write(Node.Value + " ");
        InOrderTraversal(Node.rigtNode);

    }

    void LevelOrderTraversal(BTNode<T>? Node)
    {
        //Path => level by levl Top to Down left to Right

        //root right left  

        if (Node == null)
            return;


        Queue<BTNode<T>> Nodes = new Queue<BTNode<T>>();

        Nodes.Enqueue(root);

        while (Nodes.Count > 0)
        {
            var CurrentNode = Nodes.Dequeue();

            Console.Write(CurrentNode.Value + " ");

            if (CurrentNode.leftNode != null)
            {
                Nodes.Enqueue(CurrentNode.leftNode);
            }

            if (CurrentNode.rigtNode != null)
            {
                Nodes.Enqueue(CurrentNode.rigtNode);
            }
        }
    }

    void PreOrderTraversal(BTNode<T> Node)
    {
        /*
            Pre-Order traversal is a method to visit all nodes in the tree in order way:
               Root-> Left Subtree -> Right Subtree
         */

        if(Node == null) return;

        Console.Write(Node.Value + " ");
        PreOrderTraversal(Node.leftNode);    
        PreOrderTraversal(Node.rigtNode);

    }

    void PostOrderTraversal(BTNode<T> Node)
    {
        /*
            Post-Order traversal is a method to visit all nodes in the tree in order way:
               Left sub tree ->  Right Subtree -> Root 
         */

        if (Node == null) return;

        PreOrderTraversal(Node.leftNode);
        PreOrderTraversal(Node.rigtNode);
        Console.Write(Node.Value + " ");

    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(Root);
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversal(Root);
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
    }

    public void LevelOrderTraversal()
    {
        LevelOrderTraversal(root);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var node in Nodes)
        {
            yield return node.Value;
        }
            
    }

  
    public void Add(T item)
    {
        Insert(item);
    }

    public void Clear()
    {
        Nodes.Clear();
    }

    public bool Contains(T item)
    {
        foreach(var node in Nodes)
        {
            if(Nodes.Contains(node))
                return true;
        }

        return false;
    }


    int CountAllNodes()
    {
        return PreOrderTraversalCounter(root,0);
    }


    int CountAllNodesPostOrder()
    {
        return PostOrderTraversalCounter(root, 0);
    }

    int  PreOrderTraversalCounter(BTNode<T> Node,int Counter)
    {
     
        
        if (Node == null)  return Counter;
        Counter++;
        Counter = PreOrderTraversalCounter(Node.leftNode, Counter); // left sub tree items 
        Counter = PreOrderTraversalCounter(Node.rigtNode, Counter);// right sub tree items 


        return Counter;

    }

    int CountLeafNodesPostOrderTraversal() => PreOrderTraversalCounter(root, 0);

    int CountLeafNodesPostOrderTraversal(BTNode<T> Node, int Counter)
    {
        if (Node == null) return Counter;
        
       

        Counter = PreOrderTraversalCounter(Node.leftNode, Counter++); // left sub tree items 
        Counter = PreOrderTraversalCounter(Node.rigtNode, Counter++);// right sub tree items 

        return Counter;
    }




    int PostOrderTraversalCounter(BTNode<T> node, int counter)
    {
        if (node == null)
            return counter;

        // Traverse left subtree
        counter = PostOrderTraversalCounter(node.leftNode, counter);

        // Traverse right subtree
        counter = PostOrderTraversalCounter(node.rigtNode, counter);

        // Visit root (increment AFTER children)
        counter++;

        return counter;
    }


    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }



    int CountleafsLevelOrderTraversal(BTNode<T>? Node)
    {
        //Path => level by levl Top to Down left to Right

        //root right left  
        int Counter = 0;
        if (Node == null)
            return Counter;


        Queue<BTNode<T>> Nodes = new Queue<BTNode<T>>();

        Nodes.Enqueue(root);
       

        while (Nodes.Count > 0)
        {
            var CurrentNode = Nodes.Dequeue();

            Console.Write(CurrentNode.Value + " ");
            if (CurrentNode.leftNode == null && CurrentNode.rigtNode == null)
                Counter++;
            if (CurrentNode.leftNode != null)
            {
                Nodes.Enqueue(CurrentNode.leftNode);
            }

            if (CurrentNode.rigtNode != null)
            {
                Nodes.Enqueue(CurrentNode.rigtNode);
            }
        }

        return Counter;
    }

    int CountleafsLevelOrderTraversal() => CountleafsLevelOrderTraversal(root);



    int CountLeafNodes(BTNode<T> node)
    {
        if (node == null)
            return 0;

        // A node with no children is a leaf
        if (node.leftNode == null && node.rigtNode == null)
            return 1;

        // Recursively count in left and right subtrees
        return CountLeafNodes(node.leftNode) + CountLeafNodes(node.rigtNode);
    }

    int CountLeafNodes()=> CountLeafNodes(root);

    int InternalNodes() => Count- CountLeafNodes(root)-1;

    int MaxHeightCalc()
    {
        
        int Level = 0;
        int LevelCapacity = 0;

        while (LevelCapacity<Count)
        {
            Level++;
            LevelCapacity = (int)Math.Pow(2, Level)-1;
        }

        return Level;
    }


    int MaxHeightCalcRecursive(BTNode<T> Node)
    {

        if (Node == null)
        {
            return 0;
        }

        int maxLevelLeft = MaxHeightCalcRecursive(Node.leftNode);
        int maxLevelRight = MaxHeightCalcRecursive(Node.rigtNode);


        return 1 + Math.Max(maxLevelLeft, maxLevelRight);   


    }

    public int MaxDepthRecursive()
    {
        return MaxHeightCalcRecursive(root);
    }  
}
