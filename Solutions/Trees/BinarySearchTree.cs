namespace Trees;

public class BinarySearchTree
{
    public static TreeNode? SearchBST(TreeNode? root, int val)
    {
        // Find the node in the BST that the node's value equals val and return the subtree rooted with that node.
        // If such a node does not exist, return null.

        if (root == null || root.Value == val)
        {
            return root;
        }

        if (val < root.Value)
        {
            return SearchBST(root.Left, val);
        }

        return SearchBST(root.Right, val);
    }

}