namespace AdventOfCode2022.Day01;

public class ElfInventory
{
    private readonly List<int> _calories;

    public int TotalCalories => _calories.Sum();

    public ElfInventory(List<int> calories)
    {
        _calories = calories;
    }
}