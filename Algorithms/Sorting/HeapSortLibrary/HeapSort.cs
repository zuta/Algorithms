﻿using BaseSortLibrary;
using BinaryHeapLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortLibrary
{
    public class HeapSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            BinaryHeap<T> heap = new BinaryHeap<T>(Comparer<T>.Default.Compare);

            foreach (T item in array)
            {
                heap.Insert(item);
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = heap.GetTheBest();
                heap.DeleteTheBest();
            }
        }
    }
}
