namespace AdventOfCode.Common;

public static class ArrayExtensions
{
    public static T[][] Transpose<T>(this T[][] source)
    {
        int rows = source.Length;
        int columns = source[0].Length;

        var result = new T[columns][];
        for (int c = 0; c < columns; c++)
        {
            result[c] = new T[rows];
            for (int r = 0; r < rows; r++)
            {
                result[c][r] = source[r][c];
            }
        }

        return result;
    }
}