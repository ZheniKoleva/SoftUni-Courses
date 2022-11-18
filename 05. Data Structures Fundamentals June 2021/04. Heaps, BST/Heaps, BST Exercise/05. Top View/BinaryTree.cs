namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            List<T> result = new List<T>();
            GetTopView(this, result);

            return result;
        }

        private void GetTopView(BinaryTree<T> tree, List<T> result)
        {
            if (tree == null)
            {
                return;
            }

            BinaryTree<T> root = tree;

            result.Add(root.Value);

            BinaryTree<T> currNode = root.LeftChild;

            while (currNode != null)
            {
                result.Add(currNode.Value);
                currNode = currNode.LeftChild;
            }

            currNode = root.RightChild;

            while (currNode != null)
            {
                result.Add(currNode.Value);
                currNode = currNode.RightChild;
            }
        }
    }
}
