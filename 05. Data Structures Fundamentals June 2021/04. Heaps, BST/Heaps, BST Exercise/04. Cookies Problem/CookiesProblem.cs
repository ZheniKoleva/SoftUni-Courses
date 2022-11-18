using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> bag = new OrderedBag<int>(cookies);
            
            int leastSweet = bag.GetFirst();

            // решение с MinHeap
            //MinHeap<int> bag = new MinHeap<int>();
            //foreach (var item in cookies)
            //{
            //    bag.Add(item);
            //}

            //int leastSweet = bag.Peek();

            int operations = 0;           

            while (leastSweet < k)
            {
                if (bag.Count < 2) // останала ни е 1 бисквитка в торбата
                {
                    break;
                }

                leastSweet = bag.RemoveFirst();
                int secondLeastSweet = bag.RemoveFirst();

                //if (bag.Size < 2)
                //{
                //    break;
                //}

                //leastSweet = bag.Dequeue();
                //int secondLeastSweet = bag.Dequeue();

                int newSweet = leastSweet + (2 * secondLeastSweet);
                bag.Add(newSweet);
                operations++;

                leastSweet = bag.GetFirst();
                //leastSweet = bag.Peek();
            }

            return leastSweet >= k ? operations : -1;
            
        }
    }
}
