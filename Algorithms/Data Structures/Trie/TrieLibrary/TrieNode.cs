using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.Trie.TrieLibrary
{
    public class TrieNode<T>
    {
        public T Last { get; private set; }

        public Dictionary<T, TrieNode<T>> Links { get; private set; }

        public bool IsEnd { get; set; }

        public TrieNode(T last)
        {
            this.Last = last;
            this.Links = new Dictionary<T, TrieNode<T>>();
        }
    }
}
