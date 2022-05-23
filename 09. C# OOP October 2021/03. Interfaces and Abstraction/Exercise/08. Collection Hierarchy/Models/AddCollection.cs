namespace _08.CollectionHierarchy
{   
    public class AddCollection : Collection, IAddCollection
    {
        public virtual int Add(string element)
        {
            this.Elements.Add(element);

            return this.Elements.Count - 1;         
        }
    }
}
