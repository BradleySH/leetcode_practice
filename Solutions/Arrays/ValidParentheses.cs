// Given a string s contianing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// An input string is valid if:
// 1. Open brackets are closed by the same type of brackets.
// 2. Open brackets are closed in the correct order.
// 3. Every close bracket has a corresponding open bracket of the same type.

// Example 1:
// Input: s = "()"
// Output: true

// Example 2:
// Input: s = "()[]{}"
// Output: true

// Example 3:
// Input: s = "(]"
// Output: false

// Example 4:
// Input: s = "[()]"
// Output: true

// Constraints:
// 1. 1 <= s.length <= 10^4
// 2. s consists of parentheses only '()[]{}'.

public class ValidParentheses
{
    // Brute Force
    public static bool IsValidString(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "")
                 .Replace("[]", "")
                 .Replace("{}", "");
        }
        return s.Length == 0;
    }


    public static bool IsValidStringOptimized(string s)
    {
        var stack = new Stack<char>();
        var map = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (var c in s)
        {
            if (map.TryGetValue(c, out char value))
            {
                // Pop the top of the stack if it exists, else use a dummy character
                char topElement = stack.Count > 0 ? stack.Pop() : '#';

                // Check if the top element matches the required opening bracket
                if (topElement != value)
                {
                    return false;
                }
            }
            else
            {
                // push opening bracket onto the stack
                stack.Push(c);
            }
        }

        // If the stack is empty, then all the opening brackets have been matched
        return stack.Count == 0;
    }
}