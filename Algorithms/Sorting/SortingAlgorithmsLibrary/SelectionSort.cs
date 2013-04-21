using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public class SelectionSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minPos = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minPos]) < 0)
                    {
                        minPos = j;
                    }
                }

                if (i != minPos)
                {
                    T tmp = array[i];
                    array[i] = array[minPos];
                    array[minPos] = tmp;
                }
            }
        }

        public string Name
        {
            get { return "SelectionSort"; }
        }
    }
}
