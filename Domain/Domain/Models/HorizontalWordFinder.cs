using Domain.Validations;

namespace Domain.Models;

internal class HorizontalWordFinder : IWordFinder
{
    private readonly IEnumerable<string> _matrix;
    private readonly WordFinderResult _result;

    internal HorizontalWordFinder(IEnumerable<string> matrix, WordFinderResult result)
    {
        Assert.NotNull(matrix, nameof(matrix));
        Assert.NotNull(result, nameof(result));

        this._matrix = matrix;
        this._result = result;
    }

    public void Find(int rowPosition, int columnPosition, string word)
    {
        if (this.HasNextChunk(rowPosition, columnPosition, word.Length))
        {
            string chunk = this.GetNextChunk(rowPosition, columnPosition, word.Length);

            if (word == chunk)
            {
                this._result.AddFoundedWord(word);
            }
        }
    }

    internal string GetNextChunk(int rowPosition, int chunkStart, int chunkSize)
    {
        return this._matrix.ElementAt(rowPosition).Substring(chunkStart, chunkSize);
    }

    internal bool HasNextChunk(int rowPosition, int chunkStart, int chunkSize)
    {
        return this._matrix.ElementAt(rowPosition).Substring(chunkStart).Length >= chunkSize;
    }
}