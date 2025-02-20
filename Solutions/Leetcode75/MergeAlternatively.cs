using System.Text;

namespace neetcodesolutions.Solutions.Leetcode75;

public class Solution
{
    public string MergeAlternatively(string word1, string word2)
    {
        int w1 = word1.Length;
        int w2 = word2.Length;
        StringBuilder result = new StringBuilder();
        int i = 0, j = 0;

        while (i < w1 || j < w2)
        {
            if (i < w1)
            {
                result.Append(word1[i++]);
            }

            if (j < w2)
            {
                result.Append(word2[j++]);
            }
        }

        return result.ToString();
    }
}