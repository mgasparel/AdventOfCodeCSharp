namespace AdventOfCode.Year2022.Day10;

public class Instruction
{
    public string Command { get; set; }
    public int Value { get; set; }
    public int CurrentCycle { get; set; }

    public Instruction(string command, int value, int currentCycle = 0)
    {
        Command = command;
        Value = value;
        CurrentCycle = currentCycle;
    }
}