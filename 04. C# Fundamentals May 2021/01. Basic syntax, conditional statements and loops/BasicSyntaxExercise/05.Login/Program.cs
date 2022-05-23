using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            int counter = 0;
            bool isBlocked = false;
            string input = Console.ReadLine();

            while (input != password)
            {
                counter++;

                if (counter > 3)
                {
                    isBlocked = true;
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (isBlocked)
            {
                Console.WriteLine($"User {userName} blocked!");
            }
            else
            {
                Console.WriteLine($"User {userName} logged in.");
            }

        }
    }
}
