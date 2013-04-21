using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class QuickSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int left, int right)
        {
            if (right - left > 1)
            {
                int l = left, r = right;
                T m = array[l + (r - l) / 2];

                while (l <= r)
                {
                    while (array[l].CompareTo(m) < 0) l++;
                    while (array[r].CompareTo(m) > 0) r--;
                    if (l <= r)
                    {
                        T tmp = array[l];
                        array[l++] = array[r];
                        array[r--] = tmp;
                    }
                }

                Sort(array, left, r);
                Sort(array, l, right);
            }
        }

        public string Name
        {
            get { return "QuickSort"; }
        }
    }
}
