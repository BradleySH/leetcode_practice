# Binary Trees

### Concept

Similar to Linked Lists, Binary Trees are another data structure that involve nodes and pointers.

With Linked Lists, we connected nodes in a straight line `next` and `prev` pointers. Nodes in a binary tree also have at most two pointers, but we call them `left child` and `right child` pointers. The first node is called the `root` node. We draw the pointers down instead of a straight line.

The value of a node can be any data type. A `TreeNode` class would look like the following. Notice how much of the implementation is similar to a `ListNode` except these nodes are children.

```csharp
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int val, TreeNode left, TreeNode right)
    {
        this.Value = val;
        this.Left = left;
        this.Right = right;
    }
}
```
Nodes with no children are called `leaf nodes`.

Unlike Link Lists, binart tree node pointers can only point one direction.  No cycles are allowed.


