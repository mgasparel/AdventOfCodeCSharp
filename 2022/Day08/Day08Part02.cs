namespace AdventOfCode2022;

public class Day08Part02 : Day08Part01
{
    public override string SampleAnswer => "8";

    protected override string SolveImpl(Forest input)
    {
        input.Survey();
        return input.Trees
            .SelectMany((trees) => trees)
            .Max(tree => tree.ScenicScore)
            .ToString();
    }
}