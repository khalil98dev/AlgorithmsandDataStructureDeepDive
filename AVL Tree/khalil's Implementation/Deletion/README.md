# Lesson on Deleting Nodes from an AVL Tree

## Introduction

AVL trees are a type of self-balancing binary search tree where the height difference between the left and right subtree for any node is strictly less than two. This property ensures that AVL trees maintain O(log n) time complexity for searches, insertions, and deletions. This lesson focuses on how to correctly perform deletions in an AVL tree while maintaining its balancing properties.

### Review of AVL Tree Properties

Balance Factor: This is calculated as the height of the left subtree minus the height of the right subtree. For an AVL tree, the balance factor of any node should be -1, 0, or +1.Height Calculation: The height of a node is calculated as max(height of left child, height of right child) + 1.

### Understanding Deletion in Binary Search Trees (BST)

Before we delve into deletions specific to AVL trees, it’s crucial to understand basic deletion in a BST:

Leaf Node: Simply remove the leaf node.
Single Child Node: Remove the node and replace it with its child.
Two Children Node: Replace the node with its in-order successor (the smallest node in its right subtree) or predecessor (the largest node in its left subtree), then delete the successor or predecessor.

### Challenges of Deletion in AVL Trees

Deleting a node in an AVL tree might disrupt the balance of the tree, leading to increased time complexities for operations. Restoring the balance involves rotations.

### Rotations to Restore Balance

Single Rotations:

### Right-Right (RR): Rotate left at the unbalanced node.

Left-Left (LL): Rotate right at the unbalanced node.

#### Double Rotations:

#### Right-Left (RL): Rotate right at the right child, then rotate left at the unbalanced node.

Left-Right (LR): Rotate left at the left child, then rotate right at the unbalanced node.
Diagrams or animations are helpful here to visualize these rotations. Interactive tools can provide hands-on experience.

#### Step-by-Step Deletion Process in AVL Trees

Perform Standard BST Deletion: Start by removing the node as you would in a regular BST.
Check Balance Factors: From the deleted node's parent upwards to the root, check each node’s balance factor.
Apply Rotations if Necessary: If a node becomes unbalanced (balance factor of +2 or -2), apply the appropriate rotation to balance the tree.

# Summary

Deleting nodes in an AVL tree involves more than just removing the node; it requires recalculating heights and possibly applying rotations to maintain the tree’s balance. Mastering these steps ensures efficient performance of the AVL tree.
