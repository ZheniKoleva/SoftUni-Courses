namespace CustomLinkedList
{
    using System;

    public class LinkedList<T>
    {

        private Node<T> head;        

        private int count = 0;

        public int Count => this.count;

        public void AddFirst(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.count == 0)
            {
                this.head = newNode;               
            }
            else
            {
                Node<T> oldHead = this.head;
                newNode.Next = oldHead;                
                this.head = newNode;
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

            if (this.head != null)
            {
                this.head = elementToRemove.Next;
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

            int counter = 0;

            Node<T> currentElement = this.head;

            while (currentElement != null)
            {
                array[counter] = currentElement.Value;
                counter++;
                currentElement = currentElement.Next;
            }

            return array;
        }

    }
}
