using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructure.Trie.TrieLibrary;

namespace TrieTests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void TrieTests_Contains()
        {
            Trie<char> trie = new Trie<char>();

            trie.Insert("Hello");

            Assert.IsTrue(trie.Contains("Hello"));
            Assert.IsFalse(trie.Contains("Hell"));
            Assert.IsFalse(trie.Contains("Hellop"));
        }

        [TestMethod]
        public void TrieTests_Contains2()
        {
            Trie<int> trie = new Trie<int>();

            int[] array = new int[] { 1, 2, 3 };

            trie.Insert(array);
            trie.Insert(new int[] { });

            Assert.IsTrue(trie.Contains(new int[] { }));
            Assert.IsTrue(trie.Contains(array));
            Assert.IsFalse(trie.Contains(new int[] { 1, 2 }));
        }
    }
}
