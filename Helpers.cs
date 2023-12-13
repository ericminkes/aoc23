public static class Helpers
{
    public static bool IsDigit(this char c)
    {
        return c >= '0' && c <= '9';
    }

    public static long LCM(long a, long b)
    {
        long num1, num2;
        if (a > b)
        {
            num1 = a;
            num2 = b;
        }
        else
        {
            num1 = b;
            num2 = a;
        }

        for (long i = 1; i < num2; i++)
        {
            long mult = num1 * i;
            if (mult % num2 == 0)
            {
                return mult;
            }
        }
        return num1 * num2;
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
