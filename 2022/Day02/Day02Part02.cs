namespace AdventOfCode.Year2022;

public class Day02Part02 : Day02Part01
{
    public override string SampleAnswer => "12";

    protected override string SolveImpl(IEnumerable<RockPaperScissors> input)
        => input.Sum(x => x.Shoot()).ToString();
}