using SimpleMind.AdventOfCode;

namespace AdventOfCode2022;

public class Day07Part01 : Puzzle<IEnumerable<string>>
{
    public override string SampleAnswer => "95437";

    protected override IEnumerable<string> ParseInputImpl(string rawInput)
        => rawInput.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    protected override string SolveImpl(IEnumerable<string> input)
    {
        var fs = new FileSystem(input);
        fs.ProcessCommands();
        fs.UpdateFolderSizes();
        fs.PrintFileSystem();

        var dirs = fs.Nodes.Where(node => node.Size <= 100_000 && node.Type == "dir");
        return dirs.Sum(x => x.Size).ToString();
    }
}