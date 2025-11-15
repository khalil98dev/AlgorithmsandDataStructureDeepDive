namespace BinaryTrees;

public class BTNode<T> where T : IComparable<T>
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