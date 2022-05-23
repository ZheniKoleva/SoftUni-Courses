namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var item in input)
            {
                string[] arguments = item.Split(' '); 
                int firstArg = int.Parse(arguments[0]);
                int secondArg = int.Parse(arguments[1]);

                if (!this.nodesBykeys.ContainsKey(firstArg)) 
                {
                    Tree<int> firstNode = this.CreateNodeByKey(firstArg);
                    this.nodesBykeys.Add(firstArg, firstNode); 
                }

                if (!this.nodesBykeys.ContainsKey(secondArg)) 
                {
                    Tree<int> secondNode = this.CreateNodeByKey(secondArg);
                    this.nodesBykeys.Add(secondArg, secondNode);
                }

                this.AddEdge(firstArg, secondArg); 

            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> currentNode = new Tree<int>(key); 
            return currentNode;
        }

        public void AddEdge(int parent, int child) 
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]); 
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot() 
        {           
            Tree<int> currentNode = this.nodesBykeys.FirstOrDefault().Value;

            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
            }

            return currentNode;
        }
    }
}
