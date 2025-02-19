using Trees;

namespace neetcodesolutions.Solutions.Trees.Breadth_First_Search;

public class RightSideBinary
{
    public List<int> RightSideView(TreeNode root)
    {
        var result = new List<int>();
        if (root is null)
        {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                if (i == levelSize - 1)
                {
                    result.Add(node.Value);
                }

                if (node.Left is not null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right is not null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        return result;
    }
}