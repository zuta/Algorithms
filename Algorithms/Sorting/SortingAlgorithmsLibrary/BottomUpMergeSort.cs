using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
	public class BottomUpMergeSort<T> : ISort<T>
		where T : IComparable<T>
	{
		public string Name
		{
			get { return "BottomUpMergeSort"; }
		}

		public void Sort(T[] array)
		{
			T[] auxiliaryArray = new T[array.Length];

			for (int size = 2; size < array.Length; size += size)
			{
				for (int i = 0; i < array.Length; i += size)
				{
					Merge(array, auxiliaryArray, i, Math.Min(array.Length - 1, i + size - 1));
				}
			}
		}

		private void Merge(T[] array, T[] auxiliaryArray, int left, int right)
		{
			Array.Copy(array, left, auxiliaryArray, left, right - left + 1);

			int middle = left + (right - left) / 2;

			int i = left;
			int j = middle + 1;

			for (int p = left; p <= right; p++)
			{
				if (i > middle)
				{
					Array.Copy(auxiliaryArray, j, array, p, right - p + 1);
					break;
				}
				else if (j > right)
				{
					Array.Copy(auxiliaryArray, i, array, p, right - p + 1);
					break;
				}

				if (auxiliaryArray[i].CompareTo(auxiliaryArray[j]) < 0)
				{
					array[p] = auxiliaryArray[i++];
				}
				else
				{
					array[p] = auxiliaryArray[j++];
				}
			}
		}
	}
}
