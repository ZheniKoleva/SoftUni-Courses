namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public interface IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        int Count { get; }

        void Insert(T element);

        bool Contains(T element);

        IAbstractBinarySearchTree<T> Search(T element);

        Node<T> Root { get; }

        void EachInOrder(Action<T> action);

        List<T> Range(T lower, T upper);

        void DeleteMin();

        void DeleteMax();

        int GetRank(T element);
    }
}
