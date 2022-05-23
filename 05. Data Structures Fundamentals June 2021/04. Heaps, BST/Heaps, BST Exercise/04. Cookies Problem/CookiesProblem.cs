using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> bag = new OrderedBag<int>(cookies);
          
            int leastSweet = bag.GetFirst();           

            int operations = 0;           

            while (leastSweet < k)
            {
                if (bag.Count < 2) 
                {
                    break;
                }

                leastSweet = bag.RemoveFirst();
                int secondLeastSweet = bag.RemoveFirst();
             
                int newSweet = leastSweet + (2 * secondLeastSweet);
                bag.Add(newSweet);
                operations++;

                leastSweet = bag.GetFirst();               
            }

            return leastSweet >= k ? operations : -1;
            
        }
    }
}
