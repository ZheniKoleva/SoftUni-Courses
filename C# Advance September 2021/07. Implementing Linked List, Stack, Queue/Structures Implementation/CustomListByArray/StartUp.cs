using System;

namespace CustomListByArray
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            myList.Add(7);
            myList.Add(8);           

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Count: {myList.Count}");
            Console.WriteLine(myList);
            
            Console.WriteLine(new string('=', 50));

            Console.WriteLine($"Removed: {myList.RemoveAt(4)}");
            Console.WriteLine($"Count: {myList.Count}");
            Console.WriteLine(myList);

            Console.WriteLine(new string('=', 50));

            Console.WriteLine(myList.Contains(15));
            Console.WriteLine(myList.Contains(1));

            Console.WriteLine(new string('=', 50));

            Console.WriteLine($"Removed: {myList.RemoveAt(4)}");
            Console.WriteLine($"Removed: {myList.RemoveAt(0)}");
            Console.WriteLine($"Removed: {myList.RemoveAt(3)}");
            Console.WriteLine($"Removed: {myList.RemoveAt(1)}");
            Console.WriteLine($"Removed: {myList.RemoveAt(0)}");
            Console.WriteLine($"Count: {myList.Count}");
            Console.WriteLine(myList);

            Console.WriteLine(new string('=', 50));

            myList.Reverse();
            Console.WriteLine(myList);
        }
    }
}
