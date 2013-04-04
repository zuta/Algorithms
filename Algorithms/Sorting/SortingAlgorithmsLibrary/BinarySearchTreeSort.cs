using Algorithms.DataStructure.BinarySearchTree.BinarySearchTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class BinarySearchTreeSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            IBinarySearchTree<T, bool> tree = new BinarySearchTree<T, bool>();
            foreach (T item in array)
            {
                tree.Insert(item, true);
            }

            int i = 0;
            foreach (var node in tree.Traverse())
            {
                array[i++] = node.Key;
            }
        }

    }
}
