namespace AdventOfCode2022;

public class Forest
{
    public readonly Tree[][] Trees;

    public Forest(Tree[][] trees)
    {
        Trees = trees;
    }

    public void Survey()
    {
        for (int x = 0; x < Trees.Length; x++)
        {
            int? highest = null;
            for (int y = 0; y < Trees[x].Length; y++)
            {
                int currentHeight = Trees[x][y].Height;
                if (highest is null || currentHeight > highest)
                {
                    Trees[x][y] = Trees[x][y] with { Visible = true };
                    Console.WriteLine($"({x},{y}) {Trees[x][y]}");
                    highest = currentHeight;
                }
            }

            highest = null;
            for (int y = Trees[x].Length - 1; y >= 0; y--)
            {
                int currentHeight = Trees[x][y].Height;
                if (highest is null || currentHeight > highest)
                {
                    Trees[x][y] = Trees[x][y] with { Visible = true };
                    Console.WriteLine($"({x},{y}) {Trees[x][y]}");
                    highest = currentHeight;
                }
            }
        }

        for (int y = 0; y < Trees.Length; y++)
        {
            int? highest = null;
            for (int x = 0; x < Trees.Length; x++)
            {
                int currentHeight = Trees[x][y].Height;
                if (highest is null || currentHeight > highest)
                {
                    Trees[x][y] = Trees[x][y] with { Visible = true };
                    Console.WriteLine($"({x},{y}) {Trees[x][y]}");
                    highest = currentHeight;
                }
            }

            highest = null;
            for (int x = Trees.Length - 1; x >= 0; x--)
            {
                int currentHeight = Trees[x][y].Height;
                if (highest is null || currentHeight > highest)
                {
                    Trees[x][y] = Trees[x][y] with { Visible = true };
                    Console.WriteLine($"({x},{y}) {Trees[x][y]}");
                    highest = currentHeight;
                }
            }
        }
    }
}