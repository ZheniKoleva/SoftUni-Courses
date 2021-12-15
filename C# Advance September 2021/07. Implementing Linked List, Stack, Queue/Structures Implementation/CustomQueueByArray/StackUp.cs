using System;

namespace CustomQueueByArray
{
    public class StackUp
    {
        static void Main(string[] args)
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);

            Console.WriteLine($"Count: {myQueue.Count}");
            myQueue.ForEach(Console.WriteLine);

            Console.WriteLine(new string('=', 50));

            Console.WriteLine($"Removed: {myQueue.Dequeue()}");
            Console.WriteLine($"Removed: {myQueue.Dequeue()}");
            Console.WriteLine($"Count: {myQueue.Count}");

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Peeked: {myQueue.Peek()}");

            Console.WriteLine(new string('=', 50));
            myQueue.ForEach(Console.WriteLine);

            Console.WriteLine(new string('=', 50));
            myQueue.Clear();
            Console.WriteLine($"Count: {myQueue.Count}");
            Console.WriteLine($"Removed: {myQueue.Dequeue()}");
        }
    }
}
