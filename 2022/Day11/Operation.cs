using System.Numerics;

namespace AdventOfCode2022;

public class Operation
{
    private readonly string _operationString;

    public Operation(string operationString)
    {
        _operationString = operationString;
    }

    public BigInteger Evaluate(BigInteger oldValue)
    {
        // Assumption: format is always 'new = old' plus some other operation.
        BigInteger operand = _operationString[12..] == "old"
            ? oldValue
            : int.Parse(_operationString[12..]);

        char @operator = _operationString[10];

        if (@operator == '+')
        {
            return oldValue + operand;
        }

        if (@operator == '*')
        {
            return oldValue * operand;
        }

        throw new NotSupportedException("Operator not supported.");
    }
}