# Insertion Operations In Red Black Tree

Let’s delve into the primary operations performed on Red Black Trees: insertion, deletion, and lookup. Each operation must maintain the Red Black Tree properties to ensure the tree remains balanced.

When inserting a new node into a Red Black Tree, the new node is initially colored red. The reason for starting with red is to maintain property 5 (balanced black height), which is easier to manage initially as red. If the insertion of a red node violates the properties of the Red Black Tree, adjustments and rotations are made.

## Steps for Insertion:

1. Insert the new node as in a regular binary search tree.
2. Color the new node red.
3. Fix any violations of the Red Black Tree properties using rotations and recoloring.

### Lesson: Insertion Operation in a Red-Black Tree

**Objective:**
Learn how to perform the insertion operation in a Red-Black Tree, including maintaining the tree's balancing properties through rotations and color changes.

### 1. Overview of Insertion in Red-Black Trees

Insertion in a Red-Black Tree involves **two main tasks**:

1. **Standard BST Insertion:** The new node is initially inserted as in a regular Binary Search Tree (BST).
2. **Restoring Red-Black Properties:** After insertion, the tree might violate the Red-Black properties, so adjustments (rotations and recoloring) are made to restore them.

### 2. Step-by-Step Insertion Process

**Step 1:** Regular BST Insertion

- Insert the new node as you would in a BST. New nodes are always inserted as red nodes.

**Step 2:** Restoration of Properties

- If the new node is the root node, simply recolor it to black.
- If the new node's parent is black, do nothing.
- If the new node's parent is red, further adjustments are needed to fix potential violations.

### 3. Handling Violations

When the parent of the new node is red, there are a few scenarios to consider based on the color of the uncle node (the sibling of the parent):

**Case 1:** Uncle is red

- Recolor the parent and uncle black and the grandparent red.
- Move the current node pointer to the grandparent and repeat the restoration process.

**Case 2:** Uncle is black or NULL, which requires rotations:

- Left-Left (LL) Case: Straight line formation on left side. Right rotate the grandparent.
- Left-Right (LR) Case: Triangle formation on the left. Left rotate the parent, then right rotate the grandparent.
- Right-Right (RR) Case: Straight line formation on the right. Left rotate the grandparent.
- Right-Left (RL) Case: Triangle formation on the right. Right rotate the parent, then left rotate the grandparent.

**After each rotation, recolor the involved nodes appropriately.**

## Conclusion

Understanding and implementing Red Black Trees can be challenging but rewarding. With practice and the use of visual tools, you can gain a deeper understanding and appreciation for this efficient and robust data structure.

## Impelmentaion

```csharp
public class RedBlackTree
{
    #region Red Black Node

    public class RBNode
    {
        public int Value {  get; set; }

        public RBNode Left { get; set; }

        public RBNode Right { get; set; }

        public RBNode Parent { get; set; }

        public bool IsRed { get; set; } = true;

        public RBNode(int value)
        {
            this.Value = value;
        }
    }

    #endregion


    public RBNode Root { get; set; }

    public void Insert(int value)
    {
        var newNode = new RBNode(value);

        if (Root == null)
        {
            Root = newNode;
            Root.IsRed = false; // The root must be black
            return;
        }


        RBNode Current = Root;
        RBNode Parent = null;

        while(Current != null)
        {
            Parent = Current;

            if(value<Current.Value)
                Current = Current.Left;
            else
                Current = Current.Right;
        };

        //Set The Parent of new Node
        newNode.Parent = Parent;

        if (value < Parent.Value)
            Parent.Left = newNode;
        else
            Parent.Right = newNode;


        //FixInsertion(newNode);
        FixInsert(newNode);
    }



    private void FixInsertion(RBNode node)
    {
        RBNode parent = null;
        RBNode grandParent = null;
        RBNode uncle = null;

        //while the nodeis not the root and it is red and  it's Parent is red So  violote
        while(node!=Root && node.IsRed && node.Parent.IsRed)
        {
            //Case: Uncle is  Red

            parent = node.Parent;
            grandParent = parent.Parent;

            if(parent == grandParent.Left)
                uncle = grandParent.Right;
            else
                uncle = grandParent.Left;


            if(uncle!=null && uncle.IsRed)
            {
                grandParent.IsRed  = true; //Recolor the GrandPa to red
                parent.IsRed = false; // Recoller the parent to black
                uncle.IsRed = false; //recolor the Uncle to Black
                node = grandParent;// Move the tree to continue fixing.
            }
            else
            {
               bool traingle =(grandParent.Left == parent && parent.Right == node)
                                      ||
                              (grandParent.Right == parent && parent.Left == node);

                bool line =
                      (grandParent.Left == parent && parent.Left == node)
                      ||
                      (grandParent.Right == parent && parent.Right == node);


                if (traingle)
                {
                    if (node == parent.Left)
                        RotateRight(parent);
                    else
                        RotateLeft(parent);

                    node = parent;
                    parent = node.Parent;


                    if (node == parent.Left)
                        RotateRight(grandParent);
                    else
                        RotateLeft(grandParent);

                    //swap
                    (parent.IsRed, grandParent.IsRed) = (grandParent.IsRed, parent.IsRed);
                    node = parent;

                }
            }
        }


        Root.IsRed = false;// Ensure the root remains black
    }


    private void FixInsert(RBNode node)
    {
        RBNode parent = null;
        RBNode grandparent = null;


        // Fix the tree as long as the node is not the root and both the node and its parent are red
        while ((node != Root) && (node.IsRed) && (node.Parent.IsRed))
        {
            parent = node.Parent;
            grandparent = parent.Parent;


            // Parent node is a left child
            if (parent == grandparent.Left)
            {
                RBNode uncle = grandparent.Right; // Uncle node is the right child


                // Case 1: The uncle is red (recoloring)
                if (uncle != null && uncle.IsRed)
                {
                    grandparent.IsRed = true; // Recolor grandparent to red
                    parent.IsRed = false; // Recolor parent to black
                    uncle.IsRed = false; // Recolor uncle to black
                    node = grandparent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2: Node is the right child of its parent (Triangle Case)
                    if (node == parent.Right)
                    {
                        // Perform left rotation on parent to transform the triangle case into the line case
                        RotateLeft(parent);
                        node = parent;
                        parent = node.Parent;
                    }


                    // Case 3: Node is now the left child of its parent (Line Case)
                    // Perform right rotation on grandparent to balance the tree
                    RotateRight(grandparent);
                    // Swap colors of parent and grandparent to maintain Red-Black properties
                    bool tmp = parent.IsRed;
                    parent.IsRed = grandparent.IsRed;
                    grandparent.IsRed = tmp;
                    node = parent;
                }
            }
            else // Parent node is a right child
            {
                RBNode uncle = grandparent.Left; // Uncle node is the left child


                // Case 1: The uncle is red (recoloring)
                if (uncle != null && uncle.IsRed)
                {
                    grandparent.IsRed = true; // Recolor grandparent to red
                    parent.IsRed = false; // Recolor parent to black
                    uncle.IsRed = false; // Recolor uncle to black
                    node = grandparent; // Move up the tree to continue fixing
                }
                else
                {
                    // Case 2: Node is the left child of its parent (Triangle Case)
                    if (node == parent.Left)
                    {
                        // Perform right rotation on parent to transform the triangle case into the line case
                        RotateRight(parent);
                        node = parent;
                        parent = node.Parent;
                    }


                    // Case 3: Node is now the right child of its parent (Line Case)
                    // Perform left rotation on grandparent to balance the tree
                    RotateLeft(grandparent);
                    // Swap colors of parent and grandparent to maintain Red-Black properties
                    bool tmp = parent.IsRed;
                    parent.IsRed = grandparent.IsRed;
                    grandparent.IsRed = tmp;
                    node = parent;
                }
            }
        }


        Root.IsRed = false; // Ensure the root remains black
    }


    private void RotateLeft(RBNode node)
    {
        RBNode right = node.Right; // Right child becomes the new root of the subtree
        node.Right = right.Left; // Move the left subtree of right to the right subtree of node

        if (node.Right != null)
            node.Right.Parent = node; // Set parent of the new right child


        right.Parent = node.Parent; // Connect new root with the grandparent


        if (node.Parent == null)
            Root = right; // The right child becomes new root of the tree
        else if (node == node.Parent.Left)
            node.Parent.Left = right; // Set right child to left child of parent
        else
            node.Parent.Right = right; // Set right child to right child of parent


        right.Left = node; // Original node becomes the left child of its right child
        node.Parent = right; // Update parent of the original node
    }

    private void RotateRight(RBNode node)
    {
        RBNode left = node.Left; // Right child becomes the new root of the subtree
        node.Left = left.Right; // Move the left subtree of right to the right subtree of node

        if (node.Left != null)
            node.Left.Parent = node; // Set parent of the new right child


        left.Parent = node.Parent; // Connect new root with the grandparent


        if (node.Parent == null)
            Root = left; // The right child becomes new root of the tree
        else if (node == node.Parent.Left)
            node.Parent.Left = left; // Set right child to left child of parent
        else
            node.Parent.Right = left; // Set right child to right child of parent


        left.Right = node; // Original node becomes the left child of its right child
        node.Parent = left; // Update parent of the original node
    }


    #region Print Tree


    // Public method to print the tree
    public void PrintTree()
    {
        PrintHelper(Root, "", true);
    }


    // Helper method to print the tree
    private void PrintHelper(RBNode node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "   ";
            }
            else
            {
                Console.Write("L----");
                indent += "|  ";
            }
            var color = node.IsRed ? "RED" : "BLK";
            Console.WriteLine(node.Value + "(" + color + ")");
            PrintHelper(node.Left, indent, false);
            PrintHelper(node.Right, indent, true);
        }
    }

    public void Print()
    {
        PrintTree(Root, 0);
    }

    void PrintTree(RBNode Node, int space = 1)
    {
        if (Node == null)
            return;

        PrintTree(Node.Right, space + 10);
        string Color = (Node.IsRed) ? "red" : "Black";
        Console.WriteLine($"\n{MakeSpace(space)} {Node.Value.ToString() } ({Color})");
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

    #endregion
}

```
