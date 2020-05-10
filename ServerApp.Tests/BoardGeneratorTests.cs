using System;
using Xunit;
using ServerApp.Models;

namespace ServerApp.Tests
{
    public class BoardGeneratorTests
    {
        [Fact]
        public void GenerateBoardHasSize16()
        {
            BoardGenerator boardGenerator = new BoardGenerator();

            string[] generatedBoard = boardGenerator.GenerateBoard();
            int boardSize = generatedBoard.Length;

            Assert.Equal(16,boardSize);
        }

        [Fact]
        public void GeneratedBoardIsRandomized()
        {
            BoardGenerator boardGenerator = new BoardGenerator();

            string[] generatedBoard1 = boardGenerator.GenerateBoard();
            string[] generatedBoard2 = boardGenerator.GenerateBoard();

            Assert.NotEqual(generatedBoard1,generatedBoard2);
        }
    }
}
