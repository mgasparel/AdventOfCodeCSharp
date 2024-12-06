using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2024;

public class Day02Part01 : Puzzle<List<Report>>
{
    public override string SampleAnswer => "2";

    protected override List<Report> ParseInputImpl(string rawInput)
    {
        return rawInput
            .Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => new Report(l.Split(' ').Select(int.Parse).ToArray()))
            .ToList();
    }

    protected override string SolveImpl(List<Report> parsedInput)
        => parsedInput.Count(x => x.IsSafe()).ToString();
}
