using System;

namespace CustomLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);           
            Console.WriteLine(myList.Count);
            Console.WriteLine(new string('=', 20));

            myList.ForEach(Console.WriteLine);
            Console.WriteLine(new string('=', 20));
           
            Console.WriteLine(myList.RemoveFirst());
            Console.WriteLine(myList.Count);

            Console.WriteLine(new string('=', 20));
            int[] array = myList.ToArray();
            Console.WriteLine(string.Join(' ', array));

        }
    }
}
