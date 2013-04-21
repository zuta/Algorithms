using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class InsertionSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(array[i]) > 0) j--;

                T tmp = array[i];
                array[i] = array[j + 1];
                array[j + 1] = tmp;
            }
        }

        public string Name
        {
            get { return "InsertionSort"; }
        }
    }
}
