// Bucket Sort
namespace Sorting.BucketSort;

public class BucketSort
{
    public static int[] SortColors(int[] nums)
    {
        // Counts the number of 0s, 1s and 2s in the array
        int[] counts = { 0, 0, 0 };

        foreach (int num in nums)
        {
            counts[num]++;
        }

        int i = 0;
        for (int n = 0; n < counts.Length; n++)
        {
            for (int j = 0; j < counts[n]; j++)
            {
                nums[i] = n;
                i++;
            }
        }

        return nums;
    }
}