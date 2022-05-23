
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> data;

        public CustomStack()
        {
            data = new List<T>();
        }

        public void Push(params T[] collection)
        {
            data.AddRange(collection);
        }

        public T Pop()
        {
            IsEmpty();

            T topElement = data[^1];
            data.RemoveAt(data.Count - 1);

            return topElement;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0 ; i--)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void IsEmpty()
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("No elements");
            }            
        }

    }
}
