using SimpleMind.AdventOfCode;

namespace AdventOfCode2022;

public class Day04Part01 : Puzzle<IEnumerable<Assignments>>
{
    public override string SampleAnswer => "2";

    protected override IEnumerable<Assignments> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split(','))
            .Select(l => (CreateRange(l[0]), CreateRange(l[1])))
            .Select(l => new Assignments(l.Item1, l.Item2));

    private static (int Start, int End) CreateRange(string range)
        => (int.Parse(range[..range.IndexOf('-')]), int.Parse(range[(range.IndexOf('-') + 1)..]));

    protected override string SolveImpl(IEnumerable<Assignments> input)
        => input.Count(x =>
            (x.A.Start >= x.B.Start && x.A.End <= x.B.End) ||
            (x.B.Start >= x.A.Start && x.B.End <= x.A.End)).ToString();
}