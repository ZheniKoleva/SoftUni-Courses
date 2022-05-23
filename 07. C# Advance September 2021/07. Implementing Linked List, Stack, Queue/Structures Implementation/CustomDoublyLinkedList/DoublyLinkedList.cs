namespace CustomDoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;

        private Node<T> tail = null;

        private int count = 0;

        public int Count => this.count;

        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.count == 0)
            {                
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                Node<T> oldHead = this.head;
                newNode.Next = oldHead;
                oldHead.Previous = newNode;
                this.head = newNode;                
            }

            this.count++;        
        }

        public void AddLast(T element) 
        {
            Node<T> newNode = new Node<T>(element);

            if (this.count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                Node<T> oldTail = this.tail;
                newNode.Previous = oldTail;
                oldTail.Next = newNode;
                this.tail = newNode;                
            }

            this.count++;
        }

        public T RemoveFirst()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            Node<T> elementToRemove = this.head;            
            this.head = elementToRemove.Next;
            elementToRemove.Next = null;

            if (this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {                
                this.tail = null;
            }

            this.count--;

            return elementToRemove.Value;
        }

        public T RemoveLast()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            Node<T> elementToRemove = this.tail;
            this.tail = elementToRemove.Previous;
            elementToRemove.Previous = null;

            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.count--;

            return elementToRemove.Value;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> currentElement = this.head;

            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.count];

            int indx = 0;

            Node<T> currentElement = this.head;

            while (currentElement != null)
            {
                array[indx] = currentElement.Value;
                indx++;
                currentElement = currentElement.Next;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current.Next != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
