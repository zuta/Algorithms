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
        /// <summary>
        /// Finds the k-th smallest node/element in the tree
        /// </summary>
        /// <param name="k">the zero-based index</param>
        /// <returns>k-th smallest node</returns>
        IOrderStatisticTreeNode<TKey, TValue> FindTheKthSmallestNode(int k);

        /// <summary>
        /// Finds the k-th largest node/element in the tree
        /// </summary>
        /// <param name="k">the zero-based index</param>
        /// <returns>k-th smallest node</returns>
        IOrderStatisticTreeNode<TKey, TValue> FindTheKthLargestNode(int k);

        /// <summary>
        /// Finds the rank of node in the tree, i.e. its index in the sorted list of nodes of the tree
        /// </summary>
        /// <param name="node">node of tree</param>
        /// <returns>The rank of node in the tree if the node exists in the tree. Otherwise, returns -1</returns>
        int GetRank(IOrderStatisticTreeNode<TKey, TValue> node);

    }
}
