namespace AdventOfCode.Year2022;

public record Tree(
    int Height,
    bool Visible = false,
    int ViewDistanceLeft = 0,
    int ViewDistanceRight = 0,
    int ViewDistanceUp = 0,
    int ViewDistanceDown = 0)
{
    public int ScenicScore => ViewDistanceLeft * ViewDistanceRight * ViewDistanceUp * ViewDistanceDown;
}