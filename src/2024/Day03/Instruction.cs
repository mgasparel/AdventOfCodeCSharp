namespace AdventOfCode.Year2024;

public class Instruction(string instruction)
{
    public string Value { get; } = instruction;

    public InstructionType Type { get; } = instruction switch
    {
        "do()" => InstructionType.Do,
        "don't()" => InstructionType.Dont,
        _ => InstructionType.Mul
    };
}