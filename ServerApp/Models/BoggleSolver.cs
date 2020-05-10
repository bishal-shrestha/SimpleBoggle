using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServerApp.Models
{
    /// <summary>
    /// Class to solve boggle
    /// </summary>
    public class BoggleSolver
    {
        const int BOARD_SIZE = 4;   // for 4 * 4 board
        private string[,] board = new string[BOARD_SIZE,BOARD_SIZE]; 
        private bool[,] visited = new bool[BOARD_SIZE,BOARD_SIZE];

        /// <summary>
        /// List of solved words
        /// </summary>
        public HashSet<string> wordList {get;private set;} = new HashSet<string>();
        private Trie trie = new Trie();

        public BoggleSolver()
        {
            foreach(var word in WordValidator.ValidWordsList)
            {
                trie.AddWord(word);
            }
        }

        public void InitializeBoard(string[] boardConfig)
        {
            for (int i = 0; i < BOARD_SIZE * BOARD_SIZE; ++i)
            {
                int row = i / BOARD_SIZE;
                int col = i % BOARD_SIZE;

                board[row,col] = boardConfig[i].ToString().ToUpper();
            }
        }

        public void SolveBoard()
        {
             for (int i = 0; i < BOARD_SIZE; i++)
                for (int j = 0; j < BOARD_SIZE; j++)
                   Solve(i, j,string.Empty,trie.RootNode);
        }

        /// <summary>
        /// Recursively matches letters in board with Trie
        /// </summary>
        /// <param name="row">Row position of cell</param>
        /// <param name="col">Column position of cell</param>
        /// <param name="word">Matching word</param>
        /// <param name="currentNode">Node to operate on</param>
        private void Solve(int row,int col,string word,TrieNode currentNode)
        {
            //set current cell as visited
            visited[row,col] = true;

            char cell = board[row,col][0];  // only contains single character

            if(currentNode.ChildTrieNodes.TryGetValue(cell, out TrieNode node))
            {
                word+=cell;

                //check 8 neighbour cells
                //excluding cells that are outside board or already visited
                for (int r = row - 1; r <= row + 1 && r < BOARD_SIZE; r++)
                    for (int c = col - 1; c <= col + 1 && c < BOARD_SIZE; c++)
                        if (r >= 0 && c >= 0 && !visited[r, c])
                        {
                            Solve(r,c,word,node);
                        }

                if(node.IsWord && word.Length>2)    //only words with 3 or more letters are considered
                    wordList.Add(word);
            }
            visited[row, col] = false;
        }
    }
}