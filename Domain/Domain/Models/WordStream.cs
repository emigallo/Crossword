namespace Domain.Models
{
    public class WordStream
    {
        private List<string> _words;

        public WordStream()
        {
            this._words = new List<string>();
            this.Initialize();
        }

        private void Initialize()
        {
            this._words.Add("cold");
            this._words.Add("wind");
            this._words.Add("snow");
            this._words.Add("chill");
        }

        private int _index = 0;
        public bool HasNext()
        {
            return _index < this._words.Count;
        }

        public string Next()
        {
            string current = this._words[this._index];
            this._index++;
            return current;
        }
    }
}