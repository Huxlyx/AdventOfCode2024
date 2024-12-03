using System.Text.RegularExpressions;

namespace AdventOfCode2024.Src;

internal class Day03 : IAoC
{
    public void Part1(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        string pattern = @"mul\(\d{1,3},\d{1,3}\)";

        long result = 0;

        foreach (string line in contentLines)
        {
            foreach (Match match in Regex.Matches(line, pattern))
            {
                Console.WriteLine(match.Value);
                string[] parts = match.Value[4..^1].Split(',');

                result += int.Parse(parts[0]) * int.Parse(parts[1]);

            }
        }
        Console.WriteLine(result);
    }

    public void Part2(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        string pattern = @"(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))";

        long result = 0;
        bool doMul = true;
        foreach (string line in contentLines)
        {
            foreach (Match match in Regex.Matches(line, pattern))
            {
                Console.WriteLine(match.Value);
                if (match.Value == "do()")
                {
                    doMul = true;
                }
                else if (match.Value == "don't()")
                {
                    doMul = false;
                }
                else if (doMul)
                {
                    string[] parts = match.Value[4..^1].Split(',');
                    result += int.Parse(parts[0]) * int.Parse(parts[1]);
                }

            }
        }

        Console.WriteLine(result);
    }
}
