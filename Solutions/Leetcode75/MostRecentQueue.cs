namespace neetcodesolutions.Solutions.Leetcode75;

public class MostRecentQueue
{
    private int blockSize;
    private List<List<int>> blocks;

    public MostRecentQueue(int n)
    {
        blockSize = (int)Math.Sqrt(n) + 1;
        blocks = new List<List<int>>();
        List<int> curr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            curr.Add(i);
            if (curr.Count == blockSize)
            {
                blocks.Add(curr);
                curr = new List<int>();
            }
        }

        if (curr.Count > 0)
        {
            blocks.Add(curr);
        }
    }

    public int Fetch(int k)
    {
        k--;
        int b = 0;
        
        // locate block that contains kth element
        while (b < blocks.Count && k >= blocks[b].Count)
        {
            k -= blocks[b].Count;
            b++;
        }

        int val = blocks[b][k];
        blocks[b].RemoveAt(k);

        for (int i = b; i < blocks.Count - 1; i++)
        {
            if (blocks[i + 1].Count > 0)
            {
                int shiftVal = blocks[i + 1][0];
                blocks[i + 1].RemoveAt(0);
                blocks[i].Add(shiftVal);
            }
        }

        for (int i = blocks.Count - 1; i >= 0; i--)
        {
            if (blocks[i].Count == 0)
            {
                blocks.RemoveAt(i);
            }
        }

        if (blocks.Count == 0 || blocks[blocks.Count - 1].Count == blockSize)
        {
            blocks.Add(new List<int>());
        }
        blocks[blocks.Count - 1].Add(val);

        return val;
    }
}