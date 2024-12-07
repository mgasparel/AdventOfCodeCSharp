namespace AdventOfCode.Year2022;

public class CrateMover9001 : CargoShip
{
    public CrateMover9001(Cargo cargo, IList<CraneInstruction> instructions)
        : base(cargo, instructions)
    {
    }

    protected override void MovePile(int count, int origin, int destination)
    {
        // Move a whole pile of crates at once.
        var tmp = new List<char>();
        for (int i = 0; i < count; i++)
        {
            tmp.Add(_cargo.Stacks[origin - 1].Pop());
        }

        for (int i = tmp.Count - 1; i >= 0; i--)
        {
            _cargo.Stacks[destination - 1].Push(tmp[i]);
        }
    }
}