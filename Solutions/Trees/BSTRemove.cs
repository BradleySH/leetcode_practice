using Trees;

namespace neetcodesolutions.Solutions.Trees;

public class BSTRemove
{
    public TreeNode MinValueNode(TreeNode root)
    {
        TreeNode curr = root;
        while (curr != null && curr.Left != null)
        {
            curr = curr.Left;
        }

        return curr;
    }
    public TreeNode DeleteNode(TreeNode root, int val)
    {
        if (root is null)
        {
            return null;
        }

        if (val < root.Value)
        {
            root.Left = DeleteNode(root.Left, val);
        }
        else if (val > root.Value)
        {
            root.Right = DeleteNode(root.Right, val);
        }
        else
        {
            if (root.Left is null)
            {
                return root.Right;
            }
            else if (root.Right is null)
            {
                return root.Left;
            }
            else
            {
                var minNode = MinValueNode(root.Right);
                root.Value = minNode.Value;
                root.Right = DeleteNode(root.Right, minNode.Value);
            }
        }

        return root;
    }
}