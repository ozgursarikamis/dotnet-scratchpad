using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class ConcurrentStacks
{
    public static void Run()
    {
        // StandardStacks();
        ConcurrentStacksMethod();
    }

    private static void ConcurrentStacksMethod()
    {
        List<int> ints = new()
        {
            1, 2, 3, 4, 5
        };
        ConcurrentStack<int> stack = new(ints);
        var count = stack.Count;
        WriteLine($"Count: {count}");
        WriteLine("====================================");
        
        WriteLine("Push Method:");
        stack.Push(6);
        
        WriteLine("After Push Method");
        foreach (var item in ints) 
            WriteLine(item);
    }

    private static void StandardStacks()
    {
        Stack<int> myStack = new();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);

        foreach (var item in myStack)
            WriteLine(item);

        WriteLine("====================================");
        int[] arr = new int[] { 1, 2, 3, 4 };
        Stack<int> myStack2 = new(arr);

        foreach (var item in myStack2)
            WriteLine(item);
        
        WriteLine("====================================");
        WriteLine($"Pop Method Returns Last Element and Removes It From Stack: {myStack2.Pop()}");
        
        WriteLine("After Pop():");
        foreach (var item in myStack2)
            WriteLine(item);
        
        WriteLine("====================================");
        WriteLine($"Peek Method Returns Last Element Without Removing It From Stack: {myStack2.Peek()}");
        
        WriteLine("After Peek():");
        foreach (var item in myStack2)
            WriteLine(item);
        
        WriteLine("====================================");
        WriteLine("Contains Method:");
        WriteLine(myStack2.Contains(2));

    }
}