using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees;

public class BinarySearchTree<T> : BinaryTree<T> where T:  IComparable<T>
{

    public override void Insert(T value)
    {
        root = Insert(root, value);
    }

    private BTNode<T> Insert(BTNode<T>? Node, T value)
    {
        if (Node == null)
            return new(value);

        if (value.CompareTo(Node.Value) <0)
        {
            Node.leftNode =  Insert(Node.leftNode, value);
        }
        else if(value.CompareTo(Node.Value) > 0)
        {
            Node.rigtNode =  Insert(Node.rigtNode, value);
        }

        return Node;    

    }

    private BTNode<T>? Search(BTNode<T>? Node,T Value)
    {
         
        if(Node == null || Value.Equals(Node.Value) ) return Node;

        else if(Value.CompareTo(Node.Value)>0)
        {
            return  Search(Node.rigtNode, Value);   
        }else if(Value.CompareTo(Node.Value)<0)
        {
            return Search(Node.leftNode, Value);
        }

        return Node; 
    }

    public BTNode<T>? Search(T Value)
    {
        return root = Search(root,Value);
    }

}
