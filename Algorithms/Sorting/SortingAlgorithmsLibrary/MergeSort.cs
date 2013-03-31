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
            T[] temp = InnerSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        private T[] InnerSort(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;

            // copy left part of array
            T[] lefterArray = new T[middle];
            Array.Copy(array, 0, lefterArray, 0, middle);

            // copy right part of array
            T[] righterArray = new T[array.Length - middle];
            Array.Copy(array, middle, righterArray, 0, array.Length - middle);

            // sort each part
            lefterArray = InnerSort(lefterArray);
            righterArray = InnerSort(righterArray);

            // return merged result
            return Merge(lefterArray, righterArray);
        }

        private T[] Merge(T[] lefterArray, T[] righterArray)
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
