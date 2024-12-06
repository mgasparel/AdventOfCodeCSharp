using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day03Part01 : Puzzle<IEnumerable<Rucksack>>
{
    public override string SampleAnswer => "157";

    protected override IEnumerable<Rucksack> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => new Rucksack(l));

    protected override string SolveImpl(IEnumerable<Rucksack> input)
        => input.Sum(x => x.PriorityOfDuplicate()).ToString();
}