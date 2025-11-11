using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        while(Nodes.Count>0)
        {
            var CurrentNode = Nodes.Dequeue();  
            
            if(CurrentNode.leftNode ==null )
            {
                CurrentNode.leftNode = new (value);
                return;
            }else
            {
                Nodes.Enqueue(CurrentNode.leftNode);
            }

            if (CurrentNode.rigtNode == null)
            {
                CurrentNode.rigtNode = new(value);
                return;
            }else
            {
                Nodes.Enqueue(CurrentNode.rigtNode);
            }

        }

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

}