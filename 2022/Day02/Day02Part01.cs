using SimpleMind.AdventOfCode;

namespace AdventOfCode2022;

public class Day02Part01 : Puzzle<IEnumerable<RockPaperScissors>>
{
    public override string SampleAnswer => "15";

    protected override IEnumerable<RockPaperScissors> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => new RockPaperScissors(l[2], l[0], l[2]));

    protected override string SolveImpl(IEnumerable<RockPaperScissors> input)
        => input.Sum(x => x.Shoot(usePlayerMove: true)).ToString();
}