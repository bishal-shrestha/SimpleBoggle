using System.Collections.Generic;

namespace ServerApp.Models
{
    /// <summary>
    /// Class to transfer user submitted word
    /// </summary>
    public class SubmittedWord
    {
        /// <summary>
        /// Current Board configuration
        /// </summary>
        /// <value></value>
        public string[] GeneratedBoard {get;set;}

        /// <summary>
        /// Word submitted by user
        /// </summary>
        /// <value></value>
        public string WordValue {get;set;}
    }
}