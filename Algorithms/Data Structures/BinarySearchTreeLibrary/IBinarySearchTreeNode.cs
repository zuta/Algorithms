using System;
using System.Collections.Generic;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public interface IBinarySearchTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        TKey Key { get; }

        TValue Value { get; }

        IBinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        IBinarySearchTreeNode<TKey, TValue> RightChild { get; set; }
    }
}
