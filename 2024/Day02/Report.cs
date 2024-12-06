namespace AdventOfCode.Year2024;

public class Report(int[] levels)
{
    readonly int[] _levels = levels;

    public bool IsSafe()
    {
        int lastLevel = _levels[0];
        bool? allIncreasing = null;
        for (int i = 1; i < _levels.Length; i++)
        {
            if (Math.Abs(_levels[i] - lastLevel) < 1 || Math.Abs(_levels[i] - lastLevel) > 3)
            {
                return false;
            }

            bool increasing = _levels[i] > lastLevel;
            allIncreasing ??= increasing;

            if (increasing != allIncreasing)
            {
                return false;
            }

            lastLevel = _levels[i];
        }

        return true;
    }
}