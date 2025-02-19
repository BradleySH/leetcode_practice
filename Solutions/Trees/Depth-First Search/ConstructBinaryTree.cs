using Trees;

namespace neetcodesolutions.Solutions.Trees.Depth_First_Search;

public class ConstructBinaryTree
{
    private int preorderIndex;
    private Dictionary<int, int> inorderIndexMap;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder == null || inorder == null || preorder.Length != inorder.Length)
        {
            return null;
        }

        inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderIndexMap[inorder[i]] = i;
        }

        preorderIndex = 0;
        return ArrayToTree(preorder, 0, inorder.Length - 1);
    }

    private TreeNode ArrayToTree(int[] preorder, int left, int right)
    {
        if (left > right)
        {
            return null;
        }

        int rootVal = preorder[preorderIndex++];
        TreeNode root = new TreeNode(rootVal);

        int inorderRootIndex = inorderIndexMap[rootVal];

        root.Left = ArrayToTree(preorder, left, inorderRootIndex - 1);
        root.Right = ArrayToTree(preorder, inorderRootIndex + 1, right);

        return root;
    }
}