# Red Black Tree

## Introduction to Red Black Trees

A Red-Black Tree is a type of self-balancing binary search tree, a data structure used in computer science to organize pieces of comparable data, such as numbers. Each node in a Red-Black Tree contains an extra bit for denoting the color of the node, either red or black. This color attribute is essential for balancing the tree during insertions and deletions. This balance ensures that the tree remains efficient for operations like insertion, deletion, and lookup, which all have time complexity of O(log n) in the worst case.

## Why Red Black Trees?

Red Black Trees are crucial because they provide a good balance between the complexity of operations and the performance guarantees. They are used in various real-world applications, including:

- Implementing associative arrays
- Building memory-efficient maps and sets in programming languages like C++, Java, and others.
- Maintaining a sorted stream of data.

### Properties of Red Black Trees

Every node in a Red Black Tree ** has a color **, either red or black.
The tree must satisfy these five essential properties:

1. **Color Property:** Every node is either red or black.
2. **Root Property:** The root of the tree is always black.
3. All leaves (NIL nodes) **are black**.
4. **Red Property:** If a red node has children, then both are black (no two red nodes appear in a sequence).
5. **Depth Property**: Every path from a node to its descendant NULL nodes has the same number of black nodes.

These properties ensure that the tree remains approximately balanced, with no path more than twice as long as any other, keeping operations efficient.

These properties guarantee that the longest path from the root to the leaf is no more than twice as long as the shortest path, ensuring the tree remains approximately balanced. As a result, operations such as insertion, deletion, and lookup can be completed in logarithmic time, making Red-Black Trees an efficient choice for various applications in computer science, including implementing associative arrays, priority queues, and in the construction of many other data structures.
