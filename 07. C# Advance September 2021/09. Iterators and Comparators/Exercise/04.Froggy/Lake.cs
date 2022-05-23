namespace _04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(IEnumerable<int> data)
        {
            stones = new List<int>(data);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return stones[i];
            }

            int lastOddIndx = (stones.Count - 1) % 2 == 0 
                              ? (stones.Count - 2) 
                              : (stones.Count - 1);

            for (int i = lastOddIndx; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
