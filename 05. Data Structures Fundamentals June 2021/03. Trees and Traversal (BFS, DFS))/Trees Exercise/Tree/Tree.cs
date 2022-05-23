namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;

            this._children = new List<Tree<T>>();

            foreach (var item in children)
            {
                this.AddChild(item);
                item.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            string output = this.GetAsString(0);

            return output.Trim();
        }

        private string GetAsString(int indendation = 0)
        {
            string intend = new string(' ', indendation);
            StringBuilder result = new StringBuilder();
            result.Append(intend);
            result.Append(this.Key);
            result.Append(Environment.NewLine);

            foreach (var child in this._children)
            {
                result.Append(child.GetAsString(indendation + 2));
            }

            return result.ToString();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            List<Tree<T>> leafNodes = this.GetLeafNodes();

            int level = 0;
            Tree<T> deepest = null;

            foreach (var leaf in leafNodes)
            {
                int currentLevel = 0;

                Tree<T> currentNode = leaf;

                while (currentNode != null)
                {
                    currentLevel++;

                    currentNode = currentNode.Parent;
                }

                if (level < currentLevel)
                {
                    level = currentLevel;
                    deepest = leaf;
                }
            }

            return deepest;           
        }

        private void FindDeepestNode(Tree<T> tree, int currentDepth, ref int biggestDepth, ref Tree<T> deepestNode)
        {
            if (biggestDepth < currentDepth)
            {
                biggestDepth = currentDepth;
                deepestNode = tree;
            }

            foreach (var child in tree._children)
            {
                FindDeepestNode(child, currentDepth + 1, ref biggestDepth, ref deepestNode);
            }
        }

        private Tree<T> DFS()
        {
            if (this._children.Count == 0)
            {
                return this;
            }

            foreach (var child in this._children)
            {
                return child.DFS();
            }

            return null;
        }

        public List<T> GetLeafKeys()
        {
            List<Tree<T>> leafNodes = this.GetLeafNodes(); 
            return leafNodes.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetLeafNodes()
        {
            List<Tree<T>> leafNodes = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> currentNode = queue.Dequeue();

                if (currentNode._children.Count == 0)
                {
                    leafNodes.Add(currentNode);
                }

                foreach (var item in currentNode._children)
                {
                    queue.Enqueue(item);
                }
            }

            return leafNodes;
        }

        private void GetLeafKeysDFS(Tree<T> tree, List<T> result)
        {
            if (tree._children.Count == 0)
            {
                result.Add(tree.Key);
            }
            else
            {
                foreach (var child in tree._children)
                {
                    this.GetLeafKeysDFS(child, result);
                }
            }
        }

        public List<T> GetMiddleKeys()
        {   
            List<Tree<T>> leafNodes = this.GetMiddleNodes(); 

            return leafNodes.Select(x => x.Key).ToList();

        }

        private List<Tree<T>> GetMiddleNodes()
        {
            List<Tree<T>> leafNodes = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> currentNode = queue.Dequeue();

                if (currentNode._children.Count != 0 && currentNode.Parent != null)
                {
                    leafNodes.Add(currentNode);
                }

                foreach (var item in currentNode._children)
                {
                    queue.Enqueue(item);
                }
            }

            return leafNodes;
        }

        private void GetMiddleKeysDFS(Tree<T> tree, List<T> middleNodes)
        {
            foreach (var child in tree._children)
            {
                if (child._children.Count != 0 && child.Parent != null)
                {
                    middleNodes.Add(child.Key);
                }

                this.GetMiddleKeysDFS(child, middleNodes);
            }

        }

        public List<T> GetLongestPath()
        {
            Tree<T> deepestLeaf = GetDeepestLeftomostNode();

            List<T> pathElements = TakePathElements(deepestLeaf);

            return pathElements;
        }

        private List<T> TakePathElements(Tree<T> deepestLeaf)
        {
            List<T> elements = new List<T>();
            elements.Add(deepestLeaf.Key);

            Tree<T> current = deepestLeaf;

            while (current.Parent != null)
            {
                elements.Add(current.Parent.Key);

                current = current.Parent;
            }
            
            elements.Reverse();

            return elements;            
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<Tree<T>> leafNodes = this.GetLeafNodes();

            List<List<T>> path = GetAllPath(leafNodes, sum);

            return path;           
        }

        private List<List<T>> GetAllPath(List<Tree<T>> leafNodes, int sum)
        {
            List<List<T>> result = new List<List<T>>();

            foreach (var item in leafNodes)
            {
                int currentSum = 0;
                List<T> currentPath = new List<T>();

                Tree<T> currentNode = item;

                while (currentNode.Parent != null) 
                {
                    currentPath.Add(currentNode.Key);

                    currentSum += Convert.ToInt32(currentNode.Key);

                    currentNode = currentNode.Parent;
                }

                currentPath.Add(currentNode.Key);

                currentSum += Convert.ToInt32(currentNode.Key);

                if (currentSum == sum)
                {
                    currentPath.Reverse();
                    result.Add(currentPath);
                }
            }

            return result;
        }

        private List<List<T>> PathsWithSumDFS(
            Tree<T> node,
            ref int currentSum,
            int targetSum,
            List<List<T>> allPaths,
            List<T> currentPathValues)
        {
            currentPathValues.Add(node.Key);
            currentSum += Convert.ToInt32(node.Key);

            foreach (var child in node.Children)
            {  
                this.PathsWithSumDFS(child, ref currentSum, targetSum, allPaths, currentPathValues);
            }

            if (currentSum == targetSum)
            {
                allPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= Convert.ToInt32(node.Key);
            currentPathValues.RemoveAt(currentPathValues.Count - 1);

            return allPaths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {          

            List<Tree<T>> roots = new List<Tree<T>>();

            SubTreeSumDFS(this, roots, sum);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, List<Tree<T>> roots, int targetSum)
        {
            int currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node._children)
            {
                currentSum += SubTreeSumDFS(child, roots, targetSum);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        
        }

        private List<Tree<T>> FindSubTreeRoots(int sum)
        {
            List<Tree<T>> roots = new List<Tree<T>>();           

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> currentNode = queue.Dequeue();

                int currentSum = GetSum(currentNode);

                if (currentSum == sum)
                {
                    roots.Add(currentNode);
                }

                foreach (var item in currentNode._children)
                {
                    queue.Enqueue(item);
                }

            }

            return roots;
            
        }

        private int GetSum(Tree<T> tree)
        {
            int sum = Convert.ToInt32(tree.Key);

            foreach (var child in tree._children)
            {
                sum += Convert.ToInt32(child.Key);
            }

            return sum;
        }
    }
}
