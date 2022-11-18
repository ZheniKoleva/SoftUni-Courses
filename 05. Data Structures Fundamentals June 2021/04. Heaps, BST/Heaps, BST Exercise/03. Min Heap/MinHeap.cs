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

            T minElement = this.heap[0]; // вземаме мин елемент            
            Swap(0, this.heap.Count - 1); // разменяме най-малкият с май-големият елемент
            this.heap.RemoveAt(this.heap.Count - 1); // изтриваме последният
            this.HeapifyDown(0); // намираме правилното място на бившият последен елемент

            return minElement;
        }       

        public void Add(T element)
        {
            this.heap.Add(element);
            this.HeapifyUp(this.heap.Count - 1);
        }

        public T Peek()
        {
            this.IsEmpty();
           
            return this.heap[0];
        }

        private void HeapifyUp(int indx) 
        {
            if (indx == 0)
            {
                return;
            }
            
            int indxParent = (indx - 1) / 2;

            if (this.IsSmaller(indx, indxParent)) // ако елемента, който сме вкарали последен e по-малък от родителя, трябва да го преместим             
            {
                this.Swap(indxParent, indx);
                this.HeapifyUp(indxParent);
            }

            //while (IsSmaller(indx, indxParent))
            //{
            //    Swap(indx, indxParent);
            //    indx = indxParent;
            //    indxParent = (indx - 1) / 2;
            //}
        }        

        private void Swap(int first, int second)   //   0  5
        {
            T temp = this.heap[first];             // 5 
            this.heap[first] = this.heap[second];  // 0 става 5
            this.heap[second] = temp;              // 5 става 0
        } 

        private void HeapifyDown(int startIndx) 
        {
            int leftIndx = (startIndx * 2) + 1;
            int rightIndx = (startIndx * 2) + 2;

            if (leftIndx >= this.heap.Count)
            {
                return;
            }

            int minIndx = leftIndx; // тръгваме към индекса където е по-малкото число

            if (rightIndx < this.heap.Count && this.IsSmaller(rightIndx, leftIndx))               
            {
                minIndx = rightIndx;
            }

            if (this.IsSmaller(minIndx, startIndx))
            {
                this.Swap(startIndx, minIndx);
                this.HeapifyDown(minIndx);
            }


            //int smallerChildIndx = (startIndx * 2) + 1;
            //smallerChildIndx = FindSmallerChild(smallerChildIndx, smallerChildIndx + 1);

            //while (smallerChildIndx != -1 && IsSmaller(smallerChildIndx, startIndx))
            //{
            //    Swap(smallerChildIndx, startIndx);
            //    startIndx = smallerChildIndx;
            //    smallerChildIndx = FindSmallerChild(startIndx * 2 + 1, startIndx * 2 + 2);
            //}
        }

        private int FindSmallerChild(int leftChildIndx, int rightChildIndx)
        {
            if (leftChildIndx >= this.Size)
            {
                return -1;
            }

            if (rightChildIndx >= this.Size)
            {
                return leftChildIndx;
            }

            return IsSmaller(leftChildIndx, rightChildIndx) ? leftChildIndx : rightChildIndx;
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
