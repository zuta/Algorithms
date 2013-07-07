using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary
{
    public class BinarySearchTree<TKey, TValue> : IBinarySearchTree<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        protected IBinarySearchTreeNode<TKey, TValue> root;

        public int Count
        {
            get
            {
                return TraverseInOrder().Count();
            }
        }

        public IBinarySearchTreeNode<TKey, TValue> Search(TKey key)
        {
            return Search(root, key);
        }

        protected virtual IBinarySearchTreeNode<TKey, TValue> Search(IBinarySearchTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null)
            {
                return null;
            }

            int compareResult = root.Key.CompareTo(key);

            if (compareResult > 0)
            {
                return Search(root.LeftChild, key);
            }
            else if (compareResult < 0)
            {
                return Search(root.RightChild, key);
            }

            return root;
        }

        public virtual IBinarySearchTreeNode<TKey, TValue> Insert(TKey key, TValue value)
        {
            IBinarySearchTreeNode<TKey, TValue> newNode = new BinarySearchTreeNode<TKey, TValue>(key, value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                // Insert(root, newNode);
                NonRecursiveInsert(root, newNode);
            }

            return newNode;
        }

        private void NonRecursiveInsert(IBinarySearchTreeNode<TKey, TValue> root, IBinarySearchTreeNode<TKey, TValue> newNode)
        {
            while (true)
            {
                if (root.Key.CompareTo(newNode.Key) > 0)
                {
                    if (root.LeftChild == null)
                    {
                        root.LeftChild = newNode;
                        return;
                    }
                    else
                    {
                        root = root.LeftChild;
                    }
                }
                else
                {
                    if (root.RightChild == null)
                    {
                        root.RightChild = newNode;
                        return;
                    }
                    else
                    {
                        root = root.RightChild;
                    }
                }
            }
        }

        private void Insert(IBinarySearchTreeNode<TKey, TValue> root, IBinarySearchTreeNode<TKey, TValue> newNode)
        {
            if (root.Key.CompareTo(newNode.Key) > 0)
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = newNode;
                }
                else
                {
                    Insert(root.LeftChild, newNode);
                }
            }
            else
            {
                if (root.RightChild == null)
                {
                    root.RightChild = newNode;
                }
                else
                {
                    Insert(root.RightChild, newNode);
                }
            }
        }

        public IEnumerable<IBinarySearchTreeNode<TKey, TValue>> TraverseInOrder()
        {
            IList<IBinarySearchTreeNode<TKey, TValue>> result = new List<IBinarySearchTreeNode<TKey, TValue>>();

            TraverseInOrder(root, result.Add);

            return result;
        }

        private void TraverseInOrder(IBinarySearchTreeNode<TKey, TValue> root, Action<IBinarySearchTreeNode<TKey, TValue>> yielder)
        {
            if (root == null)
            {
                return;
            }

            TraverseInOrder(root.LeftChild, yielder);
            yielder(root);
            TraverseInOrder(root.RightChild, yielder);
        }

        public int GetHeight()
        {
            return GetHeight(root);
        }

        private int GetHeight(IBinarySearchTreeNode<TKey, TValue> root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(
                root.LeftChild != null ? 1 + GetHeight(root.LeftChild) : 0,
                root.RightChild != null ? 1 + GetHeight(root.RightChild) : 0);
        }

        #region Removing

        public bool Remove(TKey key)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Key.CompareTo(key) == 0)
            {
                root = GetNewChildAfterRemoving(root);
                return true;
            }

            return Remove(root, key);
        }

        private bool Remove(IBinarySearchTreeNode<TKey, TValue> parent, TKey key)
        {
            if (parent == null)
            {
                return false;
            }

            if (parent.Key.CompareTo(key) > 0)
            {
                if (parent.LeftChild != null && parent.LeftChild.Key.CompareTo(key) == 0)
                {
                    parent.LeftChild = GetNewChildAfterRemoving(parent.LeftChild);
                    return true;
                }
                else
                {
                    return Remove(parent.LeftChild, key);
                }
            }
            else
            {
                // if (parent.Key.CompareTo(key) < 0)
                // we exclude case where parent.Key.CompareTo(key) == 0 in the public Remove(key) method 
                if (parent.RightChild != null && parent.RightChild.Key.CompareTo(key) == 0)
                {
                    parent.RightChild = GetNewChildAfterRemoving(parent.RightChild);
                    return true;
                }
                else
                {
                    return Remove(parent.RightChild, key);
                }
            }
        }

        private IBinarySearchTreeNode<TKey, TValue> GetNewChildAfterRemoving(IBinarySearchTreeNode<TKey, TValue> removedNode)
        {
            if (!removedNode.HasChildren)
            {
                return null;
            }
            else
            {
                if (removedNode.LeftChild == null)
                {
                    return removedNode.RightChild;
                }
                else if (removedNode.RightChild == null)
                {
                    return removedNode.LeftChild;
                }
                else // has two children
                {
                    IBinarySearchTreeNode<TKey, TValue> parent = removedNode;
                    IBinarySearchTreeNode<TKey, TValue> leftmostNodeInTheRightSubtree = removedNode.RightChild;
                    while (leftmostNodeInTheRightSubtree.LeftChild != null)
                    {
                        parent = leftmostNodeInTheRightSubtree;
                        leftmostNodeInTheRightSubtree = leftmostNodeInTheRightSubtree.LeftChild;
                    }

                    if (parent != removedNode)
                    {
                        // leftmostNodeInTheRightSubtree may has ONLY a right child
                        // we was moving to the left all the time, 
                        // thus we have to set a new left child for parent of leftmostNodeInTheRightSubtree
                        parent.LeftChild = leftmostNodeInTheRightSubtree.RightChild;
                        leftmostNodeInTheRightSubtree.RightChild = removedNode.RightChild;
                    }

                    leftmostNodeInTheRightSubtree.LeftChild = removedNode.LeftChild;

                    return leftmostNodeInTheRightSubtree;
                }
            }
        }

        #endregion

        public void Mirror()
        {
            Mirror(root);
        }

        private void Mirror(IBinarySearchTreeNode<TKey, TValue> root)
        {
            if (root == null)
            {
                return;
            }

            Mirror(root.LeftChild);
            Mirror(root.RightChild);

            // swap left and right subtree
            IBinarySearchTreeNode<TKey, TValue> tmp = root.LeftChild;
            root.LeftChild = root.RightChild;
            root.RightChild = tmp;
        }

        public IBinarySearchTreeNode<TKey, TValue> LCA(IBinarySearchTreeNode<TKey, TValue> node1, IBinarySearchTreeNode<TKey, TValue> node2)
        {
            // we assume that node1 and node2  have already placed in the tree

            if (node1.Key.CompareTo(node2.Key) > 0)
            {
                IBinarySearchTreeNode<TKey, TValue> tmp = node1;
                node1 = node2;
                node2 = tmp;
            }

            return LCA(root, node1, node2);
        }

        private IBinarySearchTreeNode<TKey, TValue> LCA(IBinarySearchTreeNode<TKey, TValue> root, IBinarySearchTreeNode<TKey, TValue> node1, IBinarySearchTreeNode<TKey, TValue> node2)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Key.CompareTo(node1.Key) >= 0 && root.Key.CompareTo(node2.Key) <= 0) // if tree has duplicates, all of them in the right subtree (see insert method)
            {
                return root;
            }

            if (root.Key.CompareTo(node1.Key) > 0 && root.Key.CompareTo(node2.Key) > 0)
            {
                return LCA(root.LeftChild, node1, node2);
            }
            else
            {
                return LCA(root.RightChild, node1, node2);
            }
        }
    }
}