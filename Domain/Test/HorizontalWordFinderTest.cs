using Domain.Models;

namespace Test;

[TestClass]
public class HorizontalWordFinderTest
{
    [TestMethod]
    public void Test_Given_MatrixWithOneRow_When_GetNextChunk_Then_ShouldGetTheExactLetters()
    {
        IEnumerable<string> matrix = new List<string>
        {
            "ABCD"
        };

        HorizontalWordFinder finder = new HorizontalWordFinder(matrix, new WordFinderResult());

        int columnPosition = 1;
        int rowPosition = 0;
        int wordSize = 2;
        string result = finder.GetNextChunk(rowPosition, columnPosition, wordSize);
        Assert.AreEqual("BC", result);
    }

    [TestMethod]
    public void Test_Given_MatrixWithFourRows_When_GetNextChunk_Then_ShouldGetTheExactLetters()
    {
        IEnumerable<string> matrix = new List<string>
        {
            "ABCD",
            "EFGH",
            "IJKL",
            "MNOP"
        };

        HorizontalWordFinder finder = new HorizontalWordFinder(matrix, new WordFinderResult());

        int columnPosition = 2;
        int rowPosition = 3;
        int wordSize = 2;
        string result = finder.GetNextChunk(rowPosition, columnPosition, wordSize);
        Assert.AreEqual("OP", result);
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

        HorizontalWordFinder finder = new HorizontalWordFinder(matrix, new WordFinderResult());

        int columnPosition = 0;
        int rowPosition = 2;
        int wordSize = 2;

        Assert.IsTrue(finder.HasNextChunk(columnPosition, rowPosition, wordSize));
    }
}