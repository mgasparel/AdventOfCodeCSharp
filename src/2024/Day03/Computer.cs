namespace AdventOfCode.Year2024;

public class Computer(List<Instruction> instructions)
{
    private readonly List<Instruction> _instructions = instructions;

    public int Execute()
    {
        bool disabled = false;

        int result = 0;
        foreach (Instruction instruction in _instructions)
        {
            disabled = instruction.Type switch
            {
                InstructionType.Do => false,
                InstructionType.Dont => true,
                _ => disabled
            };

            if (instruction.Type == InstructionType.Mul && !disabled)
            {
                result += new Mul(instruction.Value).Multiply();
            }
        }

        return result;
    }
}