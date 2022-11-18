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
            if (this.LeftChild != null) // ако лявото дете на този нод е различно от нула, то нода е негов родител
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
            BinaryTree<T> firstTree = this.SearchTree(first); // намираме къде са двата нода, на който търсим общите прадеди
            BinaryTree<T> secondTree = this.SearchTree(second);   
            
            if (firstTree == null || secondTree == null)
            {
                throw new InvalidOperationException();
            }
            
            List<T> firstAncestors = this.GetAncestors(firstTree); // вземаме родителите от нода до корена
            List<T> secondAncestors = this.GetAncestors(secondTree); 

            List<T> ancestors = firstAncestors.Intersect(secondAncestors).ToList();

            return ancestors.First();            
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
