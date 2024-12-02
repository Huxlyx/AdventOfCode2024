using AdventOfCode2024.Src;
using System.Diagnostics;

namespace AdventOfCode2024
{
    internal class Program
    {
        static void Main()
        {
            Stopwatch sw = new();
            sw.Start();
            var aoc = new Day01();
            aoc.Part1(aoc);
            aoc.Part2(aoc);
            Console.WriteLine("Done after " + sw.Elapsed);
        }
    }
}