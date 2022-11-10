namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head == null)
            {
                this._head = newNode;
            }
            else
            {
                Node<T> oldhead = this._head;
                this._head = newNode;
                newNode.Next = oldhead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head == null)
            {
                this._head = newNode;
            }
            else
            {
                Node<T> currentNode = this._head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;                
            }

            this.Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return this._head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            Node<T> currentNode = this._head;

            if (this.Count == 1)
            {
                return currentNode.Item;
            }           

            while (currentNode.Next != null) { 
           
                currentNode = currentNode.Next;
            }

            return currentNode.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            Node<T> oldHead = this._head;

            if (this.Count == 1)
            {
                this._head = null;
            }
            else
            {
                this._head = oldHead.Next;
            }

            this.Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            Node<T> currentNode = this._head;
            T itemToRemove = default;

            if (this.Count == 1)
            {
                itemToRemove = currentNode.Item;
                this._head = null;
            }
            else
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                itemToRemove = currentNode.Next.Item;
                currentNode.Next = null;
            }

            this.Count--;

            return itemToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this._head;

            while (currentNode != null)
            {
                yield return currentNode.Item;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
       
        
        private void EnsureNotEmpty()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}