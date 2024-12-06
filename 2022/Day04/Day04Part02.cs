namespace AdventOfCode.Year2022;

public class Day04Part02 : Day04Part01
{
    public override string SampleAnswer => "4";

    protected override string SolveImpl(IEnumerable<Assignments> input)
        => input.Count(x =>
            (x.A.Start >= x.B.Start && x.A.Start <= x.B.End) ||
            (x.B.Start >= x.A.Start && x.B.Start <= x.A.End)).ToString();
}