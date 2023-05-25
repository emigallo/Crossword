namespace Domain.Models;

internal interface IWordFinder
{
    void Find(int rowPosition, int columnPosition, string word);
}