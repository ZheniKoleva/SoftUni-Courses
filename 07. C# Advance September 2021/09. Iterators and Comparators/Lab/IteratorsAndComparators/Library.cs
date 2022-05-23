namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] libraryBooks)
        {
            books = new SortedSet<Book>(libraryBooks, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(books);
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IList<Book> books;

            private int indx = -1;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = new List<Book>(books);
            }

            public Book Current => books[indx];

            object IEnumerator.Current => Current;           

            public bool MoveNext()
            {
                indx++;
                return indx >= 0 && indx < books.Count;
            }

            public void Reset() => indx = -1;

            public void Dispose() { }            
        }
    }
}
