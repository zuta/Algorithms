using System;
using System.Collections.Generic;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public class BinarySearchTree<TKey, TValue> : IBinarySearchTree<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        private IBinarySearchTreeNode<TKey, TValue> root;

        public int Count { get; private set; }

        public IBinarySearchTreeNode<TKey, TValue> Search(TKey key)
        {
            return Search(root, key);
        }

        private IBinarySearchTreeNode<TKey, TValue> Search(IBinarySearchTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null)
            {
                return null;
            }

            int compareResult = root.Key.CompareTo(key);

            if (compareResult > 0)
            {
                return Search(root.LeftChild, key);
            }
            else if (compareResult < 0)
            {
                return Search(root.RightChild, key);
            }

            return root;
        }

        public void Insert(TKey key, TValue value)
        {
            IBinarySearchTreeNode<TKey, TValue> newNode = new BinarySearchTreeNode<TKey, TValue>(key, value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Insert(root, newNode);
            }

            Count++;
        }

        private void Insert(IBinarySearchTreeNode<TKey, TValue> root, IBinarySearchTreeNode<TKey, TValue> newNode)
        {
            int compareResult = root.Key.CompareTo(newNode.Key);

            if (compareResult > 0)
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = newNode;
                }
                else
                {
                    Insert(root.LeftChild, newNode);
                }
            }
            else if (compareResult < 0)
            {
                if (root.RightChild == null)
                {
                    root.RightChild = newNode;
                }
                else
                {
                    Insert(root.RightChild, newNode);
                }
            }
            else 
            {
                throw new ArgumentException("An element with the same key already exists in the tree");
            }
        }

        public IEnumerable<IBinarySearchTreeNode<TKey, TValue>> Traverse()
        {
            IList<IBinarySearchTreeNode<TKey,TValue>> result = new List<IBinarySearchTreeNode<TKey,TValue>>();

            Traverse(root, result.Add);

            return result;
        }

        private void Traverse(IBinarySearchTreeNode<TKey, TValue> root, Action<IBinarySearchTreeNode<TKey, TValue>> yielder)
        {
            if (root == null)
            {
                return;
            }

            Traverse(root.LeftChild, yielder);
            yielder(root);
            Traverse(root.RightChild, yielder);
        }
    }
}