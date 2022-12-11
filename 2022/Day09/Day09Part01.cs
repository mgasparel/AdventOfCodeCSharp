using SimpleMind.AdventOfCode;
using AdventOfCode2022.Common;

namespace AdventOfCode2022;

public class Day09Part01 : Puzzle<RopeBridge>
{
    public override string SampleAnswer => "13";

    protected virtual int NumKnots => 2;

    protected override RopeBridge ParseInputImpl(string rawInput)
        => new (rawInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
                new Instruction(
                    ParseDirection(x[0]),
                    int.Parse(x[2..]))
            ).ToList());

    private static Direction ParseDirection(char c)
        => c switch
        {
            'U' => Direction.Up,
            'R' => Direction.Right,
            'L' => Direction.Left,
            'D' => Direction.Down,
            _ => Direction.None
        };

    protected override string SolveImpl(RopeBridge input)
    {
        input.Simulate(NumKnots);
        return input.CountVisited().ToString();
    }
}