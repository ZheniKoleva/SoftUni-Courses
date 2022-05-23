namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;        

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            this.EnsureNotEmpty();

            Node<T> current = this._head;

            while (current.Next != null)
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

            T firstNodeItem = this._head.Item;

            if (this.Count == 1)
            {
                this._head = null;
            }
            else
            {
                this._head = this._head.Next;                
            }           

            this.Count--;          

            return firstNodeItem;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head == null)
            {                
                this._head = newNode;
            }
            else
            {
                Node<T> current = this._head;

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

            return this._head.Item;
        }        

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

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
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}