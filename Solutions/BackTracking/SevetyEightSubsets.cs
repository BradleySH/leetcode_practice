using System.Collections;

namespace neetcodesolutions.Solutions.BackTracking;

public class SeventyEightSubsets {
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var currentSubset = new List<int>();

        BackTrack(nums, 0, currentSubset, result);
        return result;
    }

    private void BackTrack(int[] nums, int start, List<int> currentSubset, List<IList<int>> result)
    {
        result.Add(new List<int>(currentSubset));

        for (int i = start; i < nums.Length; i++)
        {
            currentSubset.Add(nums[i]);
            
            BackTrack(nums, i + 1, currentSubset, result);
            
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }
    }
}