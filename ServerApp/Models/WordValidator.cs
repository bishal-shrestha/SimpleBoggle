using System.Collections.Generic;
using System.IO;

namespace ServerApp.Models
{
    /// <summary>
    /// Class to load valid word list
    /// </summary>
    public static class WordValidator
    {
        //list of valid words taken from
        //http://wordlist.aspell.net/12dicts-readme/#2of12inf

        /// <summary>
        /// path of file containing valid english words
        /// </summary>
        public static string DictFileName {get;private set;} = "./2of12inf.txt";

        /// <summary>
        /// List of valid words
        /// </summary>
        /// <value></value>
        private static List<string> ValidWordsList {get;set;}
        static WordValidator()
        {
            ValidWordsList = new List<string>();
            if(File.Exists(DictFileName))
                ValidWordsList.AddRange(File.ReadAllLines(DictFileName));
        }

        /// <summary>
        /// Checks if given word is a valid english word
        /// </summary>
        /// <param name="word">word to be checked</param>
        /// <returns>True if word is valid</returns>
        public static bool IsWordInDict(string word)
        {
            return ValidWordsList.Contains(word);
        }
    }
}