using System;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public class BinarySearchTreeNode<TKey, TValue> : IBinarySearchTreeNode<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        public TKey Key { get; private set; }

        public TValue Value { get; private set; }

        public IBinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        public IBinarySearchTreeNode<TKey, TValue> RightChild { get; set; }

        public BinarySearchTreeNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}