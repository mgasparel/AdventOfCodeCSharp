namespace AdventOfCode2022.Day01;

public class Day01Part02 : Day01Part01
{
    public override string SampleAnswer => "45000";

    protected override string SolveImpl(List<ElfInventory> parsedInput)
    {
        var items = parsedInput.ToList();
        return items
            .OrderByDescending(x => x.TotalCalories)
            .Take(3)
            .Sum(x => x.TotalCalories)
            .ToString();
    }
}
