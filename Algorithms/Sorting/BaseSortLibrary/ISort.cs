using System;

namespace BaseSortLibrary
{
    public interface ISort<T>
        where T : IComparable<T>
    {
        void Sort(T[] array);
    }
}
