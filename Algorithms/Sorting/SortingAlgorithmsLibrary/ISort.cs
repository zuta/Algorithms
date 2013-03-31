using System;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public interface ISort<T>
        where T : IComparable<T>
    {
        void Sort(T[] array);
    }
}
