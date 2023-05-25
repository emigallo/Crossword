using Domain.Models;
using Domain.Validations;

namespace Domain.UseCases
{
    public class WordFinder
    {
        private IEnumerable<string> _matrix;
        private List<IWordFinder> _finders;
        private WordFinderResult _result;

        public WordFinder(IEnumerable<string> matrix)
        {
            Assert.NotNull(matrix);
            this._matrix = matrix;
            this._result = new WordFinderResult();

            this._finders = new List<IWordFinder>(new[] {
                new HorizontalWordFinder(this._matrix,this._result) });
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Assert.NotNull(wordstream);

            // Pasar estos 2 a iteradores
            for (int columnPosition = 0; columnPosition < this._matrix.Count(); columnPosition++)
            {
                for (int rowPosition = 0; rowPosition < this._matrix.ElementAt(0).Length; rowPosition++)
                {
                    foreach (string word in wordstream)
                    {
                        this._finders.ForEach(x => x.Find(rowPosition, columnPosition, word));
                    }
                }
            }

            return this._result.GetRanking();
        }
    }
}