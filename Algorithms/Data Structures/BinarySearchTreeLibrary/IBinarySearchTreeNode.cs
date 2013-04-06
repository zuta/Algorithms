using System;
using System.Collections.Generic;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public interface IBinarySearchTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        TKey Key { get; set; }

        TValue Value { get; set; }

        IBinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        IBinarySearchTreeNode<TKey, TValue> RightChild { get; set; }

        bool HasChildren { get; }
    }
}
