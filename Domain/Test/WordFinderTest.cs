using Domain.UseCases;

namespace Test;

[TestClass]
public class WordFinderTest
{
    [TestMethod]
    public void Test_Given_WordsToFinde_When_CreateWithNullMatrix_Then_ShouldThowArgumentException()
    {
        try
        {
            WordFinder finder = new WordFinder(null);

            Assert.Fail();
        }
        catch (ArgumentException)
        {
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithOneWord_When_FindTheWord_ShouldFindIt()
    {
        IList<string> matrix = new List<string>(new[] { "ABCATJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "CAT" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithNoMatching_When_FindTheWord_ShouldNotFindIt()
    {
        IList<string> matrix = new List<string>(new[] { "ABCATJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "DOG" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithRepeteaedWord_When_FindTheWord_ShouldBeFirst()
    {
        IList<string> matrix = new List<string>(new[] { "ABCATJNT", "ABCATJNT", "ABDOGJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "CAT", "DOG" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual("CAT", result.First());
    }
}