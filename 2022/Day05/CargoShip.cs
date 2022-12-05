namespace AdventOfCode2022;

public class CargoShip
{
    protected readonly Cargo _cargo;
    protected readonly IList<CraneInstruction> _instructions;

    public CargoShip(Cargo cargo, IList<CraneInstruction> instructions)
    {
        _cargo = cargo;
        _instructions = instructions;
    }

    public void MoveCargo()
    {
        foreach ((int count, int origin, int destination) in _instructions)
        {
            MovePile(count, origin, destination);
        }
    }

    protected virtual void MovePile(int count, int origin, int destination)
    {
        // Move a pile of crates, one at a time.
        for (int i = 0; i < count; i++)
        {
            MoveCrate(origin, destination);
        }
    }

    public string GetTopOfStacks()
        => _cargo.Stacks.Aggregate("", (agg, curr) => agg += curr.Peek());

    protected void MoveCrate(int origin, int destination)
    {
        char item = _cargo.Stacks[origin - 1].Pop();
        _cargo.Stacks[destination - 1].Push(item);
    }
}