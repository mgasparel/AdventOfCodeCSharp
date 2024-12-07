namespace AdventOfCode.Common;

public class Node<T>
{
    public Node<T>? Parent { get; set; }
    public HashSet<Node<T>> Children { get; }
    public T Value { get; set; }

    public Node(T value)
    {
        Value = value;
        Children = new HashSet<Node<T>>();
    }

    public override bool Equals(object? obj)
    {
        return obj is Node<T> node && node.Value!.Equals(Value);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}