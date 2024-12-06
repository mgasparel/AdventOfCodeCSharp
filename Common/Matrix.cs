namespace AdventOfCode2022.Common;

public class Matrix<T>
{
    private readonly T[,] _matrix;

    public Matrix(T[,] matrix)
    {
        _matrix = matrix;
    }

    public T[,] Transpose()
    {
        int rows = _matrix.GetLength(0);
        int columns = _matrix.GetLength(1);

        var result = new T[columns, rows];

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                result[c, r] = _matrix[r, c];
            }
        }

        return result;
    }
}
