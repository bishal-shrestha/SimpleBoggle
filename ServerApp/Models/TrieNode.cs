using System.Collections.Generic;

namespace ServerApp.Models
{
    public class TrieNode
    {
        public char TrieValue {get;set;}
        public Dictionary<char,TrieNode> ChildTrieNodes {get;set;} = new Dictionary<char, TrieNode>();

        public bool IsWord{get;set;} = false;
    }
}