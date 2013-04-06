using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.BinarySearchTree.OrderStatisticTreeLibrary
{
    public interface IOrderStatisticTree<TKey, TValue> : IBinarySearchTree<TKey,TValue>
        where TKey : IComparable<TKey>
    {
        IOrderStatisticTreeNode<TKey, TValue> FindTheKthSmallestNode(int k);

        IOrderStatisticTreeNode<TKey, TValue> FindTheKthLargestNode(int k);

        /// <summary>
        /// Finds the rank of node in the tree, i.e. its index in the sorted list of nodes of the tree
        /// </summary>
        /// <param name="node">node of tree</param>
        /// <returns>The rank of node in the tree</returns>
        int GetRank(IOrderStatisticTreeNode<TKey, TValue> node);

    }
}
