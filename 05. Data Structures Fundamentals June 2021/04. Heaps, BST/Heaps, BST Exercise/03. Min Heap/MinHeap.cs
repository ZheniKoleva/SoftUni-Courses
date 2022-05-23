namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MinHeap()
        {
            this.heap = new List<T>();
        }

        public int Size => this.heap.Count;

        public T Dequeue()
        {
            this.IsEmpty();      

            T minElement = this.heap[0]; 
            this.heap[0] = this.heap[this.heap.Count - 1]; 
            //Swap(0, this.heap.Count - 1); 
            this.heap.RemoveAt(this.heap.Count - 1); 
            HeapifyDown(0); 

            return minElement;
        }       

        public void Add(T element)
        {
            this.heap.Add(element);
            Heapify(this.heap.Count - 1);
        }

        public T Peek()
        {
            IsEmpty();
           
            return this.heap[0];
        }

        private void Heapify(int indx) 
        {
            if (indx == 0)
            {
                return;
            }
            
            int indxParent = (indx - 1) / 2;

            if (IsSmaller(indx, indxParent))            
            {
                Swap(indxParent, indx);
                Heapify(indxParent);
            }
            
        }        

        private void Swap(int first, int second)
        {
            T temp = this.heap[first];   
            this.heap[first] = this.heap[second]; 
            this.heap[second] = temp;  
        } 

        private void HeapifyDown(int startIndx) 
        {
            int leftIndx = (startIndx * 2) + 1;
            int rightIndx = (startIndx * 2) + 2;

            if (leftIndx >= this.heap.Count)
            {
                return;
            }

            int minIndx = leftIndx; ло

            if (rightIndx < this.heap.Count
                && IsSmaller(rightIndx, leftIndx))               
            {
                minIndx = rightIndx;
            }

            if (IsSmaller(minIndx, startIndx))
            {
                Swap(startIndx, minIndx);
                HeapifyDown(minIndx);
            }          

        }
      

        private void IsEmpty()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private bool IsSmaller(int firstIndx, int secondIndx)
        {
            return this.heap[firstIndx].CompareTo(this.heap[secondIndx]) < 0;
        }
    }
}
