// See https://aka.ms/new-console-template for more information
using System;

string solutionToRun = "MinStack";

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

