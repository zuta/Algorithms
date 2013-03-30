using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapLibrary
{
    public class BinaryHeap<T> : IHeap<T>
    {
        private List<T> items;
        private Comparison<T> compareFunction;

        public BinaryHeap(Comparison<T> comparer)
        {
            this.compareFunction = comparer;
            this.items = new List<T>();
        }

        public void Insert(T item)
        {
            this.items.Add(item);

            HeapifyUp(this.items.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index != 0)
            {
                int parentIndex = index % 2 == 0 ? index / 2 - 1 : index / 2;

                if (this.compareFunction(this.items[index], this.items[parentIndex]) > 0)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            T temp = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = temp;
        }

        public bool DeleteTheBest()
        {
            bool result = false;

            if (this.items.Count > 0)
            {
                Swap(0, this.items.Count - 1);

                this.items.RemoveAt(this.items.Count - 1);

                HeapifyDown(0);

                result = true;
            }

            return result;
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftSonIndex = index * 2 + 1;
                int rightSonIndex = index * 2 + 2;

                bool hasLeftSon = leftSonIndex < this.items.Count;
                bool hasRightSon = rightSonIndex < this.items.Count;

                if (!hasLeftSon && !hasRightSon)
                {
                    break;
                }

                int bestSonIndex = leftSonIndex;
                if (hasRightSon && this.compareFunction(this.items[rightSonIndex], this.items[leftSonIndex]) > 0)
                {
                    bestSonIndex = rightSonIndex;
                }

                if (this.compareFunction(this.items[bestSonIndex], this.items[index]) > 0)
                {
                    Swap(index, bestSonIndex);
                    index = bestSonIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T FindTheBest()
        {
            if (this.items.Count > 0)
            {
                return this.items[0];
            }

            return default(T);
        }

        public int Count
        {
            get { return this.items.Count; }
        }
    }
}