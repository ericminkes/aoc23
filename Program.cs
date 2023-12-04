List<IDay> Days = new()
{
    new Day01(),
};

foreach (var day in Days)
{
    Console.WriteLine($"Day {day.Number}, part 1: {day.Part1()}");
    Console.WriteLine($"Day {day.Number}, part 2: {day.Part2()}");
    Console.WriteLine();
}
