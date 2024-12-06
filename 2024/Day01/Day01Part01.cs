using SimpleMind.AdventOfCode;
using System.Collections.Immutable;

namespace AdventOfCode.Year2024;

public class Day01Part01 : Puzzle<(int[] l, int[] r)>
{
    public override string SampleAnswer => "11";

    protected override (int[] l, int[] r) ParseInputImpl(string rawInput)
    {
        return rawInput
            .Split(Environment.NewLine)
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Aggregate(
                (l: new List<int>(), r: new List<int>()),
                (acc, x) =>
                {
                    acc.l.Add(int.Parse(x[..x.IndexOf(' ')]));
                    acc.r.Add(int.Parse(x[x.LastIndexOf(' ')..]));
                    return acc;
                },
                acc =>
                {
                    acc.l.Sort();
                    acc.r.Sort();
                    return (acc.l.ToArray(), acc.r.ToArray());
                });
    }

    protected override string SolveImpl((int[] l, int[] r) parsedInput)
        => parsedInput.l.Zip(parsedInput.r, (li, ri) => Math.Abs(li - ri)).Sum().ToString();
}
