using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> myList = new DoublyLinkedList<int>();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);
            myList.AddLast(4);
            myList.AddLast(5);
            Console.WriteLine(myList.Count);
            Console.WriteLine(new string('=', 20));

            myList.ForEach(Console.WriteLine);
            Console.WriteLine(new string('=', 20));

            Console.WriteLine(myList.RemoveLast());
            Console.WriteLine(myList.Count);
            Console.WriteLine(new string('=', 20));

            Console.WriteLine(myList.RemoveFirst());
            Console.WriteLine(myList.Count);

            Console.WriteLine(new string('=', 20));
            int[] array = myList.ToArray();
            Console.WriteLine(string.Join(' ', array));

            Console.WriteLine(new string('=', 20));

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
