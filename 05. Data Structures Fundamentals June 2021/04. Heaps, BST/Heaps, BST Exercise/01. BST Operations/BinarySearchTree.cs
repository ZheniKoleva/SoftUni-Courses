namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> node)
        {
            //this.CopyNode(node);           

            Root = node;
            LeftChild = node.LeftChild;
            RightChild = node.RightChild;
        }

        private void CopyNode(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value); 
                this.CopyNode(node.LeftChild);
                this.CopyNode(node.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public int Count { get; private set; }


        public bool Contains(T element)
        {
            return ContainsBST(element, this.Root);           
        }

        private bool ContainsBST(T element, Node<T> currNode)
        {
            while (currNode != null)
            {
                if (IsGreater(currNode.Value, element))
                {
                    currNode = currNode.LeftChild;
                }
                else if (IsSmaller(currNode.Value, element))
                {
                    currNode = currNode.RightChild;
                }
                else
                {
                    return true; 
                }
            }

            return false; 
        }


        public void Insert(T element)
        {
            if (!Contains(element))
            {
                InsertBST(element, this.Root);
                this.Count++;
            }
        }

        private void InsertBST(T element, Node<T> currNode)
        {
            if (currNode == null)
            {
                currNode = new Node<T>(element, null, null);
                Root = currNode;
                return;
            }

            if (currNode.Value.CompareTo(element) > 0)
            {
                if (currNode.LeftChild == null)
                {
                    currNode.LeftChild = new Node<T>(element, null, null);
                    return;
                }

                InsertBST(element, currNode.LeftChild);
            }
            else
            {
                if (currNode.RightChild == null)
                {
                    currNode.RightChild = new Node<T>(element, null, null);
                    return;
                }

                InsertBST(element, currNode.RightChild);
            }
        }


        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return SearchBST(element, this.Root);
        }

        private IAbstractBinarySearchTree<T> SearchBST(T element, Node<T> currNode)
        {
            while (currNode != null)
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
                    return new BinarySearchTree<T>(currNode);
                }
            }

            return null; 
        }


        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> currNode)
        {
            if (currNode == null)
            {
                return;
            }

            EachInOrder(action, currNode.LeftChild);

            action.Invoke(currNode.Value); 

            EachInOrder(action, currNode.RightChild);

        }


        public List<T> Range(T lower, T upper)
        {
            List<T> result = new List<T>();
            FindElementsInRange(this.Root, lower, upper, result);

            return result;
        }

        private void FindElementsInRange(Node<T> currNode, T lower, T upper, List<T> result)
        {
            if (currNode == null)
            { 
                return;
            } 

            if (currNode.Value.CompareTo(lower) > 0) 
            {
                FindElementsInRange(currNode.LeftChild, lower, upper, result);
            }

            if (currNode.Value.CompareTo(lower) >= 0
               && currNode.Value.CompareTo(upper) <= 0)   
            {
                result.Add(currNode.Value);
            }

            if (currNode.Value.CompareTo(upper) < 0) 
            {
                FindElementsInRange(currNode.RightChild, lower, upper, result);
            }
        }


        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.LeftChild = this.DeleteMinElement(this.Root.LeftChild);
           
        }

        private Node<T> DeleteMinElement(Node<T> currNode)
        {            
            if (currNode.LeftChild == null)
            {
                Count--;
                return currNode.RightChild;
            }

            currNode.LeftChild = DeleteMinElement(currNode.LeftChild);

            return currNode;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.RightChild = this.DeleteMaxElement(this.Root.RightChild);
        }

        private Node<T> DeleteMaxElement(Node<T> currNode)
        {
            
            if (currNode.RightChild == null)
            {
                Count--;
                return currNode.LeftChild;
            }

            currNode.RightChild = DeleteMaxElement(currNode.RightChild);

            return currNode;
        }

        public int GetRank(T element)
        {  
            if (Count == 0)
            {
                return 0;
            }

            return GetRankBST(element, this.Root);
        }

        private int GetRankBST(T element, Node<T> currNode) 
        {
            if (currNode == null)
            {
                return 0;
            }

            if (currNode.Value.CompareTo(element) > 0) 
            {               
                return GetRankBST(element, currNode.LeftChild);                
            }

            if (currNode.Value.CompareTo(element) < 0)
            {                
                return 1 + GetRankBST(element, currNode.LeftChild) + GetRankBST(element, currNode.RightChild);
            }

            return 1; // ако е числото == нода 

        }

        private bool IsGreater(T value, T element)
        {
            return value.CompareTo(element) > 0;
        }

        private bool IsSmaller(T value, T element)
        {
            return value.CompareTo(element) < 0;
        }
        
    }
}
