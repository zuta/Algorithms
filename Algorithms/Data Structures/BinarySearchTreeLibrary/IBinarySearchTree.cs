using System;
using System.Collections.Generic;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public interface IBinarySearchTree<TKey, TValue>
        where TKey : IComparable<TKey>, IEquatable<TKey>
    {
        int Count { get; }

        IBinarySearchTreeNode<TKey, TValue> Search(TKey key);

        void Insert(TKey key, TValue value);

        IEnumerable<IBinarySearchTreeNode<TKey, TValue>> Traverse();
    }
}
