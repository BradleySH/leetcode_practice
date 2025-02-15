namespace NeetcodeSolutions.Solutions.Sorting;

public class MergeListNode(int x)
{
    public int val = x;
    public MergeListNode? next = null;
}

public class MergeKSortedLists
{
    public MergeListNode? MergeKLists(MergeListNode?[] lists)
    {
        if (lists == null || lists.Length == 0)
            return null;

        return MergeKLists(lists, 0, lists.Length - 1);
    }

    // Divide and Conquer helper
    private MergeListNode? MergeKLists(MergeListNode?[] lists, int left, int right)
    {
        if (left == right)
            return lists[left];

        int mid = left + (right - left) / 2;
        MergeListNode? l1 = MergeKLists(lists, left, mid);
        MergeListNode? l2 = MergeKLists(lists, mid + 1, right);

        return MergeTwoLists(l1, l2);
    }

    // Merge the two sorted lists into one sorted list
    private MergeListNode? MergeTwoLists(MergeListNode? l1, MergeListNode? l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        MergeListNode dummy = new MergeListNode(0);
        MergeListNode current = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                current.next = l1;
                l1 = l1.next;
            }
            else
            {
                current.next = l2;
                l2 = l2.next;
            }
            current = current.next;
        }

        // Attach the remaining nodes 
        current.next = l1 ?? l2;
        return dummy.next;

    }

}