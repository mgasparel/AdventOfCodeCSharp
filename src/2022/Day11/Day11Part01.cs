using System.Numerics;

using AdventOfCode.Common;

using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day11Part01 : Puzzle<List<Monkey>>
{
    public override string SampleAnswer => "10605";
    public virtual int NumRounds => 20;
    public virtual bool MonkeyBored => true;

    protected override List<Monkey> ParseInputImpl(string rawInput)
    {
        var monkeys = rawInput
            .Split(Environment.NewLine)
            .ChunkOn(line => string.IsNullOrWhiteSpace(line))
            .Where(lines => lines.Length > 0)
            .Select(lines => ParseMonkey(lines))
            .ToList();

        return monkeys;
    }

    private static Monkey ParseMonkey(string[] lines)
    {
        var startingItems = lines[1][18..]
            .Split(',')
            .Select(num => int.Parse(num))
            .ToArray();

        string operationString = lines[2][13..];
        string test = lines[3][8..];
        int conditionTrue = int.Parse(lines[4][29..]);
        int conditionFalse = int.Parse(lines[5][30..]);

        var operation = new Operation(operationString);
        var condition = new Condition(test, conditionTrue, conditionFalse);
        return new Monkey(startingItems, operation, condition);
    }

    protected override string SolveImpl(List<Monkey> input)
    {
        int lcm = input.Aggregate(1, (int agg, Monkey cur) => cur.Condition.Divisor * agg);
        for (int round = 1; round <= NumRounds; round++)
        {
            //Console.WriteLine("Round " + round);

            foreach (Monkey monkey in input)
            {
                while (monkey.TryInspect(out BigInteger item))
                {
                    BigInteger worryLevel = monkey.WorryLevel(item);
                    if (MonkeyBored)
                    {
                        worryLevel /= 3;
                    }
                    else
                    {
                        worryLevel %= lcm;
                    }

                    int targetIndex = monkey.ChooseThrowTarget(worryLevel);
                    input[targetIndex].Catch(worryLevel);
                }
            }
        }

        return input.OrderByDescending(monkey => monkey.InspectedCount)
            .Take(2)
            .Select(monkey => monkey.InspectedCount)
            .Aggregate((curr, agg) => agg * curr)
            .ToString();
    }
}