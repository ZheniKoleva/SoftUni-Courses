namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }

       // public Node<T> Previous { get; set; }

        public Node(T item)
        {
            this.Item = item;
            this.Next = null;
           // this.Previous = null;
        }
    }
}