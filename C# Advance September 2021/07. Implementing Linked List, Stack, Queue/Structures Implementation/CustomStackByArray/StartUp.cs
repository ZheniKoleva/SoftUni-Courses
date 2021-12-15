using System;

namespace CustomStackByArray
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            Console.WriteLine($"Count: {myStack.Count}");
            myStack.ForEach(Console.WriteLine);

            Console.WriteLine(new string('=', 50));

            Console.WriteLine($"Removed: {myStack.Pop()}");
            Console.WriteLine($"Removed: {myStack.Pop()}");
            Console.WriteLine($"Count: {myStack.Count}");

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Peeked: {myStack.Peek()}");

            Console.WriteLine(new string('=', 50));
            myStack.ForEach(Console.WriteLine);

        }
    }
}
