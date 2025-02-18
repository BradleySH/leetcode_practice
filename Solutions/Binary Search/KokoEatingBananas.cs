namespace BinarySearch;

public class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = 1;

        foreach (int pile in piles)
        {
            right = Math.Max(right, pile);
        }

        while (left < right)
        {
            int mid = (left + right) / 2;
            int hours = 0;

            foreach (int pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / mid);
            }

            if (hours <= h)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
    
}