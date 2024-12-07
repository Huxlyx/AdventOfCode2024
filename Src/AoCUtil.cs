namespace AdventOfCode2024.Src
{
    internal static class AoCUtil
    {
        internal static long LCMOfArray(int[] numbers)
        {
            long result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                /* GCD */
                long a = result;
                long b = numbers[i];
                while (b != 0)
                {
                    long temp = b;
                    b = a % b;
                    a = temp;
                }

                result = result * numbers[i] / a;
            }

            return result;
        }

        internal static void PrintGrid(char[][] grid)
        {
            Console.WriteLine();
            foreach (char[] line in grid)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }
    }
}
