using Domain.Validations;

namespace Domain.Models
{
    internal class VerticalWordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;
        private readonly WordFinderResult _result;

        internal VerticalWordFinder(IEnumerable<string> matrix, WordFinderResult result)
        {
            Assert.NotNull(matrix, nameof(matrix));
            Assert.NotNull(result, nameof(result));

            this._matrix = matrix;
            this._result = result;
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

        internal string GetNextChunk(int columnPosition, int chunkStart, int chunkSize)
        {
            return this.GetColumn(columnPosition).Substring(chunkStart, chunkSize);
        }

        internal bool HasNextChunk(int columnPosition, int chunkStart, int chunkSize)
        {
            string word = this.GetColumn(columnPosition);
            return word.Length >= chunkStart + chunkSize
                && word.Substring(chunkStart).Length >= chunkSize;
        }

        internal string GetColumn(int columnPosition)
        {
            string rett = string.Empty;
            foreach (string row in this._matrix)
            {
                rett += row.Substring(columnPosition, 1);
            }

            return rett;
        }
    }
}