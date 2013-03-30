using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapLibrary
{
    public interface IHeap<T>
    {
        int Count { get; }

        void Insert(T item);

        bool DeleteTheBest();

        T FindTheBest();
    }
}
