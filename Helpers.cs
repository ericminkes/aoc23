public static class Helpers
{
    public static bool IsDigit(this char c)
    {
        return c >= '0' && c <= '9';
    }

    public static int BinarySearch<T>(this List<T> list, T item, Func<T, T, int> compare)
    {
        return list.BinarySearch(item, new ComparisonComparer<T>(compare));
    }
}

public class ComparisonComparer<T> : IComparer<T>
{
    private readonly Comparison<T> comparison;

    public ComparisonComparer(Func<T, T, int> compare)
    {
        if (compare == null)
        {
            throw new ArgumentNullException("comparison");
        }
        comparison = new Comparison<T>(compare);
    }

    public int Compare(T x, T y)
    {
        return comparison(x, y);
    }
}
