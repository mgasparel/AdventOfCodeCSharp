using System.Text;

namespace AdventOfCode2022;

public class CRT
{
    private readonly List<char> _buffer;
    private int _cycle;
    private const int ScreenWidth = 40;

    public CRT()
    {
        _buffer = new(240);
    }

    public void Draw(int spritePosition)
    {
        char pixel = '.';
        int cyclePosition = _cycle % ScreenWidth;
        if (cyclePosition >= spritePosition - 1 && cyclePosition <= spritePosition + 1)
        {
            pixel = '#';
        }

        _buffer.Add(pixel);
        _cycle++;
    }

    public void DrawBuffer()
    {
        foreach (char[] chunk in _buffer.Chunk(ScreenWidth))
        {
            Console.WriteLine(chunk);
        }
    }

    public string DumpBuffer()
    {
        var sb = new StringBuilder();
        foreach (char[] chunk in _buffer.Chunk(ScreenWidth))
        {
            sb.Append(chunk).Append(Environment.NewLine);
        }
        sb.Length -= 2; // Remove newline chars from last line.
        return sb.ToString();
    }
}