using Trees;

namespace NeetcodeSolutions.Solutions.Trees;

public class BstInsert
{
    public TreeNode? InsertIntoBST(TreeNode? root, int val)
    {
        if (root is null)
        {
            return new TreeNode(val);
        }

        if (val < root.Value)
        {
            root.Left = InsertIntoBST(root.Left, val);
        }
        else if (val > root.Value)
        {
            root.Right = InsertIntoBST(root.Right, val);
        }

        return root;
    }
}