# Fixing Violations During Deletion in Red-Black Trees

When a black node is deleted in a Red-Black tree, a "double black" situation may arise, which violates the tree's properties. The resolution strategy depends on the color of the sibling node and its children.

## Case 1: Sibling is Red

**Action:**

When you delete the node, it becomes double black.
Perform a rotation to move the red sibling to the parent's position.
Swap the colors of the sibling and the parent (color the sibling black and the parent red).
The double black situation still exists, but now the sibling of the double black node is black, allowing you to continue with the appropriate steps for Case 2.

## Case 2: Sibling is Black

### Sub-case 2.1: Sibling's Children Are Both Black

**Action:**

When you delete the node, it becomes double black.
Color the sibling red.
Move the double black up to the parent (effectively reducing the problem to the parent).
If the parent is red, color it black to resolve the double black.
If the parent is black, the double black situation may continue, requiring further handling up the tree.

## Sub-case 2.2: At Least One of the Sibling's Children is Red

### Sub-sub-case 2.2.1: Sibling's Far Child is Red

**Action:**

1. When you delete the node, it becomes double black.
2. Perform a rotation on the parent and sibling (if the sibling is a right child, perform a left rotation; if the sibling is a left child, perform a right rotation).
3. Color the far child black.
4. Color the original sibling with the parent's original color.
5. Color the parent black.
6. The double black situation My be resolved and may be not: further steps are required to resolve the double black, potentially involving moving the double black up the tree and applying the rules from Case 2.1 or Case 2.2 again.

### Sub-sub-case 2.2.2: Sibling's Near Child is Red:

**Action:**

1. When you delete the node, it becomes double black.
2. Perform a rotation on the sibling and its parent (right rotation if the sibling is a left child; left rotation if the sibling is a right child).
3. Swap the colors of the sibling and its near child.
4. Now, the sibling is red, turning this into Sub-sub-case 2.2.1.
5. Follow the actions in Sub-sub-case 2.2.1 to resolve the double black.

**Key Points:**

- The primary goal is to restore the Red-Black properties: maintaining the balancing of the tree and preserving the black height.
- Actions taken depend on the relative colors of the sibling, the sibling's children, and the double black node.
- The process may involve multiple iterations, propagating the double black situation upward if necessary.
