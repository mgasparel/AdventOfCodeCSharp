namespace AdventOfCode2022.Day10;

public class CPU
{
    public int X { get; private set; } = 1;

    public int Run(List<Instruction> instructions)
    {
        var e = instructions.GetEnumerator();
        e.MoveNext();
        int cycle = 0;
        bool complete = false;
        int totalSignalStrength = 0;

        while (!complete)
        {
            cycle++;
            string command = e.Current.Command;
            if (command == "addx")
            {
                e.Current.CurrentCycle += 1;
            }

            if (cycle == 20 || ((cycle + 20) % 40 == 0 && cycle <= 220))
            {
                int signalStrength = cycle * X;
                totalSignalStrength += signalStrength;
                Console.WriteLine($"Cycle: {cycle}, X: {X}, SignalStrength: {signalStrength}, TotalSS: {totalSignalStrength}");
            }

            if (command == "noop")
            {
                complete = !e.MoveNext();
                continue;
            }

            if (command == "addx" && e.Current.CurrentCycle == 2)
            {
                X += e.Current.Value;
                complete = !e.MoveNext();
            }
        }

        return totalSignalStrength;
    }
}