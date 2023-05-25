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
    public void Test_Given_DemoMatrixWithOneHorizontalWord_When_FindTheWord_Then_ShouldFindIt()
    {
        IList<string> matrix = new List<string>(new[] { "ABCATJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "CAT" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithOneVerticalWords_When_Find_Then_ShouldFindAll()
    {
        IList<string> matrix = new List<string>(new[] {
            "PBCATJNP",
            "EBCATJNA",
            "TBDOGJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "PET" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithRepeatedWord_When_FindTheWord_Then_ShouldBeFirst()
    {
        IList<string> matrix = new List<string>(new[] {
            "ABCATJNT",
            "ABCATJNT",
            "ABDOGJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "CAT", "DOG" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual("CAT", result.First());
    }

    [TestMethod]
    public void Test_Given_DemoMatrixWithHorizontalAndVerticalWords_When_Find_Then_ShouldFindAll()
    {
        IList<string> matrix = new List<string>(new[] {
            "ABCATJNP",
            "ABCATJNE",
            "ABDOGJNT" });
        WordFinder finder = new WordFinder(matrix);
        IList<string> stream = new List<string>(new[] { "CAT", "DOG", "PET", "KAT" });

        IEnumerable<string> result = finder.Find(stream);

        Assert.AreEqual(3, result.Count());
    }
}