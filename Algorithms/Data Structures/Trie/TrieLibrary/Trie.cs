using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.Trie.TrieLibrary
{
    public class Trie<T>
    {
        private TrieNode<T> root;

        public Trie()
        {
            root = new TrieNode<T>(default(T));
        }

        public void Insert(IEnumerable<T> sequence)
        {
            TrieNode<T> current = root;

            foreach (T item in sequence)
            {
                if (current.Links.ContainsKey(item))
                    current = current.Links[item];
                else
                {
                    current.Links.Add(item, new TrieNode<T>(item));
                    current = current.Links[item];
                }
            }

            current.IsEnd = true;
        }

        public bool Contains(IEnumerable<T> sequence)
        {
            TrieNode<T> current = root;

            foreach (T item in sequence)
            {
                if (current.Links.ContainsKey(item))
                {
                    current = current.Links[item];
                }
                else
                {
                    return false;
                }
            }

            return current.IsEnd;
        }

        public IEnumerable<IEnumerable<T>> EnumerateInOrder()
        {
            return EnumerateInOrder(root, new List<T>());
        }

        private IEnumerable<IEnumerable<T>> EnumerateInOrder(TrieNode<T> root, List<T> list)
        {
            if (root.IsEnd) yield return list;

            foreach (var child in root.Links.OrderBy(pair => pair.Key))
            {
                list.Add(child.Key);

                foreach (IEnumerable<T> sequence in EnumerateInOrder(child.Value, list))
                {
                    yield return sequence;
                }

                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
