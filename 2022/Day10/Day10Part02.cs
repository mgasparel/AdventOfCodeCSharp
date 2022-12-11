namespace AdventOfCode2022.Day10;

public class Day10Part02 : Day10Part01
{
    public override string SampleAnswer => @"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....";

    protected override List<Instruction> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => new Instruction(
                    line[0..4],
                    line == "noop" ?
                        0 :
                        int.Parse(line[5..])))
            .ToList();

    protected override string SolveImpl(List<Instruction> input)
    {
        var crt = new CRT();
        _ = new CPU().Run(input, crt);
        return crt.DumpBuffer();
    }
}