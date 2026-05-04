public static class CollectionUtils
{
    public static List<T> Distinct<T>(List<T> source)
    {
        var seen = new HashSet<T>();
        var result = new List<T>();
        foreach (var item in source)
        {
            if (seen.Add(item))
                result.Add(item);
        }
        return result;
    }

    public static Dictionary<TKey, List<TValue>> GroupBy<TValue, TKey>(
        List<TValue> source,
        Func<TValue, TKey> keySelector) where TKey : notnull
    {
        var result = new Dictionary<TKey, List<TValue>>();
        foreach (var item in source)
        {
            var key = keySelector(item);
            if (!result.TryGetValue(key, out var list))
            {
                list = new List<TValue>();
                result[key] = list;
            }
            list.Add(item);
        }
        return result;
    }

    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
        Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second,
        Func<TValue, TValue, TValue> conflictResolver) where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>(first);
        foreach (var pair in second)
        {
            if (result.TryGetValue(pair.Key, out var existing))
                result[pair.Key] = conflictResolver(existing, pair.Value);
            else
                result[pair.Key] = pair.Value;
        }
        return result;
    }

    public static T MaxBy<T, TKey>(List<T> source, Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        if (source.Count == 0)
            throw new InvalidOperationException("Коллекция пуста");

        var best = source[0];
        var bestKey = selector(best);
        for (int i = 1; i < source.Count; i++)
        {
            var current = source[i];
            var currentKey = selector(current);
            if (currentKey.CompareTo(bestKey) > 0)
            {
                best = current;
                bestKey = currentKey;
            }
        }
        return best;
    }
}
