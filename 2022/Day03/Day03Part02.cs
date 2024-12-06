using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day03Part02 : Puzzle<IEnumerable<ElfGroup>>
{
    public override string SampleAnswer => "70";

    protected override IEnumerable<ElfGroup> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => new Rucksack(l))
            .Chunk(3)
            .Select(x => new ElfGroup(x));

    protected override string SolveImpl(IEnumerable<ElfGroup> input)
        => input.Sum(x => x.PriorityOfBadge()).ToString();
}