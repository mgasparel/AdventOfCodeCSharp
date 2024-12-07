using AdventOfCode.Year2024;
using Xunit;

namespace AdventOfCode.Tests;

public class Day02Part02Tests
{
    [Fact]
    public void Solve_ShouldReturnExpectedValue()
    {
        var input = "2 5 4 3 2";
        var report = new Report(input.Split(' ').Select(int.Parse).ToArray());

        Assert.True(report.IsSafe(true));
    }
}
