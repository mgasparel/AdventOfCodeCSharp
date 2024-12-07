namespace AdventOfCode.Year2022;

public class Rucksack
{
    public string Contents { get; init; }
    private readonly int _midpoint;
    private ReadOnlySpan<char> LeftSide => Contents.AsSpan(0, _midpoint);
    private ReadOnlySpan<char> RightSide => Contents.AsSpan(_midpoint);

    public Rucksack(string contents)
    {
        Contents = contents;
        _midpoint = contents.Length / 2;
    }

    public int PriorityOfDuplicate()
    {
        char duplicate = DetermineDuplicate(LeftSide, RightSide);
        return GetPriority(duplicate);
    }

    // ReadonlySpan can not be nullable, so we're using an empty span and this overload instead.
    private static char DetermineDuplicate(ReadOnlySpan<char> leftSide, ReadOnlySpan<char> rightSide)
        => DetermineDuplicate(leftSide, rightSide, "".AsSpan());

    public static char DetermineDuplicate(ReadOnlySpan<char> a, ReadOnlySpan<char> b, ReadOnlySpan<char> c)
    {
        // Find the first char in a that is also present in b.
        // If c is not empty, also check that the matching char is present in c.
        foreach (char cCurrent in a)
        {
            if (b.IndexOf(cCurrent) == -1)
            {
                continue;
            }

            if (c.Length > 0)
            {
                if (c.IndexOf(cCurrent) >= 0)
                {
                    return cCurrent;
                }
                continue;
            }
            return cCurrent;
        }
        throw new Exception("No duplicates found!");
    }

    public static int GetPriority(char value)
        => value switch
        {
            >= 'a' and <= 'z' => value - 'a' + 1,  //1-26
            >= 'A' and <= 'Z' => value - 'A' + 27, //27-52
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be between a-z or A-Z.")
        };
}