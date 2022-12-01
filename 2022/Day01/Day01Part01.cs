using SimpleMind.AdventOfCode;

namespace AdventOfCode2022.Day01;

public class Day01Part01 : Puzzle<List<ElfInventory>>
{
    public override string SampleAnswer => "24000";

    protected override List<ElfInventory> ParseInputImpl(string rawInput)
    {
        string[] lines = rawInput.Split(Environment.NewLine);
        return ParseInventories(lines).ToList();

        static IEnumerable<ElfInventory> ParseInventories(IEnumerable<string> input)
        {
            var buffer = new List<int>();
            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return new ElfInventory(buffer);
                    buffer = new List<int>();
                    continue;
                }

                buffer.Add(int.Parse(line));
            }

            yield return new ElfInventory(buffer);
        }
    }

    protected override string SolveImpl(List<ElfInventory> parsedInput)
        => parsedInput.Max(x => x.TotalCalories).ToString() ?? "";
}
