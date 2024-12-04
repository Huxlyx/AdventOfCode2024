namespace AdventOfCode2024.Src;

internal class Day04 : IAoC
{
    public void Part1(IAoC aoc)
    {
        char[][] grid = aoc.GetContent().Select(x => x.ToCharArray()).ToArray();
        int findings = 0;
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] != 'X')
                {
                    continue;
                }

                bool canSearchUp = y >= 3;
                bool canSearchDown = y < grid.Length - 3;
                bool canSearchLeft = x >= 3;
                bool canSearchRight = x < grid[y].Length - 3;

                if (canSearchUp && FoundMas(grid, x, y, 0, -1))
                {
                    ++findings;
                }
                if (canSearchUp && canSearchRight && FoundMas(grid, x, y, 1, -1))
                {
                    ++findings;
                }
                if (canSearchRight && FoundMas(grid, x, y, 1, 0))
                {
                    ++findings;
                }
                if (canSearchDown && canSearchRight && FoundMas(grid, x, y, 1, 1))
                {
                    ++findings;
                }
                if (canSearchDown && FoundMas(grid, x, y, 0, 1))
                {
                    ++findings;
                }
                if (canSearchDown && canSearchLeft && FoundMas(grid, x, y, -1, 1))
                {
                    ++findings;
                }
                if (canSearchLeft && FoundMas(grid, x, y, -1, 0))
                {
                    ++findings;
                }
                if (canSearchLeft && canSearchUp && FoundMas(grid, x, y, -1, -1))
                {
                    ++findings;
                }
            }
        }
       
        Console.WriteLine(findings);
    }

    private static bool FoundMas(char[][] grid, int x, int y, int modx, int mody)
    {
        char[] mas = ['M', 'A', 'S'];
        int arrIdx = 0;
        for (int i = 0; i < mas.Length; i++)
        {
            x += modx;
            y += mody;
            if (grid[y][x] != mas[arrIdx++])
            {
                return false;
            }
        }
        return true;
    }

    public void Part2(IAoC aoc)
    {
        char[][] grid = aoc.GetContent().Select(x => x.ToCharArray()).ToArray();
        int findings = 0;
        for (int y = 1; y < grid.Length - 1; y++)
        {
            for (int x = 1; x < grid[y].Length -1; x++)
            {
                if (grid[y][x] != 'A')
                {
                    continue;
                }

                if ((grid[y - 1][x - 1] == 'M' && grid[y + 1][x + 1] == 'S')
                    || (grid[y - 1][x - 1] == 'S' && grid[y + 1][x + 1] == 'M')) {

                    if ((grid[y + 1][x - 1] == 'M' && grid[y - 1][x + 1] == 'S')
                        || grid[y + 1][x - 1] == 'S' && grid[y - 1][x + 1] == 'M')
                    {
                        ++findings;
                    }
                }
            }
        }

        Console.WriteLine(findings);
    }
}
