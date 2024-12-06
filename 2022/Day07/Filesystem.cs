namespace AdventOfCode.Year2022;

public class FileSystem
{
    public List<FileSystemNode> Nodes { get; } = new();
    private readonly IEnumerable<string> _terminalOutput;
    private readonly Stack<FileSystemNode> _currentNodes = new();
    private FileSystemNode? ParentNode => _currentNodes.Any() ? _currentNodes.Peek() : null;

    public FileSystemNode Root { get; private set; }

    public FileSystem(IEnumerable<string> terminalOutput)
    {
        _terminalOutput = terminalOutput;
        Root = new FileSystemNode("/", 0, "dir");
        Nodes.Add(Root);
    }

    public void UpdateFolderSizes()
    {
        _ = WalkNodes(Root);
    }

    public int WalkNodes(FileSystemNode node)
    {
        int totalNodeSize = 0;
        foreach (FileSystemNode childNode in node.Children)
        {
            totalNodeSize += childNode.Size;

            totalNodeSize += WalkNodes(childNode);

            if (node.Type == "dir")
            {
                node.Size = totalNodeSize;
            }
        }
        return totalNodeSize;
    }

    public void PrintFileSystem()
    {
        WalkNodesPrint(Root, 0);
    }

    public int WalkNodesPrint(FileSystemNode node, int tabSize)
    {
        Print(node, tabSize);
        tabSize += 2;
        foreach (FileSystemNode childNode in node.Children)
        {
            tabSize = WalkNodesPrint(childNode, tabSize);
        }
        tabSize -= 2;
        return tabSize;
    }

    void Print(FileSystemNode node, int tabSize)
    {
        Console.WriteLine(new string(' ', tabSize) + $" {node.Value} ({node.Type}, Size={node.Size})");
    }

    public void ProcessCommands()
    {
        foreach (string line in _terminalOutput)
        {
            if (IsCommand(line))
            {
                Command cmd = ParseCommand(line);
                if (cmd.Name == "cd")
                {
                    if (cmd.Option == "..")
                    {
                        _ = _currentNodes.Pop();
                        continue;
                    }

                    FileSystemNode? node = Nodes.FirstOrDefault(
                        node => node.Value == cmd.Option! &&
                        node.Type == "dir" &&
                        Equals(node.Parent, ParentNode));

                    node ??= new FileSystemNode(cmd.Option!, 0, "dir")
                    {
                        Parent = ParentNode
                    };

                    ParentNode?.Children.Add(node);
                    _currentNodes.Push(node);
                    continue;
                }

                if (cmd.Name == "ls")
                {
                    continue;
                }
            }

            if (line.StartsWith("dir"))
            {
                var node = new FileSystemNode(line[4..], 0, "dir")
                {
                    Parent = ParentNode
                };
                ParentNode?.Children.Add(node);
                Nodes.Add(node);
            }
            else
            {
                int spaceIndex = line.IndexOf(' ');
                int size = int.Parse(line[..spaceIndex]);
                var node = new FileSystemNode(line[(spaceIndex + 1)..], size, "file")
                {
                    Parent = ParentNode
                };
                ParentNode?.Children.Add(node);
                Nodes.Add(node);
            }
        }
    }

    private static bool IsCommand(string line)
        => line.StartsWith('$');

    private static Command ParseCommand(string line)
    {
        if (line.StartsWith("$ cd"))
        {
            var folder = line[5..];
            return new Command("cd", folder);
        }

        if (line.StartsWith("$ ls"))
        {
            return new Command("ls");
        }

        throw new Exception("nope!");
    }

    private record Command(string Name, string? Option = null);
}