namespace AdventOfCode.Common;

public static class CharExtensions
{
    public static int AsInt(this char c)
        => (int)char.GetNumericValue(c);
}