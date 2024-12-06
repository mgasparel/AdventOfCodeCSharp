using System.Text.RegularExpressions;
using AdventOfCode.Common;
using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day05Part01 : Puzzle<CargoShip>
{
    private static readonly Regex Rx = new(@"(\d+).+(\d+).+(\d+)", RegexOptions.Compiled);
    public override string SampleAnswer => "CMZ";

    protected override CargoShip ParseInputImpl(string rawInput)
    {
        (Cargo cargo, CraneInstruction[] instructions) = Parse(rawInput);
        return new CargoShip(cargo, instructions);
    }

    protected static (Cargo cargo, CraneInstruction[] instructions) Parse(string rawInput)
    {
        IEnumerable<string[]> inputChunks = rawInput
            .Split(Environment.NewLine)
            .ChunkOn(l => string.IsNullOrWhiteSpace(l));

        IEnumerator<string[]> e = inputChunks.GetEnumerator();
        e.MoveNext();

        var cargo = new Cargo();
        string[] cargoLines = e.Current;
        for (int i = cargoLines.Length - 2; i >= 0; i--)
        {
            string line = cargoLines[i];
            for (int c = 1; c < line.Length; c += 4)
            {
                char letter = line[c];
                if (letter is not ' ' or (< '1' and > '9'))
                {
                    int pileNumber = ((c - 1) / 4) + 1;
                    cargo.AddToPile(pileNumber, letter);
                }
            }
        }

        e.MoveNext();
        CraneInstruction[] instructions = e.Current.Select(line =>
        {
            GroupCollection matches = Rx.Matches(line).First().Groups;
            return new CraneInstruction(
                Count: int.Parse(matches[1].Value),
                Origin: int.Parse(matches[2].Value),
                Destination: int.Parse(matches[3].Value)
            );
        }).ToArray();

        return (cargo, instructions);
    }

    protected override string SolveImpl(CargoShip input)
    {
        input.MoveCargo();
        return input.GetTopOfStacks();
    }
}
