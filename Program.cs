List<IDay> Days = new()
{
    new Day01(),
    new Day02(),
    new Day03(),
};

foreach (var day in Days)
{
    Console.WriteLine($"Day {day.Number}, part 1:\n{day.Part1()}");
    Console.WriteLine($"Day {day.Number}, part 2:\n{day.Part2()}\n");
}
