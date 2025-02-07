﻿// See https://aka.ms/new-console-template for more information
using System;

string solutionToRun = "DesignLinkedList";

switch (solutionToRun)
{
    case "ConcatOfArray":
        RunConcatOfArray();
        break;

    case "ValidParentheses":
        RunValidParentheses();
        break;

    case "MinStack":
        RunMinStack();
        break;

    case "ReversedLinkedList":
        RunReversedLinkedList();
        break;

    case "MergeTwoSortedLinkedLists":
        RunMergeTwoSortedLinkedLists();
        break;

    case "DesignLinkedList":
        RunDesignLinkedList();
        break;
}

static void RunConcatOfArray()
{
    int[] nums = { 1, 2, 1 };
    int[] nums2 = { 1, 3, 2, 1 };

    Console.WriteLine(string.Join(",", ConcatOfArray.GetConcatenation(nums)));
    Console.WriteLine(string.Join(",", ConcatOfArray.GetConcatenation(nums2)));

    Console.WriteLine(string.Join(",", ConcatOfArray.GetConcatOptimized(nums)));
    Console.WriteLine(string.Join(",", ConcatOfArray.GetConcatOptimized(nums2)));
}

static void RunValidParentheses()
{
    string[] testCases = { "()", "()[]{}", "(]", "[()]" };

    Console.WriteLine("Brute Force");
    foreach (var testCase in testCases)
    {
        Console.WriteLine($"{testCase} -> {ValidParentheses.IsValidString(testCase)}");
    }

    Console.WriteLine("\nOptimized");
    foreach (var testCase in testCases)
    {
        Console.WriteLine($"{testCase} -> {ValidParentheses.IsValidStringOptimized(testCase)}");
    }
}

static void RunMinStack()
{
    MinStack minStack = new MinStack();
    minStack.Push(-2);
    minStack.Push(0);
    minStack.Push(-3);

    Console.WriteLine(minStack.GetMin());
    minStack.Pop();
    Console.WriteLine(minStack.Top());
    Console.WriteLine(minStack.GetMin());
}

static void RunReversedLinkedList()
{
    // Create a linked list: 1 -> 2 -> 3 -> 4 -> 5
    ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

    // Test Iterative Approach
    Console.WriteLine("Iterative Approach");
    ListNode? reversedIterative = ReversedLinkedList.ReverseList(head);
    PrintLinkedList(reversedIterative);

    // Recreate the linked list for the recursive approach
    head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

    Console.WriteLine("Recursive Approach");
    ListNode? reversedRecursive = ReversedLinkedList.ReverseLinkedListRecursive(head);
    PrintLinkedList(reversedRecursive);
}

static void PrintLinkedList(ListNode? head)
{
    while (head != null)
    {
        Console.Write(head.val + " -> ");
        head = head.next;
    }
    Console.WriteLine();
}

static void RunMergeTwoSortedLinkedLists()
{
    ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
    ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

    Console.WriteLine("Iterative Approach");
    ListNode? merged = MergeTwoSortedLinkedLists.MergeTwoLists(list1, list2);
    PrintLinkedList(merged);

    list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
    list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

    Console.WriteLine("Recursive Approach");
    ListNode? mergedRecurive = MergeTwoSortedLinkedLists.MergeTwoListsRecursive(list1, list2);
    PrintLinkedList(mergedRecurive);
}

static void RunDesignLinkedList()
{
    DesignLinkedList.MyLinkedList myLinkedList = new DesignLinkedList.MyLinkedList();

    Console.WriteLine("Adding at head: 1");
    myLinkedList.AddAtHead(1);
    myLinkedList.PrintList(); // 1 <-> null

    Console.WriteLine("Adding at tail: 3");
    myLinkedList.AddAtTail(3);
    myLinkedList.PrintList(); // 1 <-> 3 <-> null

    Console.WriteLine("Adding at index 1: 2");
    myLinkedList.AddAtIndex(1, 2);
    myLinkedList.PrintList(); // 1 <-> 2 <-> 3 <-> null

    Console.WriteLine("Getting value at index 1:");
    Console.WriteLine(myLinkedList.Get(1)); // Output: 2

    Console.WriteLine("Deleting node at index 1");
    myLinkedList.DeleteAtIndex(1);
    myLinkedList.PrintList(); // 1 <-> 3 <-> null

    Console.WriteLine("Getting value at index 1:");
    Console.WriteLine(myLinkedList.Get(1)); // Output: 3
}
