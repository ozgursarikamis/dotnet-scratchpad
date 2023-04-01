using System.Collections.Concurrent;

namespace ConcurrentCollections;

public static class CopyConcurrentDictionaryItemsToAnotherCollection
{
    public static void Run()
    {
        var dictionary = new ConcurrentDictionary<string, string>();
        dictionary.TryAdd("1", "First");

        KeyValuePair<string, string>[] keyValuePairs = dictionary.ToArray();
        Dictionary<string, string> dict = 
            dictionary.ToDictionary(w => w.Key, w => w.Value);

        List<KeyValuePair<string, string>> keyValuePairList = dictionary.ToList();
        // or
        var keyValuePairList2 = new List<KeyValuePair<string, string>>(dictionary);
        // or
        var keyValuePairList3 = dict.ToList();
    }
}