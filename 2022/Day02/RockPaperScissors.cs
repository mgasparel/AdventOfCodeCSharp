namespace AdventOfCode2022;

public class RockPaperScissors
{
    private const char Draw = 'Y', Win = 'Z';
    private readonly char _playerMove, _rivalMove, _desiredOutcome;

    public RockPaperScissors(char playerMove, char rivalMove, char desiredOutcome)
    {
        _playerMove = (char)(playerMove - 23); // Convert X,Y,Z values to A,B,C
        _rivalMove = rivalMove;
        _desiredOutcome = desiredOutcome;
    }

    public int Shoot(bool usePlayerMove = false)
    {
        char move = _playerMove;
        if (!usePlayerMove)
        {
            move = ChooseMove(_rivalMove, _desiredOutcome);
        }

        int playerScore = move - 'C' + 3;
        return playerScore + GetOutcome(move, _rivalMove);
    }

    private static int GetOutcome(char playerMove, char rivalMove)
    {
        if (playerMove == rivalMove)
        {
            return 3;
        }

        if (playerMove == ChooseMove(rivalMove, Win))
        {
            return 6;
        }

        return 0;
    }

    private static char ChooseMove(char rivalMove, char desiredOutcome)
    {
        if (desiredOutcome == Draw)
        {
            return rivalMove;
        }

        // The winning item is always 1 item ahead, rolling back around to zero if needed.
        // The losing item is always 2 items ahead, rolling back around to zero if needed.
        int offset = desiredOutcome == Win ? 1 : 2;

        // Calculate the zero-based index of rivalMove in the sequence A,B,C.
        int index = rivalMove - 'A';
        int winningIndex = (index + offset) % 3;
        // Turn the index back into a value.
        return (char)(winningIndex + 'A');
    }
}