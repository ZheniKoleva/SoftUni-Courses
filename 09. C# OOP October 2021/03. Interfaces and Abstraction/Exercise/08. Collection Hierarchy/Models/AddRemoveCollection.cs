namespace _08.CollectionHierarchy
{  
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {   
        public override int Add(string element)
        {
            this.Elements.Insert(0, element);

            return 0;
        }

        public virtual string Remove()
        {
            string lastItem = this.Elements[this.Elements.Count - 1];
            this.Elements.RemoveAt(this.Elements.Count - 1);

            return lastItem;
        }       

    }
}
