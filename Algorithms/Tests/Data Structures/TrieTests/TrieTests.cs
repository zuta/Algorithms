using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructure.Trie.TrieLibrary;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void TrieTests_EnumerateInOrder()
        {
            Trie<char> trie = new Trie<char>();

            List<string> items = new List<string>() { "abcd", "abc" };
            foreach (string item in items)
            {
                trie.Insert(item);
            }

            items.Sort();

            var actualOrder = trie.EnumerateInOrder().Select(sequence => new string(sequence.ToArray())).ToList();

            Assert.IsTrue(items.Except(actualOrder).Count() == 0);
            Assert.IsTrue(actualOrder.Except(items).Count() == 0);
        }

        [TestMethod]
        public void TrieTests_EnumerateInOrder2()
        {
            Trie<char> trie = new Trie<char>();

            List<string> items = new List<string>();

            Random r = new Random();
            for (int i = 0; i < 100000; i++)
            {
                char[] word = new char[r.Next(10) + 1];

                for (int j = 0; j < word.Length; j++)
                {
                    word[j] = (char)(97 + r.Next(26));
                }

                string sword = new string(word);

                items.Add(sword);

                trie.Insert(sword);
            }

            items.Sort();

            var actualOrder = trie.EnumerateInOrder().Select(sequence => new string(sequence.ToArray())).ToList();

            Assert.IsTrue(items.Except(actualOrder).Count() == 0);
            Assert.IsTrue(actualOrder.Except(items).Count() == 0);
        }
    }
}
