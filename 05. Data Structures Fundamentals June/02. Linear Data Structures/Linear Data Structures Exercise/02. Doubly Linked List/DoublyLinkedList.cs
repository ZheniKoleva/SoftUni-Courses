namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newElement = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = newElement;
                this.tail = newElement;
            }
            else
            {                
                Node<T> oldHead = this.head;
                this.head = newElement;
                oldHead.Previous = newElement;
                this.head.Next = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newElement = new Node<T>(item);

            if (this.Count == 0)
            {                
                this.head = newElement;
                this.tail = newElement;
            }
            else
            {
                Node<T> oldTail = this.tail;
                this.tail = newElement;
                oldTail.Next = newElement;
                this.tail.Previous = oldTail;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            IsListEpmty();

            return this.head.Item;
        }

        public T GetLast()
        {
            IsListEpmty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            IsListEpmty();

            Node<T> firstElement = this.head;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next; 
                this.head.Previous = null;
            }           

            this.Count--;

            return firstElement.Item;
        }

        public T RemoveLast()
        {
            IsListEpmty();

            Node<T> lastElement = this.tail;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }            

            this.Count--;

            return lastElement.Item;
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

        private void IsListEpmty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}