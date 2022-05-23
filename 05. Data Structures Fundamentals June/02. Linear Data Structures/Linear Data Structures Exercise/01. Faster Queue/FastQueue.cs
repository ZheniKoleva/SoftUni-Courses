namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            IsQueueEpmty();
            
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
            IsQueueEpmty();

            Node<T> oldHead = this.head;            
            this.head = oldHead.Next;
            this.Head.Previous = null;
            oldHead.Next = null;            

            this.Count--;

            return oldHead.Item;            
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this.Count == 0)
            { 
                this.head = newNode;
                this.tail = newNode;               
                
            }
            else
            {
                Node<T> currentTail = this.tail;  
                this.tail = newNode;               
                currentTail.Next = this.tail;
            }           

            this.Count++;
        }

        public T Peek()
        {
            IsQueueEpmty();

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Item;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IsQueueEpmty() 
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}