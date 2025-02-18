using Trees;

namespace neetcodesolutions.Solutions.Trees.Depth_First_Search;

public class SmallestElement
{
    public int KthSmallest(TreeNode? root, int k)
    {
        Stack<TreeNode?> stack = new();

        while (true)
        {
            while (root is not null)
            {
                stack.Push(root);
                root = root.Left;
            }
            
            root = stack.Pop();
            if (--k == 0) return root.Value;
            root = root.Right;
        }
    }
}