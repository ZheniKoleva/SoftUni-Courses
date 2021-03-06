namespace GenericCountMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Box<T> where T: IComparable
    {
        private readonly List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Swap(int firstIndx, int secondIndx)
        {
            T temp = items[firstIndx];
            items[firstIndx] = items[secondIndx];
            items[secondIndx] = temp;
        }

        public int GetGreater(T elementToCompare)
        {
            return items.Where(x => x.CompareTo(elementToCompare) > 0).Count();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (var item in items)
            {
                output.AppendLine($"{item.GetType()}: {item}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
