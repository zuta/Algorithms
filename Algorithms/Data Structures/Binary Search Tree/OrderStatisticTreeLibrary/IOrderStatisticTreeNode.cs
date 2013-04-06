using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.BinarySearchTree.OrderStatisticTreeLibrary
{
    public interface IOrderStatisticTreeNode<TKey, TValue> : IBinarySearchTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        int LeftSubtreeCount { get; set; }

        int RightSubtreeCount { get; set; }

        int TotalSubtreesCount { get; }
    }
}
