namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {            
            return DFSPreOrder(this, new StringBuilder(), indent);
        }

        private string DFSPreOrder(IAbstractBinaryTree<T> tree, StringBuilder result, int indent)
        {   
            result.Append(new string(' ', indent));
            result.AppendLine($"{tree.Value}");               

            if (tree.LeftChild != null)
            {
               DFSPreOrder(tree.LeftChild, result, indent + 2);
            }

            if (tree.RightChild != null)
            {
                DFSPreOrder(tree.RightChild, result, indent + 2);
            }

            return result.ToString();
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            InOrderDFS(this, result);

            return result;
        }

        private void InOrderDFS(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {
            if (tree.LeftChild != null)
            {
                InOrderDFS(tree.LeftChild, result);
            }

            result.Add(tree);

            if (tree.RightChild != null)
            {
                InOrderDFS(tree.RightChild, result);
            }
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PostOrderDFS(this, result);

            return result;
        }

        private void PostOrderDFS(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {
            if (tree.LeftChild != null)
            {
                PostOrderDFS(tree.LeftChild, result);
            }

            if (tree.RightChild != null)
            {
                PostOrderDFS(tree.RightChild, result);
            }
            
            result.Add(tree);
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PreOrderDFS(this, result);

            return result;
        }

        private void PreOrderDFS(IAbstractBinaryTree<T> tree, List<IAbstractBinaryTree<T>> result)
        {            
            result.Add(tree);

            if (tree.LeftChild != null)
            {
                PreOrderDFS(tree.LeftChild, result);
            }

            if (tree.RightChild != null)
            {
                PreOrderDFS(tree.RightChild, result);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }

        }
    }
}
