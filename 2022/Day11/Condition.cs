using System.Numerics;

namespace AdventOfCode.Year2022;

public class Condition
{
    private readonly string _test;
    private readonly int _conditionTrue;
    private readonly int _conditionFalse;

    public int Divisor { get; init; }

    public Condition(string test, int conditionTrue, int conditionFalse)
    {
        _test = test;
        _conditionTrue = conditionTrue;
        _conditionFalse = conditionFalse;
        Divisor = int.Parse(_test[13..]);
    }

    public int Evaluate(BigInteger value)
    {
        if (_test.StartsWith("divisible by"))
        {
            return value % Divisor == 0
                ? _conditionTrue
                : _conditionFalse;
        }

        throw new NotSupportedException("Condition not supported.");
    }
}