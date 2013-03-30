using System;

namespace BinaryHeapLibrary
{
    public interface IHeap<T>
    {
        int Count { get; }

        void Insert(T item);

        bool DeleteTheBest();

        T GetTheBest();
    }
}
