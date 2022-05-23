namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public Node(T item)
        {
            this.Item = item;
            this.Next = null;
            this.Previous = null;
        }

        //public Node(T item, Node<T> next, Node<T> previous)
        //{
        //    this.Item = item;
        //    this.Next = next;
        //    this.Previous = previous;
        //}

        public Node()
        {
           
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        
    }
}