using System.Diagnostics;

List<IDay> Days = new()
{
    new Day01(),
    new Day02(),
    new Day03(),
    new Day04(),
    new Day05(),
    new Day06(),
    new Day07(),
    new Day08(),
    new Day09(),
    new Day10(),
};

foreach (var day in Days)
{
    var sw = Stopwatch.StartNew();
    Console.WriteLine($"Day {day.Number}, part 1:\n{day.Part1()}\nTime: {sw.ElapsedMilliseconds}ms");
    sw.Restart();
    Console.WriteLine($"Day {day.Number}, part 2:\n{day.Part2()}\nTime: {sw.ElapsedMilliseconds}ms\n");
}
