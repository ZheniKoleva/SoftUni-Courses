namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null) 
            {
                this.LeftChild.Parent = this;
            }

            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstTree = SearchTree(first); 
            BinaryTree<T> secondTree = SearchTree(second);            
            
            List<T> firstAncestors = GetAncestors(firstTree); 
            List<T> secondAncestors = GetAncestors(secondTree);      
           

            List<T> ancestors = firstAncestors.Intersect(secondAncestors).ToList();

            return ancestors[0];
            
        }

        private BinaryTree<T> SearchTree(T element)
        {
            var currNode = this;

            while (currNode.Value != null)
            {
                if (currNode.Value.CompareTo(element) > 0)
                {
                    currNode = currNode.LeftChild;
                }
                else if (currNode.Value.CompareTo(element) < 0)
                {
                    currNode = currNode.RightChild;
                }
                else
                {
                    return currNode;
                }
            }

            return null;
        }

        private List<T> GetAncestors(BinaryTree<T> currNode)
        {
            List<T> result = new List<T>();

            while (currNode != null)
            {
                result.Add(currNode.Value);
                currNode = currNode.Parent;
            }

            return result;
        }
    }
}
