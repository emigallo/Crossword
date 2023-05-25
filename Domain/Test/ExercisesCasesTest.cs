using Domain.UseCases;

namespace Test;

[TestClass]
public class ExercisesCasesTest
{
    [TestMethod]
    public void Test_Given_DemoMatrixWithNoMatching_When_FindThen_ShouldNotFindIt()
    {
        IList<string> matrix = new List<string>(new[] { "ABCATJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "DOG" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithElevenWords_When_Find_Then_ShouldReturnTen()
    {
        IList<string> matrix = new List<string>(new[] {
            "GLASSKEYCELL",
            "MONITORBPATH",
            "HEADSETNNPEN",
            "TELEVISIONRE",
            "COACHASTREET",
            "WORLDAAGLASS"});

        IEnumerable<string> words = new List<string>
        {
            "GLASS",
            "KEY",
            "CELL",
            "MONITOR",
            "PATH",
            "HEADSET",
            "PEN",
            "TELEVISION",
            "COACH",
            "STREET"
        };

        WordFinder finder = new WordFinder(matrix);
        IEnumerable<string> result = finder.Find(words);
        Assert.AreEqual(10, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithRepeatedWord_When_Find_Then_ShouldBeCountedOnlyOnce()
    {
        IList<string> matrix = new List<string>(new[]
        {
            "ABDOGJNT",
            "ABCATJNT",
            "ABDOGJNT"
        });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "DOG" });

        IEnumerable<string> result = finder.Find(stream).Where(x => x == "DOG");

        Assert.AreEqual(1, result.Count());
    }
}