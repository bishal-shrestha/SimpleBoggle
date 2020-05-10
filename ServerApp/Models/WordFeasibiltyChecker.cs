using System.Collections.Generic;
using System.Linq;
using System;

namespace ServerApp.Models
{
    /// <summary>
    /// Class to check if a word is feasible in given board
    /// </summary>
    public class WordFeasibilityChecker
    {
        const int BOARD_SIZE = 4;   // for 4 * 4 board
        private string[,] board = new string[BOARD_SIZE,BOARD_SIZE]; 
        private bool[,] visited = new bool[BOARD_SIZE,BOARD_SIZE];

        private string submittedWord = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardConfig">Array of strings representing board</param>
        public WordFeasibilityChecker(string[] boardConfig)
        {
            //load board
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; ++i)
            {
                int row = i / BOARD_SIZE;
                int col = i % BOARD_SIZE;

                board[row,col] = boardConfig[i].ToString().ToUpper();
            }
        }

        /// <summary>
        /// Checks if word is feasible
        /// </summary>
        /// <param name="word">Word submitted by user</param>
        /// <returns>True if word is feasible</returns>
        public bool IsWordFeasible(string word)
        {
            bool feasible = false;
            submittedWord = word.ToUpperInvariant();

            for (int i = 0; i < BOARD_SIZE; i++)
                for (int j = 0; j < BOARD_SIZE; j++)
                   feasible = feasible || CheckWord(i, j, 0);

            return feasible;
        }

        /// <summary>
        /// Recursively checks if a word can belong in the board
        /// </summary>
        /// <param name="row">Starting row position</param>
        /// <param name="col">Starting column positiion</param>
        /// <param name="index">Index of character in user submitted word</param>
        /// <returns></returns>
        private bool CheckWord(int row,int col,int index)
        {
            //set current cell as visited
            visited[row,col] = true;

            string letter = submittedWord[index].ToString();
            string cell = board[row,col].ToString();
            
            //continue only if cell matches required char. for optimization
            if(cell.Equals(letter,StringComparison.InvariantCultureIgnoreCase))
            {
                if(index<submittedWord.Length-1)
                {                
                    //check 8 neighbour cells
                    //excluding cells that are outside board or already visited
                    for (int r = row - 1; r <= row + 1 && r < BOARD_SIZE; r++)
                        for (int c = col - 1; c <= col + 1 && c < BOARD_SIZE; c++)
                            if (r >= 0 && c >= 0 && !visited[r, c])
                                if(CheckWord(r,c,index+1))  // recursively check each neighbour for next char
                                    // no need for further recursion
                                    return true;
                }
                else
                    return true;    //checked all char in submitted word. returning
                            
            }

            visited[row, col] = false;
            return false;
        }
    }
}