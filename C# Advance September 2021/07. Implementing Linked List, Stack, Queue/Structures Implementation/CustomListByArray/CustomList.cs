namespace CustomListByArray
{
    using System;

    public class CustomList<T>
    {
        private T[] elements { get; set; }

        private const int InitialCapasity = 2;

        public CustomList()
        {
            elements = new T[InitialCapasity];
        }

        public int Count { get ; private set;}

        public T this[int index]
        {
            get
            {
                if (!IsIndxValid(index))
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                return elements[index];
            }
            set
            {
                if (!IsIndxValid(index))
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                elements[index] = value;            
            }
        }

        public void Add(T item)
        {
            if (Count == elements.Length)
            {
                Resize();
            }

            elements[Count] = item;
            Count++;
        }       

        public T RemoveAt(int index)
        {
            if (!IsIndxValid(index))
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            T elementToRemove = elements[index];
            elements[index] = default;
            
            Shift(index);
            Count--;

            if (Count <= elements.Length / 4)
            {
                Shrink();
            }

            return elementToRemove;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndx, int secondIndx)
        {
            if (!IsIndxValid(firstIndx) || !IsIndxValid(secondIndx))
            {
                throw new ArgumentOutOfRangeException();
            }

            T temp = elements[firstIndx];
            elements[firstIndx] = elements[secondIndx];
            elements[secondIndx] = temp; 
        }

        public void Reverse()
        {
            Array.Reverse(elements, 0, Count); 
        }

        public override string ToString()
        {
            return string.Join(' ', elements[0..Count]);
        }

        private void Resize()
        {
            T[] tempArray = new T[elements.Length * 2];
            Array.Copy(elements, tempArray, Count);
            elements = tempArray;
        }

        private void Shrink()
        {
            T[] tempArray = new T[elements.Length / 2];
            Array.Copy(elements, tempArray, Count);
            elements = tempArray;
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            elements[Count - 1] = default;
        }

        private bool IsIndxValid(int indx) => indx >= 0 && indx < Count;        
    }
}
