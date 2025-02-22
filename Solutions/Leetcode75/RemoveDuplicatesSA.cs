namespace neetcodesolutions.Solutions.Leetcode75;

public class RemoveDuplicatesSA
{
    public int RemoveDuplicates(int[] nums)
    {
        int count = 1, j = 1;
        
        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i - 1] == nums[i]) count++;
            else count = 1;

            if(count <= 2)
            {
                nums[j] = nums[i];
                j++;
            }
        }

        return j;
    }
}