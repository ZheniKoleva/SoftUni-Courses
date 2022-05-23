namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {        
        private List<T> heap;

        public PriorityQueue()
        {            
            this.heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public T Dequeue()
        {
            IsQueueEmpty();
            
            T firstElement = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return firstElement;
        }        

        private void HeapifyDown(int indx)
        {
            int indxLeft = (2 * indx) + 1;
            int indxRight = (2 * indx) + 2;

            if (indxLeft >= heap.Count)
            {
                return;
            }

            int maxIndx = indxLeft; 

            if (indxRight <= heap.Count - 1 
                && heap[indxLeft].CompareTo(heap[indxRight]) < 0) 
            {
                maxIndx = indxRight;
            }

            if (heap[indx].CompareTo(heap[maxIndx]) < 0)                  
            {
                Swap(indx, maxIndx);               
                HeapifyDown(maxIndx);
            }          
           
        }

        public void Add(T element)
        {
            heap.Add(element);

            Heapify(heap.Count - 1);            
        }

        private void Heapify(int indx)
        {
            if (indx == 0)
            {
                return;
            }

            int parentIndx = (indx - 1) / 2;

            if (heap[indx].CompareTo(heap[parentIndx]) > 0)
            {
                Swap(indx, parentIndx);                
                Heapify(parentIndx);
            }
        }

        public T Peek()
        {
            IsQueueEmpty();

            return heap[0];
        }

        private void Swap(int firstIndx, int secondIndx)
        {
            T temp = heap[firstIndx];
            heap[firstIndx] = heap[secondIndx];
            heap[secondIndx] = temp;
        }        

        private void IsQueueEmpty()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
