using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructure.BinarySearchTree.OrderStatisticTreeLibrary
{
    public class OrderStatisticTree<TKey, TValue> : BinarySearchTree<TKey, TValue>, IOrderStatisticTree<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public override IBinarySearchTreeNode<TKey, TValue> Insert(TKey key, TValue value)
        {
            IOrderStatisticTreeNode<TKey, TValue> newNode = new OrderStatisticTreeNode<TKey, TValue>(key, value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Insert((IOrderStatisticTreeNode<TKey, TValue>)root, newNode);
            }

            return newNode;
        }

        private void Insert(IOrderStatisticTreeNode<TKey, TValue> root, IOrderStatisticTreeNode<TKey, TValue> newNode)
        {
            if (root.Key.CompareTo(newNode.Key) > 0)
            {
                if (root.LeftChild == null)
                {
                    root.LeftSubtreeCount = 1;
                    root.LeftChild = newNode;
                }
                else
                {
                    Insert((IOrderStatisticTreeNode<TKey, TValue>)root.LeftChild, newNode);
                    root.LeftSubtreeCount++;
                }
            }
            else
            {
                if (root.RightChild == null)
                {
                    root.RightSubtreeCount = 1;
                    root.RightChild = newNode;
                }
                else
                {
                    Insert((IOrderStatisticTreeNode<TKey, TValue>)root.RightChild, newNode);
                    root.RightSubtreeCount++;
                }
            }
        }

        public IOrderStatisticTreeNode<TKey, TValue> FindTheKthSmallestNode(int k)
        {
            return FindTheKthSmallestNode((IOrderStatisticTreeNode<TKey, TValue>)root, k);
        }

        private IOrderStatisticTreeNode<TKey, TValue> FindTheKthSmallestNode(IOrderStatisticTreeNode<TKey, TValue> node, int k)
        {
            if (node == null)
            {
                return null;
            }

            if (node.LeftSubtreeCount == k)
            {
                return node;
            }
            else if (k > node.LeftSubtreeCount)
            {
                return FindTheKthSmallestNode((IOrderStatisticTreeNode<TKey, TValue>)node.RightChild, k - node.LeftSubtreeCount - 1);
            }
            else
            {
                return FindTheKthSmallestNode((IOrderStatisticTreeNode<TKey, TValue>)node.LeftChild, k);
            }
        }

        public IOrderStatisticTreeNode<TKey, TValue> FindTheKthLargestNode(int k)
        {
            return FindTheKthSmallestNode(Count - k - 1); 
        }

        public int GetRank(IOrderStatisticTreeNode<TKey, TValue> node)
        {
            return GetRank((IOrderStatisticTreeNode<TKey, TValue>)root, node, 0);
        }

        private int GetRank(IOrderStatisticTreeNode<TKey, TValue> root, IOrderStatisticTreeNode<TKey, TValue> nodeToSearch, int shift)
        {
            if (root == null)
            {
                return -1;
            }

            if (root == nodeToSearch)
            {
                return root.LeftSubtreeCount + shift;
            }
            else if (root.Key.CompareTo(nodeToSearch.Key) > 0)
            {
                return GetRank((IOrderStatisticTreeNode<TKey, TValue>)root.LeftChild, nodeToSearch, shift);
            }
            else
            {
                return GetRank((IOrderStatisticTreeNode<TKey, TValue>)root.RightChild, nodeToSearch, shift + root.LeftSubtreeCount + 1);
            }
        }
    }
}
