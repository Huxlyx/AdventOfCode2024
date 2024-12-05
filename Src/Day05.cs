namespace AdventOfCode2024.Src;

internal class Day05 : IAoC
{
    public void Part1(IAoC aoc)
    {
        string[] lines = aoc.GetContent();

        int lineIdx = 0;
        bool[] rules = new bool[10_000];
        foreach (string line in lines)
        {
            ++lineIdx;
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
            int[] pages = line.Split('|').Select(int.Parse).ToArray();
            rules[pages[0] * 100 + pages[1]] = true;
        }

        int result = 0;

        for (int i = lineIdx; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            int[] nums = currentLine.Split(',').Select(int.Parse).ToArray();

            bool broken = false;

            for (int firstPage = 0; firstPage < nums.Length - 1 && ! broken; ++firstPage)
            {
                for (int secondPage = firstPage + 1; secondPage < nums.Length && ! broken; ++secondPage)
                {
                    if (rules[nums[secondPage] * 100 + nums[firstPage]])
                    {
                        broken = true;
                    }
                }
            }

            if ( ! broken)
            {
                result += nums[nums.Length >> 1];
            }
        }

        Console.WriteLine(result);
    }

    public void Part2(IAoC aoc)
    {
        string[] lines = aoc.GetContent();

        int lineIdx = 0;
        bool[] rules = new bool[10_000];
        foreach (string line in lines)
        {
            ++lineIdx;
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
            int[] pages = line.Split('|').Select(int.Parse).ToArray();
            rules[pages[0] * 100 + pages[1]] = true;
        }

        int result = 0;

        for (int i = lineIdx; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            int[] nums = currentLine.Split(',').Select(int.Parse).ToArray();

            bool broken = false;
            for (int firstPage = 0; firstPage < nums.Length - 1; ++firstPage)
            {
                for (int secondPage = firstPage + 1; secondPage < nums.Length; ++secondPage)
                {
                    if (rules[nums[secondPage] * 100 + nums[firstPage]])
                    {
                        (nums[secondPage], nums[firstPage]) = (nums[firstPage], nums[secondPage]);
                        broken = true;
                    }
                }
            }
            if (broken)
            {
                result += nums[nums.Length >> 1];
            }
        }

        Console.WriteLine(result);
    }
}
