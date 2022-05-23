namespace _08.CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => this.Elements.Count;

        public override int Add(string element)
        {
            this.Elements.Insert(0, element);

            return 0;
        }

        public override string Remove()
        {
            string firstItem = this.Elements[0];
            this.Elements.RemoveAt(0);

            return firstItem;
        }
    }
}
