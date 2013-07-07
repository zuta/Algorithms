using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class PancakeSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public string Name
        {
            get { return "PancakeSort"; }
        }

        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Flip(array, minIndex);
                    Flip(array, i);
                }
            }
        }

        private void Flip(T[] array, int index)
        {
            int left = index;
            int right = array.Length - 1;

            while (left < right)
            {
                Swap(array, left++, right--);
            }
        }

        private void Swap(T[] array, int x, int y)
        {
            T tmp = array[x];
            array[x] = array[y];
            array[y] = tmp;
        }
    }
}
