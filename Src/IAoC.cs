namespace AdventOfCode2024.Src
{
    internal interface IAoC
    {

        void Part1(IAoC aoc);
        void Part1Optimized(IAoC aoc) { }
        void Part2(IAoC aoc);
        void Part2Optimized(IAoC aoc) { }

        public string[] GetContent()
        {
            return File.ReadAllLines($"Res/{GetType().Name}.txt");
        }
    }
}
