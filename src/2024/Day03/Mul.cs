namespace AdventOfCode.Year2024;

public class Mul
{
    private readonly int _a;
    private readonly int _b;

    public Mul(string instruction)
    {
        int openBracketPos = instruction.IndexOf('(');
        int commaPos = instruction.IndexOf(',');
        int closeBracketPos = instruction.IndexOf(')');

        _a = int.Parse(instruction[(openBracketPos + 1)..commaPos]);
        _b = int.Parse(instruction[(commaPos + 1)..closeBracketPos]);
    }

    public int Multiply()
        => _a * _b;
}