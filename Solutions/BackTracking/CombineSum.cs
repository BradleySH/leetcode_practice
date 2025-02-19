namespace neetcodesolutions.Solutions.BackTracking;

public class CombineSum
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(candidates);
        BackTrack(candidates, target, new List<int>(), 0, result);
        return result;
    }
    
    // Helper
    private void BackTrack(int[] candidates, int target, List<int> current, int start, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
            {
                break;
            }

            current.Add(candidates[i]);
            BackTrack(candidates, target - candidates[i], current, i, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}