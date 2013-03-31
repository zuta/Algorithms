using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public interface IBinarySearchTreeNode<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        TKey Key { get; }

        TValue Value { get; }

        IBinarySearchTreeNode<TKey, TValue> LeftChild { get; set; }

        IBinarySearchTreeNode<TKey, TValue> RightChild { get; set; }
    }
}
