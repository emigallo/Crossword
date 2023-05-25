using Domain.Models;

namespace Test;

[TestClass]
public class VerticalWordFinderTest
{
    [TestMethod]
    public void Test_Given_MatrixWithOneColumn_When_GetColumn_Then_ShouldGetSameLetters()
    {
        IEnumerable<string> matrix = new List<string>
        {
            "ABCD"
        };

        VerticalWordFinder finder = new VerticalWordFinder(matrix, new WordFinderResult());

        string result = finder.GetColumn(0);
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    public void Test_Given_MatrixWithFourColumns_When_GetColumn_Then_ShouldGetSameLetters()
    {
        IEnumerable<string> matrix = new List<string>
        {
            "ABCD",
            "EFGH",
            "IJKL",
            "MNOP"
        };

        VerticalWordFinder finder = new VerticalWordFinder(matrix, new WordFinderResult());

        string result = finder.GetColumn(0);
        Assert.AreEqual("AEIM", result);
    }

    [TestMethod]
    public void Test_Given_FourByFourMatrix_When_RowPositionIsTwoAndWordSizeIsTwo_Then_HasNextChunk()
    {
        IEnumerable<string> matrix = new List<string>
        {
            "ABCD",
            "EFGH",
            "IJKL",
            "MNOP"
        };

        VerticalWordFinder finder = new VerticalWordFinder(matrix, new WordFinderResult());

        int columnPosition = 0;
        int rowPosition = 2;
        int wordSize = 2;

        Assert.IsTrue(finder.HasNextChunk(columnPosition, rowPosition, wordSize));
    }
}