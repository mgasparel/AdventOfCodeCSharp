using System.Text.RegularExpressions;
using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2024;

public class Day03Part01 : Puzzle<List<Mul>>
{
    public override string SampleAnswer => "161";
    private readonly Regex _regex = new(@"mul\(\d{1,3}\,\d{1,3}\)", RegexOptions.Compiled);

    protected override List<Mul> ParseInputImpl(string rawInput)
        => _regex.Matches(rawInput)
            .Select(match => new Mul(match.Value))
            .ToList();

    protected override string SolveImpl(List<Mul> parsedInput)
        => parsedInput.Sum(mul => mul.Multiply()).ToString();
}
