namespace CustomLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
           
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
       
    }
}
