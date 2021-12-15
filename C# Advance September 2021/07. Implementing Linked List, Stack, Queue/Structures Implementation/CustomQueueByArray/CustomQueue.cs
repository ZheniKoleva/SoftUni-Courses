namespace CustomQueueByArray
{
    using System;

    public class CustomQueue<T>
    {
        private T[] elements;

        private const int InitialCapacity = 4;

        private int count = 0;

        public CustomQueue()
        {
            elements = new T[InitialCapacity];
        }

        public int Count => count;

        public void Enqueue(T item)
        {
            if (count == elements.Length)
            {
                Resize();
            }

            elements[count] = item;
            count++;
        }

        public T Dequeue()
        {
            IsEmpty();

            T firstElement = elements[0];
            elements[0] = default;

            SwitchElements();
            count--;

            if (count <= elements.Length / 4)
            {
                Shrink();
            }

            return firstElement;
        }       

        public T Peek()
        {
            IsEmpty();

            return elements[0];
        }

        public void Clear() 
        {
            IsEmpty();
            Array.Clear(elements, 0, count);
            count = 0;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(elements[i]);
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[elements.Length * 2];
            Array.Copy(elements, tempArray, count);
            elements = tempArray;
        }

        private void Shrink()
        {
            T[] tempArray = new T[elements.Length / 2];
            Array.Copy(elements, tempArray, count);
            elements = tempArray;
        }

        private void SwitchElements()
        {
            for (int i = 1; i < count; i++)
            {
                elements[i - 1] = elements[i];
            }

            elements[count - 1] = default;
        }

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("The queue is empty");
            }
        }

    }
}
