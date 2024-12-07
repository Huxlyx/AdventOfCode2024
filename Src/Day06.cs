namespace AdventOfCode2024.Src;

internal class Day06 : IAoC
{

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public void Part1(IAoC aoc)
    {
        char[][] grid = aoc.GetContent().Select(x => x.ToCharArray()).ToArray();

        int posX = 0;
        int posY = 0;

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == '^')
                {
                    grid[y][x] = '.';
                    posX = x;
                    posY = y;
                    break;
                }
            }
        }
        int distinctFields = 0;
        Direction dir = Direction.UP;
        while (true)
        {
            if (grid[posY][posX] != 'X')
            {
                ++distinctFields;
                grid[posY][posX] = 'X';
            }


            if (dir == Direction.UP)
            {
                if (posY == 0)
                {
                    break;
                }
                if (grid[posY - 1][posX] == '#')
                {
                    dir = Direction.RIGHT;
                }
            }
            else if (dir == Direction.RIGHT)
            {
                if (posX == grid[0].Length - 1)
                {
                    break;
                }
                if (grid[posY][posX + 1] == '#')
                {
                    dir = Direction.DOWN;
                }
            }
            else if (dir == Direction.DOWN)
            {
                if (posY == grid.Length - 1)
                {
                    break;
                }
                if (grid[posY + 1][posX] == '#')
                {
                    dir = Direction.LEFT;
                }
            }
            else if (dir == Direction.LEFT)
            {
                if (posX == 0)
                {
                    break;
                }
                if (grid[posY][posX - 1] == '#')
                {
                    dir = Direction.UP;
                }
            }

            switch (dir)
            {
                case Direction.UP:
                    --posY;
                    break;
                case Direction.DOWN:
                    ++posY;
                    break;
                case Direction.LEFT:
                    --posX;
                    break;
                case Direction.RIGHT:
                    ++posX;
                    break;
            }
        }

        AoCUtil.PrintGrid(grid);

        Console.WriteLine(distinctFields);
    }

    public void Part2(IAoC aoc)
    {
        char[][] grid = aoc.GetContent().Select(x => x.ToCharArray()).ToArray();

        int posX = 0;
        int posY = 0;
        int startX;
        int startY;

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == '^')
                {
                    grid[y][x] = '.';
                    posX = x;
                    posY = y;
                    break;
                }
            }
        }
        startX = posX;
        startY = posY;
        Direction dir = Direction.UP;
        HashSet<(int x, int y)> possibleObstacles = [];
        while (true)
        {
            if (posX != startX || posY != startY)
            {
                possibleObstacles.Add((posX, posY));
            }

            if (dir == Direction.UP)
            {
                if (posY == 0)
                {
                    break;
                }
                if (grid[posY - 1][posX] == '#')
                {
                    dir = Direction.RIGHT;
                }
            }
            else if (dir == Direction.RIGHT)
            {
                if (posX == grid[0].Length - 1)
                {
                    break;
                }
                if (grid[posY][posX + 1] == '#')
                {
                    dir = Direction.DOWN;
                }
            }
            else if (dir == Direction.DOWN)
            {
                if (posY == grid.Length - 1)
                {
                    break;
                }
                if (grid[posY + 1][posX] == '#')
                {
                    dir = Direction.LEFT;
                }
            }
            else if (dir == Direction.LEFT)
            {
                if (posX == 0)
                {
                    break;
                }
                if (grid[posY][posX - 1] == '#')
                {
                    dir = Direction.UP;
                }
            }

            switch (dir)
            {
                case Direction.UP:
                    --posY;
                    break;
                case Direction.DOWN:
                    ++posY;
                    break;
                case Direction.LEFT:
                    --posX;
                    break;
                case Direction.RIGHT:
                    ++posX;
                    break;
            }
        }

        int infiniteLoops = 0;

        foreach ((int x, int y) in possibleObstacles)
        {
            grid[y][x] = '#';
            if (InfiniteLoop(grid, startX, startY))
            {
                ++infiniteLoops;
            }
            grid[y][x] = '.';
        }

        Console.WriteLine(infiniteLoops);
    }

    private static bool InfiniteLoop(char[][] grid, int posX, int posY)
    {

        HashSet<(int x, int y, Direction dir)> tiles = [];

        Direction dir = Direction.UP;
        while (true)
        {

            if ( ! tiles.Add((posX, posY, dir)))
            {
                return true;
            }


            if (dir == Direction.UP)
            {
                if (posY == 0)
                {
                    break;
                }
                if (grid[posY - 1][posX] == '#')
                {
                    dir = Direction.RIGHT;
                    if (grid[posY][posX + 1] == '#')
                    {
                        dir = Direction.DOWN;
                    }
                }
            }
            else if (dir == Direction.RIGHT)
            {
                if (posX == grid[0].Length - 1)
                {
                    break;
                }
                if (grid[posY][posX + 1] == '#')
                {
                    dir = Direction.DOWN;
                    if (grid[posY + 1][posX] == '#')
                    {
                        dir = Direction.LEFT;
                    }
                }
            }
            else if (dir == Direction.DOWN)
            {
                if (posY == grid.Length - 1)
                {
                    break;
                }
                if (grid[posY + 1][posX] == '#')
                {
                    dir = Direction.LEFT;
                    if (grid[posY][posX - 1] == '#')
                    {
                        dir = Direction.UP;
                    }
                }
            }
            else if (dir == Direction.LEFT)
            {
                if (posX == 0)
                {
                    break;
                }
                if (grid[posY][posX - 1] == '#')
                {
                    dir = Direction.UP;
                    if (grid[posY - 1][posX] == '#')
                    {
                        dir = Direction.RIGHT;
                    }
                }
            }

            switch (dir)
            {
                case Direction.UP:
                    --posY;
                    break;
                case Direction.DOWN:
                    ++posY;
                    break;
                case Direction.LEFT:
                    --posX;
                    break;
                case Direction.RIGHT:
                    ++posX;
                    break;
            }
        }
        return false;
    }
}
