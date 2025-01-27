// Given the head of a singly linked list, reverse the list and return the reversed list.

// Given in Leetcode
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}

public class ReversedLinkedList
{
    public static ListNode? ReverseList(ListNode? head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode? prev = null;
        ListNode? current = head;

        while (current != null)
        {
            // Store the next node
            ListNode? next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }


    public static ListNode? ReverseLinkedListRecursive(ListNode? head)
    {
        if (head == null || head.next == null)
            return head;

        // Recursively reverse the rest of the list
        ListNode? newHead = ReverseLinkedListRecursive(head.next);

        // Reverse the current node
        head.next.next = head; // Point the next node back to the current node
        head.next = null;

        return newHead;
    }


    // Iterative approach
    // Time Complexity: O(n)
    // Space Complexity: O(1)

    // Recursive approach
    // Time Complexity: O(n)
    // Space Complexity: O(n)

    // Iterative approach is more efficient in terms of space complexity, as it doesn't require additional stack space for recursion.
    // Just practicing recursion here.
}
