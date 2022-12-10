using AdventOfCode2022.Common;

namespace AdventOfCode2022;

public class RopeBridge
{
    private readonly List<Instruction> _instructions;
    private readonly List<Point> _visited;
    private Point _head = new(0, 0);
    private Point _tail = new(0, 0);

    public int CountVisited()
        => _visited.Distinct().Count();

    public RopeBridge(List<Instruction> instructions)
    {
        _instructions = instructions;
        _visited = new() { _tail }; // Remember that we visited the origin!
    }

    public void Simulate()
    {
        PrintState();
        foreach (Instruction instruction in _instructions)
        {
            for (int i = 0; i < instruction.Count; i++)
            {
                MoveHead(instruction.Direction);
                MoveTail();
                PrintState();
            }
        }
    }

    private void MoveHead(Direction direction)
        => _head = MovePoint(_head, direction);

    private void MoveTail()
    {
        if (!ShouldMoveTail())
        {
            return;
        }

        MoveTail(GetDirectionToHeadX(), GetDirectionToHeadY());
    }

    private void MoveTail(Direction x, Direction y)
    {
        if (x != Direction.None)
        {
            _tail = MovePoint(_tail, x);
        }

        if (y != Direction.None)
        {
            _tail = MovePoint(_tail, y);
        }

        _visited.Add(_tail);
    }

    private Direction GetDirectionToHeadX()
    {
        if (_head.X == _tail.X)
        {
            return Direction.None;
        }

        return _head.X > _tail.X
            ? Direction.Right
            : Direction.Left;
    }

    private Direction GetDirectionToHeadY()
    {
        if (_head.Y == _tail.Y)
        {
            return Direction.None;
        }

        return _head.Y > _tail.Y
            ? Direction.Up
            : Direction.Down;
    }

    private bool ShouldMoveTail()
        => Math.Abs(_head.X - _tail.X) > 1 ||
            Math.Abs(_head.Y - _tail.Y) > 1;

    private void PrintState()
    {
        Console.WriteLine($"H: ({_head.X},{_head.Y}), T: ({_tail.X},{_tail.Y})");
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