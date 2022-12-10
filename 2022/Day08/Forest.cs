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
            for (int y = 0; y < Trees[x].Length; y++)
            {
                int viewDistanceLeft = GetViewDistanceLeft(x, y);
                int viewDistanceRight = GetViewDistanceRight(x, y);
                int viewDistanceUp = GetViewDistanceUp(x, y);
                int viewDistanceDown = GetViewDistanceDown(x, y);

                Trees[x][y] = Trees[x][y] with
                {
                    ViewDistanceLeft = viewDistanceLeft,
                    ViewDistanceRight = viewDistanceRight,
                    ViewDistanceUp = viewDistanceUp,
                    ViewDistanceDown = viewDistanceDown,
                };
                Trees[x][y] = Trees[x][y] with { Visible = IsVisible(x, y) };
                Console.WriteLine($"({x},{y}) {Trees[x][y]}");
            }
        }
    }

    private bool IsVisible(int x, int y)
    {
        // All boundary trees are visible.
        if (x == 0 || y == 0 || x == Trees.Length - 1 || y == Trees.Length - 1)
        {
            return true;
        }

        // When viewing distance is "to the edge", we don't know if it's because the tree at the edge is blocking our
        // view, or because we hit the end of the grid. Also check the height of the tree at the edge to ensure it isn't
        // blocking the view to the current tree
        if (Trees[x][y].ViewDistanceUp == y && Trees[x][y].Height > Trees[x][0].Height)
        {
            return true;
        }

        if (Trees[x][y].ViewDistanceDown == Trees.Length - y - 1 && Trees[x][y].Height > Trees[x][^1].Height)
        {
            return true;
        }

        if (Trees[x][y].ViewDistanceLeft == x && Trees[x][y].Height > Trees[0][y].Height)
        {
            return true;
        }

        if (Trees[x][y].ViewDistanceRight == Trees.Length - x - 1 && Trees[x][y].Height > Trees[^1][y].Height)
        {
            return true;
        }

        return false;
    }

    private int GetViewDistanceDown(int x, int y)
    {
        int viewDistance = Trees.Length - y - 1;
        for (int i = y + 1; i < Trees.Length; i++)
        {
            if (Trees[x][i].Height >= Trees[x][y].Height)
            {
                viewDistance = i - y;
                break;
            }
        }
        return viewDistance;
    }

    private int GetViewDistanceUp(int x, int y)
    {
        int viewDistance = y;
        for (int i = y - 1; i >= 0; i--)
        {
            if (Trees[x][i].Height >= Trees[x][y].Height)
            {
                viewDistance = y - i;
                break;
            }
        }
        return viewDistance;
    }

    private int GetViewDistanceRight(int x, int y)
    {
        int viewDistance = Trees.Length - x - 1;
        for (int i = x + 1; i < Trees.Length; i++)
        {
            if (Trees[i][y].Height >= Trees[x][y].Height)
            {
                viewDistance = i - x;
                break;
            }
        }
        return viewDistance;
    }

    private int GetViewDistanceLeft(int x, int y)
    {
        int viewDistance = x;
        for (int i = x - 1; i >= 0; i--)
        {
            if (Trees[i][y].Height >= Trees[x][y].Height)
            {
                viewDistance = x - i;
                break;
            }
        }
        return viewDistance;
    }
}