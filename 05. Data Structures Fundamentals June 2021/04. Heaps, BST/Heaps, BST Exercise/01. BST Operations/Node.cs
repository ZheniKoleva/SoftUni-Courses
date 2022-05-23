namespace _01.BSTOperations
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}
