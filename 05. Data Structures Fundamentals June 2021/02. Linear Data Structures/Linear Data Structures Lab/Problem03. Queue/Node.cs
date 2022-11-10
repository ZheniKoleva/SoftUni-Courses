namespace Problem03.Queue
{
    public class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }        

        public Node(T item)
        {
            this.Item = item;
            this.Next = null;          
        }
    }
}