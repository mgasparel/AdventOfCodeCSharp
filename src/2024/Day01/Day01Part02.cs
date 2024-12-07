namespace AdventOfCode.Year2024;

public class Day01Part02 : Day01Part01
{
    public override string SampleAnswer => "31";

    protected override string SolveImpl((int[] l, int[] r) parsedInput)
        => parsedInput.l.Sum(li => parsedInput.r.Count(ri => ri == li) * li).ToString();
}
