using SimpleMind.AdventOfCode;

namespace AdventOfCode.Year2022;

public class Day07Part02 : Day07Part01
{
    private readonly int _totalDiskSpace = 70_000_000;
    private readonly int _neededDiskSpace = 30_000_000;

    public override string SampleAnswer => "24933642";

    protected override string SolveImpl(IEnumerable<string> input)
    {
        var fs = new FileSystem(input);
        fs.ProcessCommands();
        fs.UpdateFolderSizes();
        fs.PrintFileSystem();

        var remainingDiskSpace = _totalDiskSpace - fs.Root.Size;
        var additionalNeededDiskSpace = _neededDiskSpace - remainingDiskSpace;
        var dirs = fs.Nodes.Where(node => node.Size >= additionalNeededDiskSpace && node.Type == "dir").ToList();
        return dirs.Min(x => x.Size).ToString();
    }
}