
public class ConcatOfArray
{
    public static int[] GetConcatenation(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            ans[i] = nums[i];
            ans[i + n] = nums[i];
        }
        return ans;
    }

    public static int[] GetConcatOptimized(int[] nums)
    {
        return nums.Concat(nums).ToArray();
    }


    // Faster than above
    public static int[] GetConcatOptimized2(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[2 * n];
        Array.Copy(nums, 0, ans, 0, n);
        Array.Copy(nums, 0, ans, n, n);
        return ans;
    }
}