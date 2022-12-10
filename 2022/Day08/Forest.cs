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
            for (int y = 0; y < Trees.Length; y++)
            {
                if (IsVisible(x, y))
                {
                    Trees[x][y] = Trees[x][y] with { Visible = true };
                    Console.WriteLine($"({x},{y}) {Trees[x][y]}");
                    continue;
                }
                Console.WriteLine($"({x},{y}) {Trees[x][y]}");
            }
        }
    }

    private bool IsVisible(int x, int y)
    {
        return IsVisibleFromTop(x, y) ||
            IsVisibleFromRight(x, y) ||
            IsVisibleFromBottom(x, y) ||
            IsVisibleFromLeft(x, y);
    }

    private bool IsVisibleFromTop(int x, int y)
    {
        int height = Trees[x][y].Height;
        for (int i = y - 1; i >= 0; i--)
        {
            if (Trees[x][i].Height >= height)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsVisibleFromBottom(int x, int y)
    {
        int height = Trees[x][y].Height;
        int startIndex = Math.Clamp(y + 1, 0, Trees.Length - 1);
        for (int i = startIndex; i < Trees.Length; i++)
        {
            if (Trees[x][i].Height >= height)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsVisibleFromLeft(int x, int y)
    {
        int height = Trees[x][y].Height;
        for (int i = x - 1; i >= 0; i--)
        {
            if (Trees[i][y].Height >= height)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsVisibleFromRight(int x, int y)
    {
        int height = Trees[x][y].Height;
        int startIndex = Math.Clamp(x + 1, 0, Trees[x].Length - 1);
        for (int i = startIndex; i < Trees[x].Length; i++)
        {
            if (Trees[i][y].Height >= height)
            {
                return false;
            }
        }
        return true;
    }
}