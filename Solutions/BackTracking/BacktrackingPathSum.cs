using Trees;

namespace neetcodesolutions.Solutions.BackTracking;

public class BacktrackingPathSum
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }

        targetSum -= root.Value;

        if (root.Left == null && root.Right == null)
            return targetSum == 0;

        return HasPathSum(root.Left, targetSum) || HasPathSum(root.Right, targetSum);
    }
}