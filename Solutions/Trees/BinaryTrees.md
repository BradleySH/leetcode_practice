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


# Sets and Maps

Sets and Maps, similar to stacks and queues, are interfaces that can be implemented using trees. Implementing them with 
trees allows for a O(logn) time for insertion, deletions, and search operations.

### Sets
A TreeSet is a collection that maintains its elements in a sorted order and does not allow duplicate elements. 
It is typically implemented using a balanced binary search tree, such as a Red-Black Tree.

```csharp
class Program
{
    static void Main()
    {
        SortedSet<int> treeSet = new SortedSet<int>();
        treeSet.Add(3);
        treeSet.Add(1);
        treeSet.Add(2);

        foreach (var item in treeSet)
        {
            Console.WriteLine(item);
        }
    }
}
```

### Maps
A TreeMap, on the other hand, is typically implemented using a balanced binary search tree (such as a Red-Black Tree) 
and provides O(log n) time complexity for 
these operations. In C#, the equivalent of a 
TreeMap is the SortedDictionary class, which maintains the elements in a sorted order based on the keys.

```csharp
class Program
{
    static void Main()
    {
        SortedDictionary<int, string> treeMap = new SortedDictionary<int, string>();
        treeMap.Add(3, "Three");
        treeMap.Add(1, "One");
        treeMap.Add(2, "Two");

        foreach (var kvp in treeMap)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}
```