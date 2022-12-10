using AdventOfCode2022.Common;

namespace AdventOfCode2022;

public class RopeBridge
{
    private readonly List<Instruction> _instructions;
    private readonly List<Point> _visited;
    private readonly Point[] _knots;

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
        _knots = Enumerable.Range(0, 2)
            .Select(x => new Point(0, 0))
            .ToArray();

        _visited = new() { Tail }; // Remember that we visited the origin!
    }

    public void Simulate()
    {
        PrintState();
        foreach (Instruction instruction in _instructions)
        {
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
                PrintState();
            }
        }
    }

    private void MoveHead(Direction direction)
        => Head = MovePoint(Head, direction);

    private Point MoveKnot(Point follower, Point leader)
    {
        if (!ShouldMoveKnot(follower, leader))
        {
            return follower;
        }

        return MoveKnot(Tail, GetDirectionToHeadX(follower, leader), GetDirectionToHeadY(follower, leader));
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

    private void PrintState()
    {
        //Console.WriteLine($"H: ({_head.X},{_head.Y}), T: ({_tail.X},{_tail.Y})");
    }

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