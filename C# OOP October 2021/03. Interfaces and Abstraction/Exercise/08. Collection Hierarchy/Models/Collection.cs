namespace _08.CollectionHierarchy
{
    using System.Collections.Generic;

    public abstract class Collection
    {
        private const int CAPASITY = 100;         

        protected Collection()
        {
            this.Elements = new List<string>(CAPASITY);
        }

        protected IList<string> Elements { get; private set; }

        protected int Capasity => CAPASITY;
    }
}
