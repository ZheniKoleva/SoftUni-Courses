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
                this.Insert(node.Value); // InOrder - ляво дете , корена, после дясно дете.
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

            // Node<T> currNode = this.Root;
            // вкарваме алгоритъма от ContainsBST
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
                    return true; //намерили сме нод който е равен на търсеният елемент
                }
            }

            return false; //връща дали текущият нод е различен от 0
        }


        public void Insert(T element)
        {
            if (!Contains(element))
            {
                InsertBST(element, this.Root);
                this.Count++;
            }

            //Node<T> newNode = new Node<T>(element, null, null);

            //if (this.Count == 0)
            //{
            //    this.Root = newNode;
            //    this.Count++;
            //    return;
            //}

            //Node<T> node = this.Root;

            //while (node != null)
            //{
            //    if (IsGreater(node.Value, element))
            //    {
            //        if (node.RightChild == null)
            //        {
            //            node.RightChild = newNode;                        
            //        }

            //        node = node.RightChild;
            //    }
            //    else if (IsSmaller(node.Value, element))
            //    {
            //        if (node.LeftChild == null)
            //        {
            //            node.LeftChild = newNode;
            //        }

            //        node = node.LeftChild;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
        }

        private void InsertBST(T element, Node<T> currNode)
        {
            if (currNode == null)
            {
                currNode = new Node<T>(element, null, null);
                this.Root = currNode;
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

            return null; // currNode == null ? null : new BinarySearchTree<T>(currNode);
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

            action.Invoke(currNode.Value); // Може и action(currNode.Value)

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

            bool isNodeBiggerThanLowerRange = currNode.Value.CompareTo(lower) > 0;
            bool isNodeSmallerТhanUpperRange = currNode.Value.CompareTo(upper) < 0;
            bool isNodeInRange = currNode.Value.CompareTo(lower) >= 0 && currNode.Value.CompareTo(upper) <= 0;

            if (isNodeBiggerThanLowerRange) // нода е по-голям от мин => 12 > 5 
            {
                FindElementsInRange(currNode.LeftChild, lower, upper, result);
            }

            if (isNodeInRange)   // ако нода е вътре в рейнджа => нод = 12, Lower  = 5 upper = 21
            {
                result.Add(currNode.Value);
            }

            if (isNodeSmallerТhanUpperRange) // нода е по-малък от макс => 12 < 21
            {
                FindElementsInRange(currNode.RightChild, lower, upper, result);
            }
        }


        public void DeleteMin()
        {
            IsTreeEmpty();

            this.Root = this.DeleteMinElement(this.Root);

            //итеративно решение

            //Node<T> current = Root;
            //Node<T> previous = null;

            //if (Root.LeftChild == null)
            //{
            //    Root = Root.RightChild;
            //}
            //else
            //{
            //    while (current.LeftChild != null)
            //    {
            //        current.Count--;

            //        previous = current;
            //        current = current.LeftChild;
            //    }

            //    previous.LeftChild = current.RightChild;
            //}
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
            IsTreeEmpty();

            this.Root = this.DeleteMaxElement(this.Root);
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
            if (this.Count == 0)
            {
                return 0;
            }

            return GetRankBST(element, this.Root);
        }

        private int GetRankBST(T element, Node<T> currNode) // да върнем бр елементи по-малки от някакво число
        {
            if (currNode == null)
            {
                return 0;
            }

            if (currNode.Value.CompareTo(element) > 0) // числото е по малко от нода
            {               
                return GetRankBST(element, currNode.LeftChild);                
            }
            else if (currNode.Value.CompareTo(element) < 0)
            {                
                return 1 + GetRankBST(element, currNode.LeftChild) + GetRankBST(element, currNode.RightChild);
            }

            return 1; // ако е числото == нода 
        }

        private void IsTreeEmpty()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }
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
