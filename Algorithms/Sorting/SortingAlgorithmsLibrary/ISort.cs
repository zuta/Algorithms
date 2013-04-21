using System;

namespace Algorithms.Sorting.SortingAlgorithmsLibrary
{
    public interface ISort<T>
        where T : IComparable<T>
    {
		string Name { get; }

        void Sort(T[] array);
    }
}
