namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {

        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
            LeftChild = root.LeftChild;
            RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            return ContainsBST(element, this.Root);
        }

        private bool ContainsBST(T element, Node<T> tree)
        {
            if (tree == null)
            {
                return false;
            } 
            
            if (tree.Value.CompareTo(element) == 0)
            {
                return true;
            }

            if (tree.Value.CompareTo(element) > 0)
            {
                return ContainsBST(element, tree.LeftChild);
            }
            else
            {
                return ContainsBST (element, tree.RightChild);
            }            
        }

        public void Insert(T element)
        {
            if (!Contains(element))
            {
                InsertBST(element, this.Root);
            }
            
        }

        private void InsertBST(T element, Node<T> root)
        {
            if (root == null) // няма такъв нод
            {
                root = new Node<T>(element, null, null);
                Root = root;
                return;
            }            
            
            if (root.Value.CompareTo(element) > 0)
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = new Node<T>(element, null, null);
                    return;
                }
                
                InsertBST(element, root.LeftChild);
            }
            else
            {
                if (root.RightChild == null)
                {
                    root.RightChild = new Node<T>(element, null, null);
                    return;
                }

                InsertBST(element, root.RightChild);
            }

        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return SearchBST(element, this.Root);
        }

        private IAbstractBinarySearchTree<T> SearchBST(T element, Node<T> tree)
        {
            if (tree == null)
            {
                return null;
            }

            if (tree.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(tree);
            }

            if (tree.Value.CompareTo(element) > 0)
            {
                return SearchBST(element, tree.LeftChild);
            }
            else
            {
                return SearchBST(element, tree.RightChild);
            }              

        }
    }
}
