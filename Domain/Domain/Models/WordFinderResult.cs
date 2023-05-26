namespace Domain.Models;

internal class WordFinderResult
{
    private readonly Dictionary<string, WordFinderResultItem> _result;
    private readonly int PODIUM_WORDS_AMOUNT = 10;

    public WordFinderResult()
    {
        this._result = new Dictionary<string, WordFinderResultItem>();
    }

    public void AddFoundedWord(string word)
    {
        this.GetItemOrDefault(word)
            .Hits++;
    }

    private WordFinderResultItem GetItemOrDefault(string word)
    {
        if (!this._result.ContainsKey(word))
        {
            this._result.Add(word, new WordFinderResultItem(word));
        }

        return this._result[word];
    }

    public IEnumerable<string> GetRanking()
    {
        return this._result.OrderByDescending(x => x.Value.Hits)
            .Take(PODIUM_WORDS_AMOUNT)
            .Select(x => x.Value.Word);
    }
}