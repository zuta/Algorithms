using System;
using System.Collections.Generic;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public interface IBinarySearchTree<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        int Count { get; }

        int GetHeight();

        IBinarySearchTreeNode<TKey, TValue> Search(TKey key);

        IBinarySearchTreeNode<TKey, TValue> Insert(TKey key, TValue value);

        bool Remove(TKey key);

        IEnumerable<IBinarySearchTreeNode<TKey, TValue>> TraverseInOrder();
    }
}
