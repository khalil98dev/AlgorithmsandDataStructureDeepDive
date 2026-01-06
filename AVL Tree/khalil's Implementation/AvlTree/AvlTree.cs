public class AvlTree<T>where T : IComparable
{

    public class Avlnode<T> where T : IComparable
    {
        public T Value { get; set; }

        public Avlnode<T> Left { get; set; }
        public Avlnode<T> Right { get; set; }

        public int Hight { get; set; }

        public Avlnode(T value)
        {
            Value = value;
            Hight = 1;
        }



    }

    public Avlnode<T> Root;

    #region Insert Tree
    private Avlnode<T> Insert(Avlnode<T> node,T value)
    {
        if (node == null) return new Avlnode<T>(value);


        if(value.CompareTo(node.Value)<0)
            node.Left= Insert(node.Left, value);
        else if (value.CompareTo(node.Value)>0)
            node.Right= Insert(node.Right,value);
        else 
            return node;

        UpdateHeight(node);

        return Balance(node);
    }
    public void Insert(T value)
    {
        Root = Insert(Root, value);
    }

    #endregion

    #region Balance tree
    private Avlnode<T> RightRotate(Avlnode<T> OriginalRoot)
    {
        //1- Make the Right SubTree are the new Root 

        Avlnode<T> newRoot = OriginalRoot.Left;

        Avlnode<T> OriginalRightChild = newRoot.Right; // My be null

        //2- The Original Root Been the left chilf of the new Root 
        newRoot.Right = OriginalRoot;

        //3- if the new Root Already has a left child We Put the left node on the newLeftNode.Left 

        //because the Original root been the right child of the new Node (the Current root)
        OriginalRoot.Left = OriginalRightChild;
            

        UpdateHeight(OriginalRoot);
        UpdateHeight(newRoot);


        return newRoot;

    }

    private Avlnode<T> LeftRotate(Avlnode<T> OriginalRoot)
    {
        //1- Make the Right SubTree are the new Root 

        Avlnode<T> newRoot = OriginalRoot.Right;

        Avlnode<T> OriginalLeftChild = newRoot.Left; // My be null

        //2- The Original Root Been the left chilf of the new Root 
        newRoot.Left = OriginalRoot;

        //3- if the new Root Already has a left child We Put the left node on the newLeftNode.Left 

        //because the Original root been the right child of the new Node (the Current root)
        OriginalRoot.Right = OriginalLeftChild;


        UpdateHeight(OriginalRoot);  
        UpdateHeight(newRoot);
        

        return newRoot; 
    }

    private int GetBalanceFactor(Avlnode<T> node)
    {
        return (node != null) ? Height(node.Left) - Height(node.Right) : 0;
    }

    private void UpdateHeight(Avlnode<T> node)
    {
        node.Hight =1 + Math.Max(Height(node.Left), Height(node.Right));   
    }

    public int BalanceFactory(Avlnode<T> node)
    {
        return Height(node.Left)-Height(node.Right);    
    }

    public int Height(Avlnode<T> node)
    {
        return (node != null)? node.Hight: 0; 
    }

    private Avlnode<T> Balance(Avlnode<T> node)
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

        if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);

        }

        //RL Rotaion 

        if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);

        }

        return node;

    }
    #endregion

    #region Delete Value
    private Avlnode<T> MaxNode(Avlnode<T> node)
    {
        // The max value are in the Right Sub Tree 

        var Current = node;

        while (Current.Right != null)
        {
            Current = Current.Right;
        }

        return Current;

    }
    private Avlnode<T> DeleteNode(Avlnode<T> node, T value)
    {
        if (node == null)
            return node;

        if (value.CompareTo(node.Value)<0)
        {
            node.Left = DeleteNode(node.Left, value);

        }
        else if (value.CompareTo(node.Value)>0)
        {
            node.Right = DeleteNode(node.Right, value);
        }
        else
        {
            //Found the value  : 


            //the first,Second scenarios when the node has one chile or no children  

            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            //Scenario of two childern

            //Seach the Maxmimuw value in the left subtree or the 
            //minumum value in the right subtree then replace it 
            //to the Parent node 


            //Search the max value in the Left Subtree 

            Avlnode<T> temp = MaxNode(node.Left);

            //Replace the Parent node with the minumum node 
            node.Value = temp.Value;

            //Delete inorer the successor

            node.Left = DeleteNode(node.Left, temp.Value);
        }

        UpdateHeight(node);
        return Balance(node);

    }
    public void Delete(T value)
    {
        Root = DeleteNode(Root, value); 
    }

    #endregion

    #region Print Tree 
    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    public void Print()
    {
        PrintTree(Root, 0);
    }

    void PrintTree(Avlnode<T> Node, int space = 1)
    {
        if (Node == null)
            return;

        PrintTree(Node.Right, space + 10);
        Console.WriteLine($"\n{MakeSpace(space)} {Node.Value}");
        PrintTree(Node.Left, space + 10);
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

    private void PrintTree(Avlnode<T> node, string indent, bool last)
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

    #endregion


    #region Search Region 

    private bool Exists(Avlnode<T> node,T value)
    {
        if(node == null )
            return false;

        if (value.CompareTo(node.Value)>0)
            return Exists(node.Right, value);
        else if (value.CompareTo(node.Value)<0)
            return Exists(node.Left, value);
        else
            return true;
    }

    public bool Exists(T value)
    {
        return Exists(Root, value);
    }



    private Avlnode<T> Search(Avlnode<T> node, T value)
    {
        if (node == null)
            return node;

        if (value.CompareTo(node.Value) > 0)
            return Search(node.Right, value);
        else if (value.CompareTo(node.Value) < 0)
            return Search(node.Left, value);
        else
            return node;
    }


    public Avlnode<T> Search(T value)
    {
        return Search(Root, value);
    }

    #endregion


    #region AutoComplete    


    private void AutoComplete(Avlnode<T> node,string Prefix, List<string> results)
    {
        if (node == null)
            return;


        if(node.Value.ToString().StartsWith(Prefix,StringComparison.OrdinalIgnoreCase))
        {
            results.Add(node.Value.ToString());
            AutoComplete(node.Left, Prefix, results);
            AutoComplete(node.Right, Prefix, results);
        }else
        {
            if(string.Compare(Prefix,node.Value.ToString(), StringComparison.OrdinalIgnoreCase)<0)
            {
                AutoComplete(node.Left, Prefix, results);
            }else
            {
                AutoComplete(node.Right, Prefix, results);
            }
        }

    }

    public IEnumerable<string> AutoComplete(string Search)
    {
        List <string> results = new List <string>();
        AutoComplete(Root,Search ,results); 
        return results;

    }



    #endregion

}
