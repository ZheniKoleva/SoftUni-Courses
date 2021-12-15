namespace _01.ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly IList<T> data;

        private int indx = 0;

        public ListyIterator(params T[] collection)
        {
            data = new List<T>(collection);
        }

        public bool HasNext() => (indx + 1) < data.Count;

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                indx++;                
            }

            return canMove;
        }

        public void Print()
        {
            IsEmpty();
            
            Console.WriteLine(data[indx]);            
        }

        public void PrintAll()
        {
            IsEmpty();

            Console.Write(string.Join(' ', data));
            Console.WriteLine();
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return data[i];
            }          
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();       

        private void IsEmpty()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
