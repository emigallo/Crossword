using Domain.UseCases;

namespace Front
{
    internal class Demo
    {
        private const int ROWS = 24;
        private const int COLUMNS = 24;

        public Demo()
        {
        }

        public void Run()
        {
            Console.WriteLine("--------   Welcome to Crossword   --------");

            while (this.AskToRunDemo())
            {
                WordFinder finder = new WordFinder(this.GetRandomMatrix());
                this.ShowMatrix(finder.GetMatrix());
                this.ShowResult(finder.Find(this.GetWordStream()));
            }
        }

        private bool AskToRunDemo()
        {
            string keyPresses = string.Empty;
            do
            {
                Console.WriteLine("Do you want to start the demo? To continue press 'y', to cancel press 'n'");
                keyPresses = Console.ReadLine() ?? string.Empty;
            } while (keyPresses != "y" && keyPresses != "n");

            return keyPresses == "y";
        }

        private void ShowMatrix(IEnumerable<string> matrix)
        {
            Console.WriteLine("--------   Matrix   --------");
            Console.WriteLine();

            foreach (string row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private void ShowResult(IEnumerable<string> ranking)
        {
            Console.WriteLine("--------   Words founded   --------");
            Console.WriteLine();

            foreach (string word in ranking)
            {
                Console.WriteLine(word);
            }
        }

        private IList<string> GetRandomMatrix()
        {
            IList<string> rett = new List<string>();
            Random random = new Random();

            for (int rowPosition = 0; rowPosition < ROWS; rowPosition++)
            {
                string row = string.Empty;
                for (int columnPosition = 0; columnPosition < COLUMNS; columnPosition++)
                {
                    row += (char)random.Next(65, 90);
                }
                rett.Add(row);
            }

            return rett;
        }

        private IList<string> GetWordStream()
        {
            IList<string> rett = new List<string>();
            rett.Add("cold");
            rett.Add("wind");
            rett.Add("snow");
            rett.Add("chill");
            return rett;
        }
    }
}