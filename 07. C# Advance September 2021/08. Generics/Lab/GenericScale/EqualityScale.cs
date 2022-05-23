namespace GenericScale
{
    using System;

    public class EqualityScale<T> where T : IComparable
    {
        private readonly T first;

        private readonly T second;
        
        public EqualityScale(T first, T second)
        {
            this.first = first;
            this.second = second;
        }

        public bool AreEqual()
        {
            if (first.Equals(second))
            {
                return true;
            }

            return false;
        }
    }
}
