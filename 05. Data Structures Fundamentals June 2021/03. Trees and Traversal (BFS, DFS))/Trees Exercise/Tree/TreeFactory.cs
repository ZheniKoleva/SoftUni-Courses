namespace Tree
{
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
                int parentKey = int.Parse(arguments[0]);
                int childKey = int.Parse(arguments[1]);

                CreateNodeByKey(parentKey);
                CreateNodeByKey(childKey);

                this.AddEdge(parentKey, childKey); // създаваме ръб със стойностите (ключа), а зад тези ключове ни стоят нодовете
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                Tree<int> newKeyNode = new Tree<int>(key); 
                this.nodesBykeys.Add(key, newKeyNode);                
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child) // просвояваме на всеки нод родител и дете
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]); 
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot() // връщаме корена (този нод който няма родител)
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
