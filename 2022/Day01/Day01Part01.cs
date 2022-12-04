using SimpleMind.AdventOfCode;
using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day01;

public class Day01Part01 : Puzzle<IEnumerable<ElfInventory>>
{
    public override string SampleAnswer => "24000";

    protected override IEnumerable<ElfInventory> ParseInputImpl(string rawInput)
    {
        return rawInput
            .Split(Environment.NewLine)
            .ChunkOn(l => string.IsNullOrWhiteSpace(l))
            .Select(chunk => Array.ConvertAll(chunk, int.Parse))
            .Select(chunk => new ElfInventory(chunk));
    }

    protected override string SolveImpl(IEnumerable<ElfInventory> parsedInput)
        => parsedInput.Max(x => x.TotalCalories).ToString() ?? "";
}