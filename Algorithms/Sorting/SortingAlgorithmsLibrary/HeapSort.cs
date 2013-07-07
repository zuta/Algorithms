using Algorithms.DataStructure.BinaryHeap.BinaryHeapLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
	public class HeapSort<T> : ISort<T>
		where T : IComparable<T>
	{
		public string Name
		{
			get { return "HeapSort"; }
		}

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
