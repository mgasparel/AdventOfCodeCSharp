using SimpleMind.AdventOfCode;

namespace AdventOfCode2022;

public class Day06Part01 : Puzzle<string>
{
    public override string SampleAnswer => "10";

    protected int WindowSize { get; init; } = 4;

    protected override string ParseInputImpl(string rawInput)
        => rawInput;

    protected override string SolveImpl(string input)
    {
        ReadOnlySpan<char> s = input.AsSpan();
        for (int i = WindowSize - 1; i < input.Length; i++)
        {
            ReadOnlySpan<char> window = s.Slice(i - WindowSize + 1, WindowSize);
            if (Distinct(window))
            {
                return (i + 1).ToString();
            }
        }

        return "";
    }

    private static bool Distinct(ReadOnlySpan<char> window)
    {
        for (int i = 0; i < window.Length; i++)
        {
            for (int j = 0; j < window.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (window[i] == window[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}