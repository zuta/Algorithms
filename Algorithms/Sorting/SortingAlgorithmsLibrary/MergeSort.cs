using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class MergeSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            T[] auxiliaryArray = new T[array.Length];

            InnerSort(array, auxiliaryArray, 0, array.Length - 1);
        }

        private void InnerSort(T[] array, T[] auxiliaryArray, int left, int right)
        {
            if (right == left)
            {
                return;
            }

            int middle = left + (right - left) / 2;

            InnerSort(array, auxiliaryArray, left, middle);
            InnerSort(array, auxiliaryArray, middle + 1, right);

            Merge(array, auxiliaryArray, left, right);
        }

        private void Merge(T[] array, T[] auxiliaryArray, int left, int right)
        {
            // copy array
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
