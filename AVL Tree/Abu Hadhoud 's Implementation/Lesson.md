AVL Trees – Theory and Rotations
📌 Introduction

An AVL Tree is a self-balancing Binary Search Tree (BST).
It is named after its inventors Adelson-Velsky and Landis.

The key property of an AVL Tree is that it automatically maintains balance after insertions and deletions, ensuring efficient operations.

🧠 AVL Tree Property (Rule)

For every node in an AVL Tree:

The heights of the left and right subtrees differ by at most 1.

If this rule is violated at any time, rebalancing is performed to restore the AVL property.

📏 Height Definition

Height of a node is defined as:

The number of edges on the longest path from the node to a leaf.

⚖️ Balance Factor (BF)

The Balance Factor of a node is calculated as:

BF = Height(Left Subtree) − Height(Right Subtree)

Valid Balance Factors

BF = -1

BF = 0

BF = +1

If:

|BF| > 1

➡️ The node is unbalanced and rotations are required.

🔄 What Are Rotations?

Rotations are tree restructuring operations used to restore balance in an AVL Tree after insertions or deletions.

They:

Move nodes up or down

Preserve the Binary Search Tree property

Restore the required height balance

🔁 Types of AVL Rotations

There are four basic rotation cases:

Case Name Type
RR Right Rotation Single
LL Left Rotation Single
LR Left-Right Rotation Double
RL Right-Left Rotation Double
🔵 RR Rotation (Right Rotation)
When is RR Rotation Used?

The node becomes left-heavy

Balance Factor of the node is +2

Balance Factor of its left child is +1 or 0

Situation
A (+2)
/
B (+1)
/
C

🔧 RR Rotation Steps

The left child (B) becomes the new root of the subtree

The original root (A) becomes the right child of B

If B had a right child, it becomes the left child of A

After Rotation
B
/ \
 C A

The subtree is now balanced.

🟡 LL Rotation (Left Rotation)

Mirror case of RR Rotation.

Node becomes right-heavy

Balance Factor = -2

Right child BF = -1 or 0

🟠 LR Rotation (Left-Right Rotation)
When?

Node BF = +2

Left child BF = -1

Steps:

Left rotation on left child

Right rotation on the node

(Double rotation)

🔴 RL Rotation (Right-Left Rotation)
When?

Node BF = -2

Right child BF = +1

Steps:

Right rotation on right child

Left rotation on the node

(Double rotation)

✅ Summary

AVL Trees keep BST operations efficient by maintaining balance

Balance is measured using the Balance Factor

Rotations are used to restore balance

Four rotation cases handle all imbalance scenarios

📚 Useful For

Data Structures

Algorithms

Competitive Programming

Backend Systems

Database Indexing Concepts
