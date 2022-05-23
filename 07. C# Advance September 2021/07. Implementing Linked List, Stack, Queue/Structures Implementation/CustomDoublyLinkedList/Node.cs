namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }        

    }
}
