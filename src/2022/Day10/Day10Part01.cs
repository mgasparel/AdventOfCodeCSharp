using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022.Day10;

public class Day10Part01 : Puzzle<List<Instruction>>
{
    public override string SampleAnswer => "13140";

    protected override List<Instruction> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => new Instruction(
                    line[0..4],
                    line == "noop" ?
                        0 :
                        int.Parse(line[5..])))
            .ToList();

    protected override string SolveImpl(List<Instruction> input)
        => new CPU().Run(input, new CRT()).ToString();
}