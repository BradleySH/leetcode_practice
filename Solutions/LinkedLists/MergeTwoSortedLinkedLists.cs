
public class MergeTwoSortedLinkedLists
{
    // Merge two sorted linked lists and return it as a new sorted list.
    // The new list should be made up of nodes from list1 and list2

    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 is null || list2 is null)
            return list1 ?? list2;

        ListNode? dummy = new ListNode();
        ListNode? current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        current.next = list1 ?? list2;

        return dummy.next;
    }

    // Recursive solution
    public static ListNode? MergeTwoListsRecursive(ListNode? list1, ListNode? list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        // Recursive case
        if (list1.val <= list2.val)
        {
            list1.next = MergeTwoListsRecursive(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeTwoListsRecursive(list1, list2.next);
            return list2;
        }
    }
}