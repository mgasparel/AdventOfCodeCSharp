namespace AdventOfCode2022.Common;

public static class CharExtensions
{
    public static int AsInt(this char c)
        => (int)char.GetNumericValue(c);
}