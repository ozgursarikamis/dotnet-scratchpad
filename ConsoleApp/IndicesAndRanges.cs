namespace ConsoleApp;

public static class IndicesAndRanges
{
    public static void Run()
    {
        // Generate numbers from 1 (INCLUSIVE) to 10 (INCLUSIVE)
        var numbers = Enumerable.Range(1, 10).ToArray();
        var copy = numbers[..]; // copy of the array
        var copy2 = numbers[0..10]; // copy of the array
        var copy3 = numbers[0..^0];

        
        var allItemsExceptTheFirst = numbers[1..];
        var allItemsExceptTheLast = numbers[..^1];
        
        var lastItemRange = numbers[^1..]; // gives the item in an array
        var lastItem = numbers[^1]; // gives the item directly instead of in an array
    }
}