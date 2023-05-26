namespace Domain.Models;

internal class WordFinderResultItem
{
    public WordFinderResultItem(string word)
    {
        this.Word = word;
        this.Hits = 0;
    }

    public string Word { get; init; }
    public int Hits { get; set; }
}