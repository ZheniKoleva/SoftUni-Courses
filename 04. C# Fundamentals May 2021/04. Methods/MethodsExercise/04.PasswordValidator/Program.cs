using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            IsValidPassword(password);        
            
        }

        private static void IsValidPassword(string password)
        {
            bool isValidPassword = true;

            if (!IsValidLength(password))
            {
                isValidPassword = false;
            }

            if (!IsContainLettersAndDigits(password))
            {
                isValidPassword = false;
            }

            if (!HasTwoDigits(password))
            {
                isValidPassword = false;
            }

            if (isValidPassword)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool HasTwoDigits(string password, int count = 2)
        {
            bool hasDigits = false;            
            int counter = 0;

            foreach (var item in password)
            {
                if (char.IsDigit(item))
                {
                    counter++;
                }

                if (counter >= count)
                {
                    hasDigits = true;                    
                    break;
                }
            }

            if (!hasDigits)
            {
                Console.WriteLine($"Password must have at least {count} digits");
            }

            return hasDigits;
        }

        private static bool IsContainLettersAndDigits(string password)
        {
            bool hasLettersAndDigits = true;

            foreach (var item in password)
            {
                if (!char.IsLetterOrDigit(item))
                {
                    hasLettersAndDigits = false;
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }

            return hasLettersAndDigits;
        }

        private static bool IsValidLength(string password, int start = 6, int end = 10)
        {
            bool isValidLength = password.Length >= start && password.Length <= end;

            if (!isValidLength)
            {
                Console.WriteLine($"Password must be between {start} and {end} characters");
            }

            return isValidLength;
        }
    }
}
