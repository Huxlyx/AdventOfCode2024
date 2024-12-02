namespace AdventOfCode2024.Src;

internal class Day02 : IAoC
{
    public void Part1(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        int safeReports = 0;
        foreach (string line in contentLines)
        {
            int[] nums = line.Split().Select(int.Parse).ToArray();

            bool ascending = nums[0] < nums[1];
            bool correct = true;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int diff = Math.Abs(nums[i] - nums[i + 1]);

                if (diff < 1 || diff > 3
                    || (ascending && nums[i] > nums[i + 1]) 
                    || ( ! ascending && nums[i] < nums[i + 1]))
                {
                    correct = false;
                    break;
                }
            }

            if (correct)
            {
                ++safeReports;
            }
        }

        Console.WriteLine(safeReports);
    }

    public void Part2(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        int safeReports = 0;
        foreach (string line in contentLines)
        {
            int[] nums = line.Split().Select(int.Parse).ToArray();
            int offendingIndex = GetOffendingIndex(nums);

            if (offendingIndex == -1)
            {
                ++safeReports;
            }
            else 
            {
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (GetOffendingIndex(nums, i) == -1)
                    {
                        ++safeReports;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(safeReports);
    }

    private static int GetOffendingIndex(int[] nums, int skip = -1)
    {
        if (skip != -1)
        {
            int[] nums2 = new int[nums.Length - 1];
            int idx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == skip)
                {
                    continue;
                }
                nums2[idx++] = nums[i];
            }
            nums = nums2;
        }

        bool ascending = nums[0] < nums[1];

        for (int i = 0; i < nums.Length - 1; i++)
        {
            int diff = Math.Abs(nums[i] - nums[i + 1]);

            if (diff < 1 || diff > 3 
                || (ascending && nums[i] > nums[i + 1]) 
                || ( ! ascending && nums[i] < nums[i + 1]))
            {
                return i;
            }
        }
        return -1;
    }
}
