using AdventOfCode.Common;

using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day08Part01 : Puzzle<Forest>
{
    public override string SampleAnswer => "21";

    protected override Forest ParseInputImpl(string rawInput)
        => new(rawInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.ToCharArray())
            .Select(arr => Array.ConvertAll(arr, height => new Tree(height.AsInt())))
            .ToArray()
            .Transpose());

    protected override string SolveImpl(Forest input)
    {
        input.Survey();
        return input.Trees
            .SelectMany((trees) => trees)
            .Count(tree => tree.Visible)
            .ToString();
    }
}