using System;
using Xunit;
using ServerApp.Models;
using System.Collections.Generic;
using System.IO;

namespace ServerApp.Tests
{
    public class BoggleSolverTests
    {
        [Fact]
        public void IsSolved()
        {
            string[] board = {
                "B","E","0","0",
                "A","P","O","K",
                "Q","S","E","I",
                "Z","R","E","E"
            };
            BoggleSolver solver = new BoggleSolver();
            solver.InitializeBoard(board);
            solver.SolveBoard();

            HashSet<string> words= solver.wordList;

            List<string> wordList = new List<string>(words);

            Assert.Contains<string>("BASE",wordList);
            Assert.Contains<string>("POKER",wordList);
            Assert.Contains<string>("PEER",wordList);
            Assert.Contains<string>("SPA",wordList);
            Assert.Contains<string>("SPOKE",wordList);
        }
    }
}