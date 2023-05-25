using Domain.Validations;

namespace Domain.Models;

internal class HorizontalWordFinder : IWordFinder
{
    private readonly IEnumerable<string> _matrix;
    //private IList<IWordFinder> _finders;
    //private IEnumerable<string> _wordstream;
    private readonly WordFinderResult _result;

    internal HorizontalWordFinder(IEnumerable<string> matrix, WordFinderResult result)
    {
        Assert.NotNull(matrix, nameof(matrix));
        this._matrix = matrix;
        this._result = result;
    }

    public void AddWordStream(IEnumerable<string> wordstream)
    {
        Assert.NotNull(wordstream, nameof(wordstream));
        //this._wordstream = wordstream;
    }

    public void Find(int rowPosition, int columnPosition, string word)
    {
        if (this.HasNextChunk(columnPosition, rowPosition, word.Length))
        {
            string chunk = this.GetNextChunk(columnPosition, rowPosition, word.Length);

            if (word == chunk)
            {
                this._result.AddFoundedWord(word);
            }
        }
    }

    private string GetNextChunk(int columnPosition, int chunkStart, int chunkSize)
    {
        return this._matrix.ElementAt(columnPosition).Substring(chunkStart, chunkSize);
    }

    private bool HasNextChunk(int columnPosition, int chunkStart, int chunkSize)
    {
        return this._matrix.ElementAt(columnPosition).Substring(chunkStart).Length >= chunkSize;
    }
}