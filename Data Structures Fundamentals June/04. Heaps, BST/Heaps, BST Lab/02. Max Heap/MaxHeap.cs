namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public void Add(T element)
        {
            this.heap.Add(element);
            Heapify(this.heap.Count - 1);
        }

        private void Heapify(int indx)
        {
            if (indx == 0)
            {
                return;
            }

            int parentIndx = (indx - 1) / 2;

            if (this.heap[indx].CompareTo(this.heap[parentIndx]) > 0)
            {
                T temp = this.heap[indx];
                this.heap[indx] = this.heap[parentIndx];
                this.heap[parentIndx] = temp;
                Heapify(parentIndx);
            }
        }

        public T Peek()
        {
            if (this.heap.Count == 0)
            {
                 throw new InvalidOperationException();
            }

            return this.heap[0];
        }
    }
}
