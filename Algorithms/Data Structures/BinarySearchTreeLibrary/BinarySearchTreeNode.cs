using System;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public class BinarySearchTreeNode<TKey, TValue> : IBinarySearchTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public IBinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        public IBinarySearchTreeNode<TKey, TValue> RightChild { get; set; }

        public BinarySearchTreeNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public bool HasChildren
        {
            get
            {
                return LeftChild != null || RightChild != null;
            }
        }

        public override string ToString()
        {
            return string.Format("Key = {0}, Value = {1}", Key, Value);
        }
    }
}