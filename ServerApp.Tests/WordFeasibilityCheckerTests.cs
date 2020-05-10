using System;
using Xunit;
using ServerApp.Models;

namespace ServerApp.Tests
{
    public class WordFeasibilityCheckerTests
    {
        [Fact]
        public void IsFeasibleHorizental()
        {
            string[] board = {
                "T","E","S","T",
                "S","P","C","G",
                "B","P","T","A",
                "A","A","W","P"
            };
            WordFeasibilityChecker checker = new WordFeasibilityChecker(board);
            bool feasible = checker.IsWordFeasible("TEST");

            Assert.True(feasible);
        }

        [Fact]
        public void IsFeasibleVertical()
        {
            string[] board = {
                "T","H","N","K",
                "E","P","C","G",
                "S","P","T","A",
                "T","A","W","P"
            };
            WordFeasibilityChecker checker = new WordFeasibilityChecker(board);
            bool feasible = checker.IsWordFeasible("TEST");

            Assert.True(feasible);
        }

        [Fact]
        public void IsFeasibleDiagonal()
        {
            string[] board = {
                "T","H","N","K",
                "S","E","C","G",
                "B","P","S","A",
                "A","A","W","T"
            };
            WordFeasibilityChecker checker = new WordFeasibilityChecker(board);
            bool feasible = checker.IsWordFeasible("TEST");

            Assert.True(feasible);
        }

        [Fact]
        public void IsFeasibleMixed()
        {
            string[] board = {
                "F","T","N","K",
                "S","E","C","G",
                "B","T","H","A",
                "A","A","W","T"
            };
            WordFeasibilityChecker checker = new WordFeasibilityChecker(board);
            bool feasible = checker.IsWordFeasible("TEST");

            Assert.True(feasible);
        }

        [Fact]
        public void IsFeasibleRepeated()
        {
            string[] board = {
                "T","H","N","K",
                "S","E","C","G",
                "B","P","H","A",
                "A","A","W","T"
            };
            WordFeasibilityChecker checker = new WordFeasibilityChecker(board);
            bool feasible = checker.IsWordFeasible("TEST");

            Assert.False(feasible);
        }
    }
}
