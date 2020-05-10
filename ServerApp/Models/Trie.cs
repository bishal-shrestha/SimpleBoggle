using System.Collections.Generic;
using System.IO;
using System;

namespace ServerApp.Models
{
    public class Trie
    {
        public TrieNode RootNode {get;private set;} = new TrieNode();
        public TrieNode CurrentChildNode {get;set;} = new TrieNode();


        public Trie()
        {
            //rootNode = new TrieNode();
        }

        public void AddWord(string word) 
        {
            TrieNode currentNode = RootNode;
            for(int i =0; i<word.Length;++i)
            {
                char c = word[i];
                if(!currentNode.ChildTrieNodes.TryGetValue(c,out TrieNode childNode))
                {
                    childNode = new TrieNode();
                    childNode.TrieValue = c;

                    currentNode.ChildTrieNodes.Add(c,childNode);
                }
                //else
                    //childNode.IsWord = false; // discard previous flag in attempt to get longest word possible

                // if last character in word then flag as word
                if(i==word.Length-1)
                    childNode.IsWord = true;
                currentNode = childNode;
            }


        }
    }
}