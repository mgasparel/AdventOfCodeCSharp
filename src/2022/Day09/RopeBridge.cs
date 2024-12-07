using AdventOfCode.Common;

namespace AdventOfCode.Year2022;

public class RopeBridge
{
    private readonly List<Instruction> _instructions;
    private List<Point> _visited;
    private Point[] _knots;

    private Point Head
    {
        get => _knots[0];
        set => _knots[0] = value;
    }

    private Point Tail
    {
        get => _knots[1];
        set => _knots[1] = value;
    }

    public int CountVisited()
        => _visited.Distinct().Count();

    public RopeBridge(List<Instruction> instructions)
    {
        _instructions = instructions;
        _visited = new();
        _knots = Array.Empty<Point>();
    }

    private void InitializeRope(int numKnots)
    {
        _knots = Enumerable.Range(0, numKnots)
            .Select(x => new Point(0, 0))
            .ToArray();

        _visited = new() { Tail }; // Remember that we visited the origin!
    }

    public void Simulate(int numKnots)
    {
        InitializeRope(numKnots);
        PrintState();
        foreach (Instruction instruction in _instructions)
        {
            PrintInstruction(instruction);

            for (int i = 0; i < instruction.Count; i++)
            {
                MoveHead(instruction.Direction);

                Point leader = Head;
                for (int j = 1; j < _knots.Length; j++)
                {
                    _knots[j] = MoveKnot(_knots[j], leader);
                    leader = _knots[j];
                }
                _visited.Add(leader); //leader is know the tail.
            }
            PrintState();
        }
    }

    private void PrintInstruction(Instruction instruction)
    {
        //Console.WriteLine(Environment.NewLine + "==" + instruction.Direction + " " + instruction.Count + "==" + Environment.NewLine);
    }

    private void MoveHead(Direction direction)
        => Head = MovePoint(Head, direction);

    private Point MoveKnot(Point follower, Point leader)
    {
        if (!ShouldMoveKnot(follower, leader))
        {
            return follower;
        }

        return MoveKnot(follower, GetDirectionToHeadX(follower, leader), GetDirectionToHeadY(follower, leader));
    }

    private static Point MoveKnot(Point knot, Direction x, Direction y)
    {
        Point newKnot = knot with { };
        if (x != Direction.None)
        {
            newKnot = MovePoint(newKnot, x);
        }

        if (y != Direction.None)
        {
            newKnot = MovePoint(newKnot, y);
        }

        return newKnot;
    }

    private static Direction GetDirectionToHeadX(Point follower, Point leader)
    {
        if (leader.X == follower.X)
        {
            return Direction.None;
        }

        return leader.X > follower.X
            ? Direction.Right
            : Direction.Left;
    }

    private Direction GetDirectionToHeadY(Point follower, Point leader)
    {
        if (leader.Y == follower.Y)
        {
            return Direction.None;
        }

        return leader.Y > follower.Y
            ? Direction.Up
            : Direction.Down;
    }

    private static bool ShouldMoveKnot(Point follower, Point leader)
        => Math.Abs(leader.X - follower.X) > 1 ||
            Math.Abs(leader.Y - follower.Y) > 1;

#pragma warning disable CS0162 // Unreachable code detected
    private void PrintState()
    {
        return;
        int minX, minY = minX = int.MaxValue;
        int maxX, maxY = maxX = 5;

        foreach (Point p in _knots.Append(new Point(0, 0)))
        {
            if (p.X < minX)
            {
                minX = p.X;
            }
            if (p.Y < minY)
            {
                minY = p.Y;
            }
            if (p.X > maxX)
            {
                maxX = p.X;
            }
            if (p.Y > maxY)
            {
                maxY = p.Y;
            }
        }
        int offsetX = 0;
        int offsetY = 0;

        if (minX < 0)
        {
            offsetX = Math.Abs(minX);
        }
        if (minY < 0)
        {
            offsetY = Math.Abs(minY);
        }

        var grid = new List<char[]>(maxY + offsetY);
        for (int i = 0; i <= maxY + offsetY; i++)
        {
            grid.Add(new string('.', maxX + 1 + offsetX).ToCharArray());
        }

        grid[0][0] = 'O';
        for (int i = 1; i < _knots.Length; i++)
        {
            var knot = _knots[i];
            grid[knot.Y + offsetY][knot.X + offsetX] = i.ToString().First();
        }
        grid[Head.Y + offsetY][Head.X + offsetX] = 'H';

        for (int i = grid.Count - 1; i >= 0; i--)
        {
            var line = grid[i];
            Console.WriteLine(line);
        }
    }
#pragma warning restore CS0162 // Unreachable code detected

    private static Point MovePoint(Point p, Direction d)
        => d switch
        {
            Direction.Up => p with { Y = p.Y + 1 },
            Direction.Down => p with { Y = p.Y - 1 },
            Direction.Left => p with { X = p.X - 1 },
            Direction.Right => p with { X = p.X + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(d))
        };
}