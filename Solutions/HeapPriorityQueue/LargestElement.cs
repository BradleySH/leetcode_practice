namespace neetcodesolutions.Solutions.HeapPriorityQueue;

public class KthLargest
{
    private int k;
    private PriorityQueue<int, int> minHeap;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        if (minHeap.Count < k)
        {
            minHeap.Enqueue(val, val);
        }
        else if (val > minHeap.Peek())
        {
            minHeap.Dequeue();
            minHeap.Enqueue(val, val);
        }

        return minHeap.Peek();
    }
}
