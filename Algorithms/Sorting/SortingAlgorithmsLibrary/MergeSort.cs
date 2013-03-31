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
            T[] temp = InnerSort(array, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        private T[] InnerSort(T[] array, int left, int right)
        {
            if (left == right)
            {
                return array;
            }

            int middle = (right + left) / 2;

            // copy left part of array
            T[] lefterArray = new T[middle - left + 1];
            Array.Copy(array, left, lefterArray, 0, middle - left + 1);

            // copy right part of array
            T[] righterArray = new T[array.Length - middle - 1];
            Array.Copy(array, middle + 1, righterArray, 0, array.Length - middle - 1);

            // sort each part
            T[] lefterResult = InnerSort(lefterArray, 0, lefterArray.Length - 1);
            T[] righterResult = InnerSort(righterArray, 0, righterArray.Length - 1);

            // return merged result
            return Marge(lefterResult, righterResult);
        }

        private T[] Marge(T[] lefterArray, T[] righterArray)
        {
            int n = lefterArray.Length + righterArray.Length;

            T[] result = new T[n];

            int i = 0;
            int j = 0;
            for (int p = 0; p < n; p++)
            {
                if (i < lefterArray.Length && 
                        (j == righterArray.Length || lefterArray[i].CompareTo(righterArray[j]) < 0))
                {
                    result[p] = lefterArray[i++];
                }
                else
                {
                    result[p] = righterArray[j++];
                }
            }

            return result;
        }
    }
}
