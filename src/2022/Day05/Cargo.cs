namespace AdventOfCode.Year2022;

public class Cargo
{
    public List<Stack<char>> Stacks { get; private set; } = new List<Stack<char>>();

    public void AddToPile(int pileNumber, char item)
    {
        if (pileNumber <= Stacks.Count)
        {
            Stacks[pileNumber - 1].Push(item);
            return;
        }

        var stack = new Stack<char>(item);
        stack.Push(item);
        Stacks.Add(stack);
    }
}