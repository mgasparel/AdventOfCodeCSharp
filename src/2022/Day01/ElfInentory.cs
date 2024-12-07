namespace AdventOfCode.Year2022;

public class ElfInventory
{
    private readonly int[] _calories;

    public int TotalCalories => _calories.Sum();

    public ElfInventory(int[] calories)
    {
        _calories = calories;
    }
}