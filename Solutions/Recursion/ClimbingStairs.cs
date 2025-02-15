namespace NeetcodeSolutions.Solutions.Recursion;

public class ClimbingStairs
{
    public int ClimbStairs(int n)
    {
        if (n <= 2) return n;
        
        int first = 1;
        int second = 2;

        for (int i = 3; i <= n; i++)
        {
            int third = first + second;
            first = second;
            second = third;
        }

        return second;
    }

    public int ClimbStairsRecursive(int n)
    {
        if (n <= 2) return n;

        return ClimbStairsRecursive(n - 1) + ClimbStairsRecursive(n - 2);
    }
}