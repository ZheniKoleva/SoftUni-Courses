namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private readonly List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public int Count => items.Count; 
        
        public void Add(T element)
        {
            items.Add(element);
        }

        public T Remove()
        {
            T itemToRemove = items[^1];
            items.RemoveAt(items.Count - 1);
            
            return itemToRemove;
        }        
    }
}
