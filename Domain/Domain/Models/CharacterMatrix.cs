namespace Domain.Models;

public class CharacterMatrix
{
    private const int ROWS = 4;
    private const int COLUMNS = 4;
    private readonly char[,] _matrix;

    public CharacterMatrix()
    {
        this._matrix = new char[ROWS, COLUMNS];
        this.Initialize();
    }

    protected virtual void Initialize()
    {
        Random random = new Random();

        for (int row = 0; row < ROWS; row++)
        {
            for (int column = 0; column < COLUMNS; column++)
            {
                this._matrix[row, column] = (char)random.Next(65, 90);
            }
        }
    }

    public IEnumerable<string> GetMatrix()
    {
        IList<string> rett = new List<string>();

        for (int row = 0; row < ROWS; row++)
        {
            string item = string.Empty;
            for (int column = 0; column < COLUMNS; column++)
            {
                item += this._matrix[row, column];
            }

            rett.Add(item);
        }

        return rett;
    }
}