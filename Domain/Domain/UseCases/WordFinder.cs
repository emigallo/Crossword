using Domain.Models;
using Domain.Validations;

namespace Domain.UseCases;

public class WordFinder
{
    private readonly IEnumerable<string> _matrix;
    private readonly List<IWordFinder> _finders;
    private readonly WordFinderResult _result;

    public WordFinder(IEnumerable<string> matrix)
    {
        Assert.NotNull(matrix);
        this._matrix = matrix;
        this._result = new WordFinderResult();

        this._finders = new List<IWordFinder>
        {
            new HorizontalWordFinder(this._matrix, this._result),
            new VerticalWordFinder(this._matrix, this._result)
        };
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        Assert.NotNull(wordstream);

        for (int rowPosition = 0; rowPosition < this._matrix.Count(); rowPosition++)
        {
            for (int columnPosition = 0; columnPosition < this._matrix.ElementAt(0).Length; columnPosition++)
            {
                foreach (string word in wordstream)
                {
                    this._finders.ForEach(x => x.Find(rowPosition, columnPosition, word));
                }
            }
        }

        return this._result.GetRanking();
    }

    public IEnumerable<string> GetMatrix()
    {
        return this._matrix;
    }
}