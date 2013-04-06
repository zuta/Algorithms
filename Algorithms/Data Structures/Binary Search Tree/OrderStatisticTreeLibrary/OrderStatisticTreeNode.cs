using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.BinarySearchTree.OrderStatisticTreeLibrary
{
    public class OrderStatisticTreeNode<TKey, TValue> : BinarySearchTreeNode<TKey, TValue>, IOrderStatisticTreeNode<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public int LeftSubtreeCount { get; set; }

        public int RightSubtreeCount { get; set; }

        public OrderStatisticTreeNode(TKey key, TValue value)
            : base(key, value)
        {
            LeftSubtreeCount = 0;
            RightSubtreeCount = 0;
        }

        public OrderStatisticTreeNode(TKey key, TValue value, int leftSubtreeCount, int rightSubtreeCount)
            : base(key, value)
        {
            LeftSubtreeCount = leftSubtreeCount;
            RightSubtreeCount = rightSubtreeCount;
        }

        public override string ToString()
        {
            return string.Format("Key = {0}, Value = {1}, LeftSubtreeCount = {2}, RightSubtreeCount = {3}", Key, Value, LeftSubtreeCount, RightSubtreeCount);
        }

        public int TotalSubtreesCount
        {
            get
            {
                return LeftSubtreeCount + RightSubtreeCount;
            }
        }
    }
}
