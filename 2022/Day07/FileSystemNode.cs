using AdventOfCode.Common;

namespace AdventOfCode.Year2022;

public class FileSystemNode : Node<string>
{
    public int Size { get; set; }

    public string Type { get; set; }

    public FileSystemNode(string name, int size, string type)
        : base(name)
    {
        Size = size;
        Type = type;
    }

    public override bool Equals(object? obj)
    {
        return obj is FileSystemNode node && Size == node.Size && Type == node.Type && Value == node.Value && Equals(node.Parent, Parent);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Size, Type, Value);
    }
}