using System.Numerics;

namespace AdventOfCode2022;

public class Monkey
{
    private readonly Queue<BigInteger> _items;
    private readonly Operation _operation;
    public Condition Condition { get; private set; }

    public long InspectedCount { get; internal set; }

    public Monkey(int[] startingItems, Operation operation, Condition condition)
    {
        _items = new Queue<BigInteger>(startingItems.ToList().ConvertAll(x => new BigInteger(x)));
        _operation = operation;
        Condition = condition;
    }

    public bool TryInspect(out BigInteger item)
    {
        if (_items.TryDequeue(out item))
        {
            InspectedCount++;
            return true;
        }

        return false;
    }

    public BigInteger WorryLevel(BigInteger item)
        => _operation.Evaluate(item);

    public int ChooseThrowTarget(BigInteger worryLevel)
        => Condition.Evaluate(worryLevel);

    public void Catch(BigInteger worryLevel)
        => _items.Enqueue(worryLevel);
}