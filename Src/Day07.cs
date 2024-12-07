
namespace AdventOfCode2024.Src;

internal class Day07 : IAoC
{
    public void Part1(IAoC aoc)
    {
        string[] lines = aoc.GetContent();

        long calibrationResult = 0;

        foreach (string line in lines)
        {
            long result = long.Parse(line[..line.IndexOf(':')]);
            long[] operands = line[(line.IndexOf(':') + 2)..].Split().Select(long.Parse).ToArray();

            int max = 1 << operands.Length - 1;

            for (int opMask = 0; opMask < max; opMask++)
            {
                long currentResult = operands[0];

                for (int i = 1; i < operands.Length; i++)
                {
                    if (((opMask >> i - 1) & 1) > 0)
                    {
                        currentResult += operands[i];
                    }
                    else
                    {
                        currentResult *= operands[i];
                    }
                }

                if (result == currentResult)
                {
                    calibrationResult += result;
                    break;
                }
            }
        }

        Console.WriteLine(calibrationResult);
    }

    public void Part2(IAoC aoc)
    {
        string[] lines = aoc.GetContent();

        long calibrationResult = 0;

        foreach (string line in lines)
        {
            long result = long.Parse(line[..line.IndexOf(':')]);
            long[] operands = line[(line.IndexOf(':') + 2)..].Split().Select(long.Parse).ToArray();


            if (CanSolve(operands, result))
            {
                calibrationResult += result;
            }
        }

        Console.WriteLine(calibrationResult);
    }

    enum Operators
    {
        Mul,
        Add,
        Concat
    }

    private static bool CanSolve(long[] operands, long targetResult)
    {

        Operators[] operators = new Operators[operands.Length - 1];

        do
        {
            long currentResult = operands[0];

            for (int i = 0; i < operators.Length; i++)
            {
                switch (operators[i])
                {
                    case Operators.Mul:
                        currentResult *= operands[i + 1];
                        break;
                    case Operators.Add:
                        currentResult += operands[i + 1];
                        break;
                    case Operators.Concat:
                        currentResult = long.Parse(currentResult + "" + operands[i + 1]);
                        break;
                }

                if (currentResult > targetResult)
                {
                    break;
                }
            }

            if (currentResult == targetResult)
            {
                return true;
            }
        } while (CanIncrement(ref operators));
        return false;
    }

    private static bool CanIncrement(ref Operators[] operators)
    {
        bool carryOver;
        int idx = 0;
        do
        {
            carryOver = false;
            if (idx == operators.Length)
            {
                return false;
            }

            switch (operators[idx])
            {
                case Operators.Mul:
                    operators[idx] = Operators.Add;
                    break;
                case Operators.Add:
                    operators[idx] = Operators.Concat;
                    break;
                case Operators.Concat:
                    operators[idx] = Operators.Mul;
                    carryOver = true;
                    ++idx;
                    break;
            }
        } while (carryOver);
        return true;
    }

    public void Part2Optimized(IAoC aoc)
    {
        string[] lines = aoc.GetContent();

        long calibrationResult = 0;

        foreach (string line in lines)
        {
            long result = long.Parse(line[..line.IndexOf(':')]);
            long[] operands = line[(line.IndexOf(':') + 2)..].Split().Select(long.Parse).ToArray();


            if (CanSolveRecursive(result, operands, 0, operands[0]))
            {
                calibrationResult += result;
            }
        }

        Console.WriteLine(calibrationResult);
    }

    public bool CanSolveRecursive(long targetResult, long[] operands, int operandIdx, long intermediateResult)
    {
        if (intermediateResult > targetResult)
        {
            return false;
        }

        if (operandIdx == operands.Length - 1)
        {
            return intermediateResult == targetResult;
        }

        ++operandIdx;

        bool result = false;

        result |= CanSolveRecursive(targetResult, operands, operandIdx, intermediateResult + operands[operandIdx]);
        result |= CanSolveRecursive(targetResult, operands, operandIdx, intermediateResult * operands[operandIdx]);
        result |= CanSolveRecursive(targetResult, operands, operandIdx, long.Parse(intermediateResult + "" + operands[operandIdx]));

        return result;
    }

}
