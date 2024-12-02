namespace AdventOfCode2024.Src;

internal class Day01 : IAoC
{
    public void Part1(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        int[] arrLeft = new int[contentLines.Length];
        int[] arrRight = new int[contentLines.Length];

        for (int i = 0; i < contentLines.Length; ++i)
        {
            string[] parts = contentLines[i].Split("   ");
            arrLeft[i] = int.Parse(parts[0]);
            arrRight[i] = int.Parse(parts[1]);
        }
        Array.Sort(arrLeft);
        Array.Sort(arrRight);

        long totalDistance = 0;

        for (int i = 0; i < arrLeft.Length; ++i)
        {
            totalDistance += Math.Abs(arrLeft[i] - arrRight[i]);
        }

        Console.WriteLine(totalDistance);
    }

    public void Part2(IAoC aoc)
    {
        string[] contentLines = aoc.GetContent();

        Dictionary<int, int> occLeft = [];
        Dictionary<int, int> occRight = [];

        for (int i = 0; i < contentLines.Length; ++i)
        {
            string[] parts = contentLines[i].Split("   ");
            int left = int.Parse(parts[0]);
            int right = int.Parse(parts[1]);

            if (occLeft.TryGetValue(left, out int valueLeft))
            {
                occLeft[left] = ++valueLeft;
            }
            else
            {
                occLeft[left] = 1;
            }

            if (occRight.TryGetValue(right, out int valueRight))
            {
                occRight[right] = ++valueRight;
            }
            else
            {
                occRight[right] = 1;
            }
        }

        long similarity = 0;

        foreach (KeyValuePair<int, int> entry in occLeft)
        {
            if (occRight.TryGetValue(entry.Key, out int value))
            {
                similarity += entry.Key * entry.Value * value;
            }
        }

        Console.WriteLine(similarity);
    }
}
