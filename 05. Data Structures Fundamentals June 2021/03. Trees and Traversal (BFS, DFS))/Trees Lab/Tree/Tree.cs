namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                IsRootDeleted = false;
                return result;
            }

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();

                result.Add(subtree.Value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);

                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                IsRootDeleted = false;
                return result;
            }

            this.Dfs(this, result);

            return result;
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> searchedNode = this.FindBfs(parentKey);

            //CheckEmptyNode(searchedNode);

            searchedNode.children.Add(child);
        }
       
        private Tree<T> FindBfs(T parentKey)
        {
            Queue<Tree<T>> tree = new Queue<Tree<T>>();

            tree.Enqueue(this);

            while (tree.Count > 0)
            {
                Tree<T> currentNode = tree.Dequeue();

                if (currentNode.Value.Equals(parentKey))
                {
                    return currentNode;
                }

                foreach (Tree<T> child in currentNode.children)
                {
                    tree.Enqueue(child);
                }
            }

            throw new ArgumentNullException();
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> searchedNode = this.FindBfs(nodeKey);

            foreach (var child in searchedNode.children) 
            {
                child.Parent = null;
            }

            searchedNode.children.Clear(); 

            Tree<T> parentOfSearchedNode = searchedNode.Parent;

            if (parentOfSearchedNode != null) /
            {
                searchedNode.Parent.children.Remove(searchedNode); 
            }
            else
            {
                this.IsRootDeleted = true; 
            }

            searchedNode.Value = default(T); 
                                             

        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = this.FindBfs(firstKey);
            Tree<T> secondNode = this.FindBfs(secondKey);

            if (IsRoot(firstNode))
            {
                firstNode.Value = secondNode.Value;
                firstNode.children.Clear();

                foreach (var child in secondNode.children)
                {
                    this.children.Add(child);
                }
            }
            else
            {
                Tree<T> firstParent = firstNode.Parent; 
                Tree<T> secondParent = secondNode.Parent; 

                int indxFirstNode = firstParent.children.IndexOf(firstNode);
                int indxSecondNode = secondParent.children.IndexOf(secondNode); 

                firstParent.children[indxFirstNode] = secondNode; 
                secondParent.children[indxSecondNode] = firstNode;
            }
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.Parent == null;
        }
    }
}

