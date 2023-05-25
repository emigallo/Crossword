using Domain.Models;

namespace Test;

[TestClass]
public class CharacterMatrixTest
{
    [TestMethod]
    public void Test_Given_OneMatrix_When_CreateIt_Then_ShouldNotHaveEmptyPositions()
    {
        CharacterMatrix characterMatrix = new CharacterMatrix();

        foreach (string row in characterMatrix.GetMatrix())
        {
            foreach (char letter in row)
            {
                if (letter == ' ')
                {
                    Assert.Fail();
                }
            }            
        }
    }
}