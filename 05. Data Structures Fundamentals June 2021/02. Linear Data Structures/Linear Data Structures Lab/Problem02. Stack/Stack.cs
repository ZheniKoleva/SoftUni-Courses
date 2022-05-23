namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private List<Node<T>> nodes;
        
        private Node<T> _top;       

        private int itemsCount;        

        public int Count => this.itemsCount; 

        public Stack()
        {
            this.nodes = new List<Node<T>>();
            itemsCount = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                if (this.nodes[i].Item.Equals(item))
                {
                    return true;
                }
            }  

            return false;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._top.Item;
        }       

        public T Pop()
        {
            this.EnsureNotEmpty();

            T topNodeItem = this._top.Item;
            Node<T> newTop = this._top.Next;
            this._top.Next = null;
            this._top = newTop;

            this.itemsCount--;

            return topNodeItem;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = this._top;
            this._top = newNode;
            this.itemsCount++;

            this.nodes.Add(newNode);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._top;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.itemsCount <= 0)
            {
                throw new InvalidOperationException(nameof(this.itemsCount));
            }           
        }
    }
}