﻿public class Day13 : IDay
{
    public string Number => "13";

    public string Part1() => $"Test: {Impl1(Test)} (verwacht 405)\nReal: {Impl1(Input)} (correct 34202)";

    public string Part2() => $"Test: {Impl2(Test)} (verwacht ???)\nReal: {Impl2(Input)} (correct ???)";

    private string Impl1(string input)
    {
        var vertical = 0;
        var horizontal = 0;
        foreach (var grid in ParseInput(input))
        {
            var possibleH = Enumerable.Range(1, grid.GetLength(1) - 1).ToList();
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 1; y < grid.GetLength(1); y++)
                {
                    if (!possibleH.Contains(y))
                    {
                        continue;
                    }
                    var isValid = true;
                    for (var y2 = 0; y - y2 >= 1 && y + y2 < grid.GetLength(1); y2++)
                    {
                        if (grid[x, y + y2] != grid[x, y - 1 - y2])
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        possibleH.Remove(y);
                    }
                }
            }

            var possibleV = Enumerable.Range(1, grid.GetLength(0) - 1).ToList();
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 1; x < grid.GetLength(0); x++)
                {
                    if (!possibleV.Contains(x))
                    {
                        continue;
                    }
                    var isValid = true;
                    for (var x2 = 0; x - x2 >= 1 && x + x2 < grid.GetLength(0); x2++)
                    {
                        if (grid[x + x2, y] != grid[x - 1 - x2, y])
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        possibleV.Remove(x);
                    }
                }
            }
            horizontal += possibleH.Sum();
            vertical += possibleV.Sum();
        }
        return (100 * horizontal + vertical).ToString();
    }

    private string Impl2(string input)
    {
        return "";
    }

    private List<bool[,]> ParseInput(string input)
    {
        var result = new List<bool[,]>();
        foreach (var part in input.Split(Environment.NewLine + Environment.NewLine))
        {
            var lines = part.Split(Environment.NewLine);
            var grid = new bool[lines[0].Length, lines.Length];
            for (var y = 0; y < lines.Length; y++)
                for (var x = 0; x < lines[0].Length; x++)
                    grid[x, y] = lines[y][x] == '#';
            result.Add(grid);
        }
        return result;
    }

    private const string Test =
        """
        #.##..##.
        ..#.##.#.
        ##......#
        ##......#
        ..#.##.#.
        ..##..##.
        #.#.##.#.

        #...##..#
        #....#..#
        ..##..###
        #####.##.
        #####.##.
        ..##..###
        #....#..#
        """;

    private const string Input =
        """
        #..##..
        #.##.##
        #####..
        #..#.#.
        .####..
        #.#.#..
        #.#.#..
        
        ##.##.###
        ##.##.###
        ..####..#
        ###.#.###
        ###.#..#.
        #.###....
        ###.#...#
        ###.#...#
        #.###....
        ###.#..#.
        ###.#.###
        ..##.#..#
        ##.##.###
        
        ..####.
        #......
        .##..##
        #.#..#.
        #......
        #.#..#.
        #.#..#.
        #......
        ###..##
        .##..##
        #......
        
        #..####..#..#..
        .###..###.##.##
        .#......#.####.
        ###....########
        ##......######.
        ..##..##..##..#
        .#..##..#.##.#.
        .###..###.##.##
        #..####..####..
        ..#....#..##..#
        .########....##
        #..####..####..
        #.######.#..#.#
        ###.##.########
        .#.#..#.#.##.#.
        ....##.........
        #.##..##.#..#.#
        
        #..###..#..
        #..###..#..
        ###.#####..
        #####.##..#
        #.#.#....##
        .##..##....
        #.#...##.#.
        ####...####
        ####...####
        #.#...##.##
        .##..##....
        #.#.#....##
        #####.##..#
        
        ...#...#.#.##
        ##....#.##.#.
        ##..#.#.#....
        ...##.#####..
        ###..#...#...
        ###.#....###.
        ##..####....#
        ...#.####...#
        ##...##.###.#
        ##...##.###.#
        ..##.####...#
        ##..####....#
        ###.#....###.
        ###..#...#...
        ...##.#####..
        ##..#.#.#....
        ##....#.##.#.
        
        ###.##..#
        #####....
        #####....
        ##....##.
        ####.#..#
        ...#.....
        .#.######
        
        ##..####.###.
        ###.##..##...
        ...####.#..##
        ...####.#..##
        ######..##...
        ##..####.###.
        #.##...##..#.
        .#..##..##..#
        .#..##..##..#
        #.##...##..#.
        ##..####.###.
        ######..##...
        ...####.#..##
        ...####.#..##
        ###.##..##...
        ##..####.###.
        .##.#.....#.#
        
        ...#.#..##..#.#
        .###..#.##.#..#
        ..##..######..#
        ..#.##......##.
        #.###.##..##.##
        .....#......#..
        .....#......#..
        #.###.##..##.##
        ..#.##......##.
        ..##..######..#
        .###..#.##.#..#
        ...#.#..##..#.#
        .##.##......##.
        ..#...#....#...
        .#...#########.
        
        ###.######.
        #.#..#...#.
        .###...#.##
        ###.#.##...
        ##.##...#.#
        ##.##...#.#
        ###.#.##...
        .###..##.##
        #.#..#...#.
        ###.######.
        ###.######.
        #.#..#...#.
        .###..##.##
        
        ######.
        ..###..
        .#.##.#
        #....#.
        #....#.
        .#.##.#
        ..###..
        ######.
        #####..
        
        ##....#.#
        ##..#.#.#
        .#...###.
        #..#.....
        .##.....#
        #.#.#..#.
        .##..###.
        ##...####
        ##.#####.
        ##.###...
        .####....
        .####....
        ##.###...
        
        #...##.#...#.#.
        #.#######...###
        ###..##....##.#
        ....#.#.###...#
        ....#.#.###...#
        ###...#....##.#
        #.#######...###
        #...##.#...#.#.
        .###...##.##...
        .###...##.##...
        #...##.#...#.#.
        
        ###..#.
        ###..#.
        .####..
        .##....
        ###..#.
        .####.#
        .##..#.
        .##.###
        #####..
        #..#...
        .#..##.
        .#..##.
        #..##..
        
        .#####.#...#..#..
        .#####.#...#..#..
        #.#.##...#...##.#
        ##...##.##..###.#
        ....#..####....##
        ....#..#.##....##
        ##...##.##..###.#
        
        #####.#.#
        #...##..#
        #######.#
        ######.##
        .##.#..##
        #####..#.
        #..###.##
        #..#.##..
        .##....##
        #####.###
        #####.###
        .##....##
        #..#.##..
        #..###.##
        #####..#.
        
        ..#....#####.
        ..#.##.####.#
        ##.##.######.
        ....####..###
        ########..###
        ....#.##..##.
        ##.#.########
        ......#.##.#.
        ..#..##....##
        
        ##..#..#.#.#.
        ##..#..#.#.#.
        ##.#.##.....#
        .#.#.##..###.
        ..#...####..#
        #.....#..####
        #..#..#..####
        ..#...####..#
        .#.#.##..###.
        
        .#..##..#..##..#.
        #........######..
        ##########.##.###
        .#..##..#.####.#.
        ....##....#..#...
        ###....###.....##
        .###..###......##
        #..#..#..######..
        ##......########.
        ###.##.###.##.###
        ##..##..##....##.
        #.######.#.##.#.#
        .#......#.####.#.
        ####..#####..####
        ##.####.###..###.
        
        .##...##...
        #...#....#.
        #..########
        .##.#....#.
        #..##....##
        #..##....##
        ......##...
        
        ....#####.##.
        #####.#.##.##
        ....#.##.#..#
        .....#...#..#
        ####..####..#
        #########..##
        #######.....#
        #######.#.###
        ....#.#....#.
        ....##....###
        .##...####..#
        
        #....#.###..###.#
        ##..##.##.##.##.#
        .####.#........#.
        ..##..##.####.##.
        #.##.####....####
        ....#..#.#..#.#..
        #....###.#..#.###
        .......#.####.#..
        #.##.#...#..#...#
        #.##.#.##....##.#
        .#..#..#.####.#..
        #.##.#.#.####.#.#
        .####.###.##.###.
        
        .....#..#.....###
        ...#.#..#.#....##
        #####.##.######..
        .#..######..#....
        .##.##..##.##.#..
        .###.####.###..##
        #.#........#.###.
        .#..#.##.#..#.#..
        ....#.##.#.....##
        ####......#######
        #.#.#....#.#.#...
        .###.#..#.###....
        ####..##..####.##
        
        ##..####...#.
        ##..##.#.#..#
        ######.###...
        .......#....#
        #....###....#
        .......#..#..
        ..##....#.#.#
        
        .#.........
        ..#.#######
        ##.##...##.
        ###.####...
        ###.####...
        ##.##...##.
        ..#.#######
        .#.........
        .###.###..#
        ####.#.##.#
        #.####.#..#
        #.####.##.#
        ####.#.##.#
        .###.###..#
        .#.........
        
        ####....##....#
        ...#....##....#
        .##...#....#...
        #..#.##.##.##.#
        .###.##.##.##.#
        .###.##.##.##.#
        ##.############
        
        ....######.....
        #....#..#....##
        ..##..##..##...
        ..##########...
        ..##.####.##...
        ..####..####...
        .##.....#..##..
        ####..##..#####
        #.##########.##
        #.##..##..##.##
        .###.#..#.###..
        #.#.#....#.#.##
        #...##..##...##
        
        .......#.
        #..#.#..#
        .#####.##
        ####..#.#
        #####.#..
        .##.##.#.
        .##.##.#.
        #####.#..
        ####..#.#
        
        .#..#..#..###..#.
        #.##.#.####..##..
        ######.##.###.#..
        ######.##.###.#..
        #.##.#.####..##..
        .#..#..#..###..#.
        #....#..#..##.#..
        #....####..#####.
        ..##..#...##..#..
        ###############..
        ...#..####.#.##.#
        
        .##..######
        ....#######
        .##.#...#.#
        #####.###.#
        ######.##.#
        ....###....
        .....#...#.
        #..###..###
        .....##...#
        .##..##...#
        #..#...##.#
        .##....#.##
        .##...##.##
        #..#...##.#
        .##..##...#
        
        #....#..####..#..
        #.....###..###...
        .#.#..##....##..#
        ##..#...####...#.
        .##.##.....#..##.
        ..#.#..#....#..#.
        #.#######..######
        .#...#..####..#..
        .#..##.#....#.##.
        .#.####......####
        .#.####......####
        
        ......##.##.##.
        ..####.#....###
        ....##........#
        #####..#....#..
        ........####...
        ..###..######..
        ...##..######..
        ...#..###..###.
        #####..#.##.#..
        ###..#..####..#
        ..#.###.#..#.##
        
        #.....##.....
        .###..##..###
        .##..#..#..##
        ###.#....#.##
        ###...##...##
        .###..##..###
        ....##..##...
        #............
        ##.##....##.#
        .##..#..#..##
        .####....####
        
        #...#.#.##...
        ...###.##..##
        ..###.#.##...
        .###.###...#.
        ##.#...#.###.
        #...###.#.#.#
        ..#####...#.#
        ..#####...#.#
        #...###.#.#.#
        ##.#...#.###.
        .###.###...#.
        ..###.#.##...
        ...#.#.##..##
        #...#.#.##...
        .#.#....####.
        .#.#....####.
        #...#.#.##...
        
        ..#..#.#..##..#
        #..#.#....##...
        .#.#####......#
        #..###.###..###
        ##.#...###..###
        ..##.##....#...
        #..###.##....##
        ...####.######.
        ...####.######.
        
        .#.##.#.##.#.
        .#.####....##
        .##...######.
        .##...######.
        .#.####....##
        .#.##.#.##.#.
        .#######..###
        #..####....##
        ..###.#...##.
        ..###..#..#..
        #..#.########
        
        ....#..#.
        ####.#.#.
        ...###.##
        ..#..##.#
        ##...#...
        ##.##.#..
        ##.....#.
        ##...##.#
        ...####.#
        .#...####
        ####...#.
        ###..###.
        ..#####.#
        ..#..##.#
        ..#..##.#
        
        ##.#.#..##..##.#.
        .###.##.#....###.
        #..#.#.#.##.#.###
        #....#.########.#
        .....#..#.###.##.
        #....###....#####
        .###....###...###
        .###....###...###
        #....###....####.
        ..####.###..##..#
        ..####.###..##..#
        #....###....####.
        .###....###...###
        .###....###...###
        #....###....#####
        
        .###.##.###..
        .##.####.##..
        ..########...
        .#..####..#..
        ..#.#..#.#...
        .#.#....#.#..
        ..##.##.##...
        #.##....##.##
        .##.####.##..
        #.##....##.##
        ..#..##..#...
        #.#.#..#.#.##
        .#........#..
        #....#.....##
        .###....###..
        
        ..##.#..#.#
        ..##.##...#
        ..##..#...#
        ..##.#..#.#
        ##.#..####.
        ...#..#.#.#
        ...###.#.##
        ###.##..###
        ##..##.##..
        ...##..#..#
        ..###.##.#.
        ##...###..#
        ..#..####.#
        
        ##.##.#.##....#
        .........##.#..
        ....#...###.#.#
        ####..#.####.##
        .#..##...##.##.
        #.#.##.#####.#.
        .#.#.#...#..###
        #..#.####..##.#
        #..#.#.###.##.#
        ##..#.##..#####
        #...#.##..#####
        .#..#####..##.#
        ..#...#.######.
        ..#...#.######.
        .#..#####..##.#
        #...#.##..#####
        ##..#.##..#####
        
        .#..###.##.
        ..#.####..#
        ####...#..#
        ...#.##....
        ###.####..#
        #####...##.
        ###.#..####
        ##.#.#.####
        ....#.#.##.
        ..##.###..#
        ..####.....
        
        #.##.#.###.##..
        ####.##.#..#..#
        #..#.#.####...#
        #..##.##.####..
        #..######...##.
        .....##.####..#
        ####.##..######
        #######..#..#.#
        #..##.#.#.##...
        .##...#.#.#....
        ....#..#...##.#
        #..#...##.#.#..
        .##...#..##.#.#
        ####....#.#.#..
        #####.###.####.
        ......##.#....#
        ......##.#....#
        
        #.###.##.###.#.
        #.###.##.###.#.
        ...#.#..#.#...#
        ##.##.##.##.##.
        .##.#.##.#.##..
        #.#........#.#.
        .#.#.####.#.#..
        ....#....#.....
        .############..
        #.##..##..##.##
        .#####..#####.#
        #....#..#......
        .#..#....#..#.#
        #..#.#..#.#..##
        ##....##....###
        
        ...###.
        ....##.
        ...#..#
        ...##.#
        ..#####
        #.#.##.
        .#..##.
        .#..##.
        #.#.##.
        ..#####
        ...##.#
        ...#..#
        ....##.
        
        #.#......
        ..#.#..#.
        ..###..##
        ##...##..
        ###.##.#.
        .#.##..##
        ###......
        ##.......
        ##...##..
        ##...##..
        ##.......
        
        ...#.#.
        ###..##
        #...#..
        ..#.#..
        ..#.#..
        #...#..
        ###..##
        ...#.#.
        .######
        .######
        ...###.
        
        #...#.#####....##
        #.####..##......#
        ######.####....##
        ###.##.#.#.####.#
        .#.#.##...#....#.
        .##......#.####.#
        ..######...####..
        #..#..##....##...
        ###.#..#.........
        #....##...##..##.
        .#.####.##.#..#.#
        #..#...#..##..##.
        #.#..###...####..
        #...#...##.#..#.#
        #...##.#...####..
        #...##.#...####..
        #...#....#.#..#.#
        
        ##.....##..###.
        #......##..###.
        #..##..##.###..
        ......#...#####
        .#####....##.##
        ..#...#.##....#
        .##.#.###.#...#
        .##.#.###.#...#
        ..#...#.##....#
        .#####....##.##
        ......#...#####
        
        #.##....##.##
        .###....###..
        #.#..##..#.##
        .###....###..
        ...######....
        .##########..
        ...#....#....
        .##.#..#.##..
        #.##....##.##
        #..........##
        #...#..#...##
        ##...##...#..
        .#..####..#..
        
        ####.###.#...
        ####.###.#...
        .##.#....#.##
        ######..#.###
        ######.#.#.#.
        #..#..##..#..
        .##....##.###
        .....##.#.##.
        #..####..#.##
        #....##.####.
        .##..##.#..#.
        .##..#..##...
        ####.##..##.#
        ....#.##.#..#
        ....######..#
        ......##..#.#
        ####..#.##..#
        
        #.##.##.##.##.##.
        .###....###......
        ##..#..#..##.#..#
        .#.#....#.#.##..#
        ##.##..##.##..##.
        ##.#....#.##..##.
        .#.##..##.#.#.##.
        #.########.#.....
        ##.#.##.#.####..#
        ..##.##.##..##..#
        .##########......
        .#.##..##.#..####
        ...######.....##.
        ###.####.###.....
        .#.######.#..####
        .###.##.##...####
        .#.#....#.#..####
        
        ####.###.
        ....##...
        ......###
        ....###..
        #..##..#.
        ######...
        ######...
        #..##..#.
        ....###..
        ......###
        ....##...
        ####..##.
        .##.#.##.
        ####...##
        #..##.##.
        ......###
        #####....
        
        ##..####..##.
        ##.######.##.
        .....##.....#
        ##.#.##.#.###
        ##.##..##.##.
        .#.#....#.#..
        ##...##...##.
        #####..######
        ##..####..###
        ##...##...##.
        ..########..#
        ##.#.##.#.###
        ##...##...###
        ####.##.#####
        ##.#.##.#.##.
        ##.######.##.
        ..#.####.#..#
        
        #.##.##......##.#
        #.##.##......##.#
        .#.##..##......#.
        #.##..##..##...#.
        ##....#...#....##
        .#.###..###......
        ##.##..#....##.##
        ##.##..#....##.##
        .#.###..###......
        ##....#...#....##
        #.##..#...##...#.
        .#.##..##......#.
        #.##.##......##.#
        
        .#..#..
        .##.##.
        .###..#
        ##.####
        ##.####
        .###..#
        .##.##.
        .#..##.
        #..###.
        ..#.###
        #.#....
        ###...#
        ###...#
        #.#....
        ..#.###
        
        ...##...####.
        ####.........
        ..#..###.##.#
        ###..#.######
        ##..#########
        ###..........
        ..#..##......
        ##...#..#..#.
        ....##.###.##
        ..#..########
        ....#.#......
        ##.#.########
        ..###........
        ###.#########
        ...#...######
        ..#.#.#######
        #####..#....#
        
        ....#...#
        #.#.#.#..
        #.#.#.#..
        .#..#...#
        ##.#.####
        ..##.#.#.
        .....#...
        #####...#
        ####...#.
        ##....#.#
        ..#...###
        ..#...###
        ##....#.#
        
        ....#...#
        ####.##.#
        .##.##...
        ####....#
        .##..####
        .##...###
        ####....#
        
        ##.#..#
        ####..#
        ###.#..
        ##..##.
        ##..##.
        ..#.#..
        ####..#
        
        .....#..#
        ###......
        #.#######
        #.#######
        ..##.....
        ##.######
        ..#######
        .########
        ...##....
        
        ##.#..#.#
        .#.#.##..
        ##.##..##
        ....###.#
        ....###.#
        ##.##..##
        .#.#.##..
        ##.#..###
        ..###....
        .##..####
        .##..####
        ..###....
        ##.#..###
        
        ......##.#.
        #####.#.##.
        .##.#.#####
        .....##.#.#
        ....##.#.##
        #..#.##.#.#
        #..#.##.#.#
        ....#..#.##
        .....##.#.#
        .##.#.#####
        #####.#.##.
        ......##.#.
        .......##.#
        #..###..#..
        .##..##.###
        
        .#.#.#..#
        #..#..##.
        ##..##..#
        ##.##.##.
        #.#.##.##
        ....#####
        #...#....
        .#.#.....
        .####....
        ..#......
        ..#......
        .####....
        .#.#.....
        
        ......###..
        ..###.#.#..
        #......#.##
        .####..#.##
        ##.###.#...
        ##.####....
        .#....#..##
        ##.##..#...
        #.#.###....
        ..#..######
        ..#..######
        #.#.###....
        #####..#...
        .#....#..##
        ##.####....
        ##.###.#...
        .####..#.##
        
        .####..##
        ##..##..#
        #....###.
        #....###.
        ##..###.#
        .####..##
        .#..#.#.#
        ######.##
        .####..#.
        
        ###.#..#.
        ###.#..#.
        .#..#.#.#
        ###..##..
        ..#.###.#
        ...#.####
        .###..###
        #...#.###
        #...#.###
        .#.#..###
        ...#.####
        ..#.###.#
        ###..##..
        .#..#.#.#
        ###.#..#.
        
        #..#...#..#.#.#
        #..###......###
        .....########..
        #..###.####.###
        ........##.....
        #..###......###
        ....#...##...#.
        ####.##.##.##.#
        #..##.#.##.#.##
        ####....##....#
        ####.#..##..#.#
        ......##..##...
        .##.##.####.##.
        
        #...##...#...
        ######...##.#
        #.####...##.#
        .#.######.#..
        .##...##.#.#.
        .##...##.#.#.
        .#.######.#..
        #.####...##.#
        ######...##.#
        
        ...###..#.#...#
        ##.#..###.#..#.
        ...######.##.##
        ...######.##.##
        ##.#..###.#..#.
        ...###..#.#...#
        ..#..#.##.##.#.
        ..#.#.##.#...##
        ...##....#....#
        ##.###..#...#.#
        .#..###..###.##
        ..##.###..#..#.
        ..#..#####.##.#
        ##.##.#.####.#.
        ####...####.##.
        ##..#.#..#.#...
        ..#.#.#.#.#.##.
        
        ..##.#.#.##
        .###.#.#.##
        .#..#......
        ####.##.#.#
        #.#..##..##
        .##..#.#.#.
        ###........
        ##....#.##.
        .###.####.#
        ......#.##.
        ##.#..##.#.
        #...##.#...
        ..#..####.#
        ..#..####.#
        #...##.#...
        
        #.########.#..#..
        #.########.#..#..
        ##.#.##.#.###.#.#
        #..##..##..#.###.
        ....#..##........
        #....##....##.#..
        ###......###..#.#
        #.###..###.##....
        ..##.##.##..#.#..
        #..######..#..##.
        ..###..###.......
        ##..#..#..##.###.
        ##.######.###.###
        #....##....#...#.
        ...##..##...#.###
        
        #####.####.
        ##..#..#.#.
        ##..###....
        ###.###.#.#
        ....####.#.
        ..####.#.#.
        ######..#..
        ######..#..
        ..####.#.#.
        ....####.#.
        ###.###.#.#
        ##..###....
        ##..#..#.#.
        #####.####.
        ###.#.####.
        ...###.#.#.
        .###.###...
        
        ..##.#.####.#.##.
        ..##.#.####.#.##.
        .##.#.##..##.#.##
        .#.#..######.##.#
        #...###....###...
        ##.############.#
        ..##############.
        ...#####..#####..
        #.#....####....#.
        ##..##......##..#
        .#.##..####..##.#
        #.##.#.#..#.#.##.
        ..#..#.#..#.#..#.
        .##.##..##..##.##
        #.##.#.#..#.#.##.
        
        ####.##.#
        .....####
        ........#
        #..#.##..
        ....#.##.
        .##.##.##
        .##.##..#
        
        ##.##..##.#####
        ##..#..#..###..
        .#.#.##.#.#.###
        .#.#.##.#.#..##
        .#..#..#..#.#.#
        ##..#..#..##...
        .#...##...#.###
        ..#.####.#..#..
        ##.#.##.#.##.##
        .###....###....
        ##........###..
        
        .#.####.#.##.#.
        ##......######.
        ##########..###
        #...##..##..##.
        .#.#..#.#.##.#.
        ..######..##..#
        ##.#..#.##..##.
        
        .#.#####.#.####
        #...##..#######
        ..#...##.......
        ##......#..####
        .####.##.######
        .###..#########
        ##.##.#.##.....
        ###.#.##.##.##.
        ..#.###...#....
        ..#.#...#.#....
        .#.#.....######
        #####.###.#####
        ..#..##.##.####
        .#..#....#.####
        .#....#.#.#....
        
        #.#.####.#.
        .#.##..##.#
        #...#..#...
        ####....###
        ...#.##.#..
        ...##..##..
        ...##..##..
        ...#.##.#..
        ####....###
        #...#..#...
        .#.##..##.#
        #.#.####.#.
        .....##....
        ..##....##.
        ###.#######
        .#.#.##.#.#
        ####.##.###
        
        ##..##..##..###
        ##.###..###.##.
        ###.#.##.#.####
        ###.#.##.#.####
        ##.###..###.##.
        ##..##..##..###
        #..###..###..##
        ..#.##..##.#...
        #.#..##.#..#.##
        
        ....##...#.###.#.
        ####.#...##.###..
        .##.####.##.##.##
        ####.#.##...#.#.#
        ....###.#.####..#
        #..###.##.#.#.#..
        #..###.#..##..#.#
        .##...###...###.#
        .##.##.###...#.#.
        .##.##.###...#.#.
        .##...###...###.#
        #..###.#...#..#.#
        #..###.##.#.#.#..
        
        #######.##.#....#
        #.##..#..##......
        ..#..####...##...
        ######..#...#...#
        ...#....#.#.##...
        .#..##....#.##..#
        #..#.##.###.###.#
        ...#.###......#..
        #.##.#.##..#..###
        ####..######.##.#
        ####..######.#..#
        #.#.##.#.##.#....
        #.#.##.#.##.#....
        ####..######.#..#
        ####..######.##.#
        
        .#.####.#.#.##.
        .#.####.#..###.
        .#..##..#.#.###
        ##......##.##.#
        ##.####.####.##
        ..##..##..#.###
        ..##..##..#####
        
        #.#####..#.#.#...
        ..##..##.#.####..
        ..#.##.#.#.#..#..
        .#.##.#.#...#.###
        .##..##.....#####
        .###...#.#..#....
        #..#..##....#.###
        .#.###.....##....
        ..#.#####.##..#..
        .....###...###.##
        .....###...###.##
        ..#.#####.##..#..
        .#.###.....##....
        #..#.###....#.###
        .###...#.#..#....
        
        ##.####..##
        .#...#.##.#
        .#..#.#..#.
        .###.......
        ####.#.##.#
        ##.#.#.##.#
        .###.......
        .#..#.#..#.
        .#...#.##.#
        ##.####..##
        ####.######
        #..####..##
        ###..######
        #####.####.
        .#...######
        ####...##..
        #.#########
        
        #.##..##.#..#
        #.######.#.##
        ..#....#..###
        #........####
        .#.####.#....
        ##..##..#####
        ##..##..###..
        ..........###
        ####..####...
        ##..##..###..
        ####..#######
        
        #.##..####.##.#
        .###.####.#.##.
        ..#.#.##.#...##
        ....#.##....###
        #.#.##.#####.##
        ..#....#.....##
        ..#....#.....##
        #.#.##.#####.##
        ....#.##....###
        ..#.#.##.#...##
        .###.####.#.##.
        #.##..####.##.#
        ##...##.#.###..
        ##...##.#.###..
        #.##..####..#.#
        .###.####.#.##.
        ..#.#.##.#...##
        
        #######.#..
        #.##.#....#
        ......##...
        ##..######.
        ..##...#.#.
        .####..##..
        #....#.##..
        .#..#.#..##
        .......#.#.
        ......##.#.
        .#..#.#..##
        
        #..#..#.####.
        .##.###......
        ..#..##.#..##
        #..#######..#
        #####....####
        #..##.#.##..#
        ####.###..##.
        ######.#..#.#
        ....###.##.##
        ......#......
        #..#..#.##...
        ####.##...##.
        ####.##...##.
        
        ###..####
        .#...#.##
        #..###.##
        #.#.##...
        ..#.#####
        ####..#..
        .##.##.##
        #.##.....
        #.###....
        
        .####.#
        .####.#
        .#.#.#.
        .....#.
        ##..#..
        ...###.
        ...###.
        ##..#..
        .#...#.
        .#.#.#.
        .####.#
        
        ..#..##.#........
        ##.##.#...###..##
        ##.##.#...###..##
        ..#..#..#........
        #..##.###..######
        ###.##.##.#######
        ..#...#.##...##..
        .#....#.#........
        ##.#.####..#....#
        #.#.##....#######
        .#####...#.......
        ##.####.#.###..##
        #.######.###.##.#
        #.#.#.####.#....#
        ...#######.######
        
        .##..##
        #..##..
        #..#.##
        ....#..
        ....#..
        #..#.##
        #..##..
        .##..##
        ######.
        ####..#
        ...#.#.
        
        .##.#.####.
        .##.#.####.
        .####..#.##
        .#####.#.#.
        #.#..#.###.
        ##.#######.
        ..####....#
        #.##..###.#
        #.##..###.#
        ..##.#....#
        ##.#######.
        #.#..#.###.
        .#####.#.#.
        .####..#.##
        .##.#.####.
        
        ..#......#....#
        .####..####..##
        #.#.####.#.##..
        .#.######.#..#.
        #.########.##.#
        #....##....##..
        ...##..##......
        
        #.##...##
        ..#.#.###
        ##...####
        .###.....
        .###.....
        ##...####
        ..###.###
        #.##...##
        ####.####
        .####.#.#
        #..#.#.##
        ######.#.
        ..######.
        ##.##.###
        ##.##.###
        
        #....#..#....#.##
        .###......###.#..
        .#..######..#..##
        .#.#.####.#.#....
        .#.##....##.#..##
        ...##.##.##....##
        ...###..###....##
        ###..####..###...
        ..#.#.##.#.......
        ...########......
        ######..#########
        ..##..##..##.....
        .....####.....###
        #.##.#..#.##.##..
        .#...#..#...#..##
        
        ...##.#
        ...###.
        ###.###
        ###.###
        ...###.
        ...##.#
        ###..#.
        .####..
        .#.....
        #.#....
        #.#....
        .#.....
        .####..
        ###..#.
        ..###.#
        
        #.#....#...
        #.#.#..#...
        #.#.#..#...
        #.#....#...
        ###.....#.#
        ..#.#....##
        #..#.##...#
        
        #.##.##########
        .####.###....##
        .........####..
        #....#.#.....##
        .#..#.###.##.##
        #....#.#.#..#.#
        .#..#.#########
        ......##.####.#
        ..##...###..###
        """;
}