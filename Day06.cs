public class Day06 : IDay
{
    public string Number => "06";

    public string Part1() => $"Test: {Impl1(Test)} (verwacht 288)\nReal: {Impl1(Input)}";

    public string Part2() => $"Test: {Impl2(Test)} (verwacht 71503)\nReal: {Impl2(Input)}";

    private string Impl1(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var times = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
        var distances = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
        var product = 1;
        for (var t = 0; t < times.Count; t++)
        {
            var time = times[t];
            var dist = distances[t];
            var better = Enumerable.Range(1, time - 1).Count(n => n * (time - n) > dist);
            product *= better;
        }
        return product.ToString();
    }

    private string Impl2(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var time = long.Parse(lines[0].Split(':')[1].Replace(" ", ""));
        var dist = long.Parse(lines[1].Split(':')[1].Replace(" ", ""));

        var left = 1L;
        var right = (time - 1) / 2;
        while (left < right)
        {
            var mid = (left + right - 1) / 2;
            if (mid * (time - mid) <= dist)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        var start = right * (time - right) > dist ? right : left;
        var better = time - 2 * start + 1;
        return better.ToString();
    }

    private const string Test =
        """
        Time:      7  15   30
        Distance:  9  40  200
        """;

    private const string Input =
        """
        Time:        48     87     69     81
        Distance:   255   1288   1117   1623
        """;
}
