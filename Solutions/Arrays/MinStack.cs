

public class MinStack
{
    private readonly Stack<int> stack;
    private readonly Stack<int> minStack;

    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        stack.Push(val);

        // Push to minStack if it's empty or val is <= current min
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }

    public void Pop()
    {
        // Pop the top element from both stacks if they match
        if (stack.Peek() == minStack.Peek())
        {
            minStack.Pop();
        }
        stack.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}