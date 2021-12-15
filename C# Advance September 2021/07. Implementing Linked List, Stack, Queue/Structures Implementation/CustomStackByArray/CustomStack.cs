namespace CustomStackByArray
{
    using System;

    public class CustomStack<T>
    {
        private T[] elements;

        private const int InitialCapacity = 4;

        private int count = 0;

        public CustomStack()
        {
            elements = new T[InitialCapacity];
        }

        public int Count => count;

        public void Push(T item)
        {
            if (count == elements.Length)
            {
                Resize();
            }

            elements[count] = item;
            count++;
        }

        public T Pop()
        {
            IsEmpty();
            T elementToRemove = elements[count - 1];
            elements[count - 1] = default;

            count--;

            if (count <= elements.Length / 4)
            {
                Shrink();
            }

            return elementToRemove;
        }       

        public T Peek()
        {
            IsEmpty();

            return elements[count - 1];
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

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new ArgumentOutOfRangeException("The stack is empty");
            }
        }
    }
}
