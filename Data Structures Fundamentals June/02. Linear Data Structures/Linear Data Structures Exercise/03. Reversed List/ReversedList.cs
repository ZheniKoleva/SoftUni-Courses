namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {

        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) 
        { 
        
        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.items[this.Count - 1 - index];                
            }
            set
            {
                this.ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)   
        {                          
            IsResizeNeeded();
            this.items[this.Count] = item;  
            this.Count++;
        }       

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++) 
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.IsResizeNeeded();         
           
            int indxToInsert = this.Count - index;

            for (int i = this.Count; i > indxToInsert; i--) 
            {                                                 
                this.items[i] = this.items[i - 1];
            }

            this.items[indxToInsert] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {     
            int indx = this.IndexOf(item);

            if (indx == -1)
            {
                return false;
            }
            
            this.RemoveAt(indx);

            return true;
            
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--) 
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateIndex(int index) 
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }            
        }

        private void IsResizeNeeded()
        {
            if (this.Count == this.items.Length) 
            {
                Resize();
            }
        }

        private void Resize()
        {
            T[] newArray = new T[this.items.Length * 2];

            Array.Copy(this.items, 0, newArray, 0, this.Count);

            this.items = newArray;            
        }
    }
}