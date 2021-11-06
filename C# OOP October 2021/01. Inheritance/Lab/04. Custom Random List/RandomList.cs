using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private readonly Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int rndIndx = rnd.Next(0, this.Count);
            string toRemove = this[rndIndx];

            this.RemoveAt(rndIndx);

            return toRemove;
        }       
    }
}
