using System.Runtime.CompilerServices;
using Trees;

namespace neetcodesolutions.Solutions.Trees.Depth_First_Search;

public class InorderTraversal
{
    public IList<int> InOrderTraversal(TreeNode root)
    {
        List<int> res = new();
        Helper(root, res);
        return res;
    }

    public void Helper(TreeNode root, List<int> res)
    {
        if (root is not null)
        {
            Helper(root.Left, res);
            res.Add(root.Value);
            Helper(root.Right, res);
        }
    }
}