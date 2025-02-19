using System.Collections;
using Trees;

namespace neetcodesolutions.Solutions.Trees.Breadth_First_Search;

public class LevelOrderTraverse
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root is null)
        {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var currLevel = new List<int>();
            
            // Dequeue levelSize nodes of the current level
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                currLevel.Add(node.Value);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
                
            }
            result.Add(currLevel);
        }
        return result;
    }
}