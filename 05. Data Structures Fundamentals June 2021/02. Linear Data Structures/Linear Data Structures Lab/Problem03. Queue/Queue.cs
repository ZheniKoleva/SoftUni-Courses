namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {        
        private Node<T> head;        

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            this.EnsureNotEmpty();

            Node<T> current = this.head;            

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            Node<T> oldHead = this.head;

            if (this.Count == 1)
            {
                this.head = null;
            }
            else
            {               
                this.head = oldHead.Next;
            }           

            this.Count--;          

            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this.head == null)
            {                
                this.head = newNode;                
            }
            else
            {
                Node<T> current = this.head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
            
            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }        

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}