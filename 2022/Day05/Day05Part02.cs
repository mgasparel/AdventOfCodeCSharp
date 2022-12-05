namespace AdventOfCode2022;

public class Day05Part02 : Day05Part01
{
    public override string SampleAnswer => "MCD";

    protected override CargoShip ParseInputImpl(string rawInput)
    {
        (Cargo cargo, CraneInstruction[] instructions) = Parse(rawInput);
        return new CrateMover9001(cargo, instructions);
    }

    protected override string SolveImpl(CargoShip input)
    {
        if (input is CrateMover9001 crateMover)
        {
            crateMover.MoveCargo();
            return crateMover.GetTopOfStacks();
        }

        return "";
    }
}
