using System.Text.RegularExpressions;

using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2024;

public partial class Day03Part02 : Puzzle<List<Instruction>>
{
    public override string SampleAnswer => "48";
    private readonly Regex _regex = InstructionParser();

    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)", RegexOptions.Compiled)]
    private static partial Regex InstructionParser();

    protected override List<Instruction> ParseInputImpl(string rawInput)
        => _regex.Matches(rawInput)
            .Select(match => new Instruction(match.Value))
            .ToList();

    protected override string SolveImpl(List<Instruction> parsedInput)
        => new Computer(parsedInput).Execute().ToString();
}
