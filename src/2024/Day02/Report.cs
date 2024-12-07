namespace AdventOfCode.Year2024;

public class Report(int[] levels)
{
    readonly int[] _levels = levels;
    public bool IsSafe(bool dampen)
    {
        if (IsSafe())
        {
            return true;
        }

        if (!dampen)
        {
            return false;
        }

        // Re-check the safety after removing each level
        for (int i = 0; i < _levels.Length; i++)
        {
            if (IsSafe(i))
            {
                return true;
            }
        }

        return false;
    }

    bool IsSafe(int? levelToSkip = null)
    {
        int startIndex = levelToSkip.HasValue && levelToSkip.Value == 0 ? 1 : 0;

        int lastLevel = _levels[startIndex];
        bool? allIncreasing = null;
        for (int i = startIndex + 1; i < _levels.Length; i++)
        {
            if (i == levelToSkip)
            {
                continue;
            }

            if (Math.Abs(_levels[i] - lastLevel) is < 1 or > 3)
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