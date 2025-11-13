using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTrees;

public class BinaryTree<T>
{
    BTNode<T>? root { get; set; }

    public BTNode<T> Root { get => root; }

    public BinaryTree(BTNode<T>? root)
    {
        this.root = root;
    }



    public void Insert(T value)
    {

        //root right left  

        if (root == null)
        {
            root = new BTNode<T>(value);
            return;
        }

        Queue<BTNode<T>> Nodes = new Queue<BTNode<T>>();

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

    private void InOrderTraversal(BTNode<T> Node)
    {
        //left-root-right

        if (Node == null) return;

        InOrderTraversal(Node.leftNode);
        Console.Write(Node.Value + " ");
        InOrderTraversal(Node.rigtNode);
       
    }
}
public class BTNode<T>
{
    public T ?Value { get; set; }
    public BTNode<T> ?leftNode { get; set; }  
    public BTNode<T>? rigtNode { get; set; }  

    public BTNode(T? value)
    {
        Value = value;
        this.leftNode = null;
        this.rigtNode = null;
    }

    public int CompareTo(T? other)
    {
        if (other == null)
            return 1;

        if (Value == null && other == null)
            return 0;

        if (Value == null)
            return -1;

        if (other == null)
            return 1;

        // Compare based on the Value property
        return this.CompareTo(other);
    }

    }