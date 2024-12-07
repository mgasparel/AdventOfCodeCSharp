namespace AdventOfCode.Year2022;

public class Day01Part02 : Day01Part01
{
    public override string SampleAnswer => "45000";

    protected override string SolveImpl(IEnumerable<ElfInventory> parsedInput)
    {
        return parsedInput
            .OrderByDescending(x => x.TotalCalories)
            .Take(3)
            .Sum(x => x.TotalCalories)
            .ToString();
    }
}