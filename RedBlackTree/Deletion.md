# Understanding Deletion in a Red-Black Tree

## What is a Red-Black Tree?

A **Red-Black Tree** is a type of **self-balancing binary search tree**. Each node contains an extra bit of information—its **color**, which is either **red** or **black**.  
This coloring mechanism ensures that the tree remains approximately balanced, allowing **search**, **insert**, and **delete** operations to run in **O(log n)** time.

---

## Why is Deletion Important?

Deletion is a fundamental operation that allows elements to be removed from the tree.  
However, removing a node can break one or more **Red-Black Tree properties**, causing the tree to become unbalanced.  
To maintain efficiency, the tree must be **fixed** after deletion using recoloring and rotations.

---

## Key Properties of Red-Black Trees

Before diving into the deletion process, remember these important properties:

1. Every node is either **red** or **black**.
2. The **root** is always **black**.
3. **Red nodes cannot have red children** (no two consecutive red nodes).
4. Every path from a node to its descendant leaves contains the **same number of black nodes** (black-height).

These rules guarantee that the tree remains balanced.

---

## Steps for Deleting a Node

Deleting a node in a Red-Black Tree consists of three main phases:

---

### 1. Find the Node to Delete

- Start at the root.
- Compare the target value with the current node’s value.
- Move left or right as in a standard **Binary Search Tree (BST)** search.
- Continue until the node is found.

---

### 2. Delete the Node

The deletion logic depends on how many children the node has:

#### Case 1: Node Has No Children (Leaf Node)

- Remove the node directly.
- If the node is **red**, no fix is needed.
- If the node is **black**, a violation may occur and must be fixed.

#### Case 2: Node Has One Child

- Replace the node with its child.
- Ensure the replacement node is colored **black** to preserve properties.

#### Case 3: Node Has Two Children

- Find the **in-order successor** (smallest node in the right subtree).
- Copy the successor’s value into the node.
- Delete the successor node instead.
- This reduces the problem to **Case 1 or Case 2**.

---

### 3. Fix the Tree (Rebalancing)

After deletion, the tree may violate Red-Black properties, especially the **black-height** rule.

To restore balance, the algorithm may perform:

- **Recoloring** of nodes
- **Left rotations**
- **Right rotations**

These operations are applied based on the color of:

- The deleted node
- Its sibling
- The sibling’s children

The goal is to restore all Red-Black Tree properties while keeping the tree balanced.

---

## Summary

- Deletion in a Red-Black Tree starts like a normal BST deletion.
- The complexity comes from restoring the tree’s properties.
- Recoloring and rotations ensure the tree remains balanced.
- Proper fixing guarantees **O(log n)** performance after deletion.

---

**Red-Black Trees trade complexity in deletion logic for guaranteed performance.**
