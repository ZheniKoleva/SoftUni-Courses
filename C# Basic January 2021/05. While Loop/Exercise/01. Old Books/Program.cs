using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();

            int bookChecked = 0;
            bool isFound = false;
            while (!isFound)
            {
                string currentBook = Console.ReadLine();
                if (currentBook == searchedBook)
                {
                    isFound = true;
                    break;
                }
                else if (currentBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookChecked} books.");
                    return;
                }
                bookChecked++;
            }
            Console.WriteLine($"You checked {bookChecked} books and found it.");
        }
    }
}
