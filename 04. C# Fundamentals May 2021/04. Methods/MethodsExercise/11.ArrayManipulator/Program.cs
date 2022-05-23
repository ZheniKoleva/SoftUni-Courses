using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                switch (command)
                {
                    case "exchange":
                        int indxToSplit = int.Parse(parts[1]);

                        if (!IsValidIndx(numbers, indxToSplit))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        
                        numbers = ExchangeArray(numbers, indxToSplit);                       
                        break;

                    case "max":
                        string digitType = parts[1];
                        int evenOrOdd = GetParity(digitType);

                        int maxIndx = GetMaxIndx(numbers, evenOrOdd);
                        PrintIndex(maxIndx); 
                        break;

                    case "min":
                        digitType = parts[1];
                        evenOrOdd = GetParity(digitType);

                        int minIndx = GetMinIndx(numbers, evenOrOdd);
                        PrintIndex(minIndx);
                        break;

                    case "first":
                        int firstToTake = int.Parse(parts[1]);
                        digitType = parts[2];
                        evenOrOdd = GetParity(digitType);

                        if (firstToTake > numbers.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        int[] result = TakeFirstElements(numbers, firstToTake, evenOrOdd);
                        PrintArray(result);
                        break;

                    case "last":
                        int lastToTake = int.Parse(parts[1]);
                        digitType = parts[2];
                        evenOrOdd = GetParity(digitType);

                        if (lastToTake > numbers.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        result = TakeLastElements(numbers, lastToTake, evenOrOdd);
                        PrintArray(result);
                        break;                   
                   
                }

                line = Console.ReadLine();
            }

            PrintArray(numbers);
        }

        private static int[] TakeLastElements(int[] initialArray, int countToTake, int evenOrOdd)
        {
            int[] resultArray = initialArray
               .Where(x => x % 2 == evenOrOdd)
               .TakeLast(countToTake)
               .ToArray();

            return resultArray;
        }

        private static void PrintArray(int[] initialArray)
        {
            if (initialArray.Length == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{string.Join(", ", initialArray)}]");
            }
        }

        private static int[] TakeFirstElements(int[] initialArray, int countToTake, int evenOrOdd)
        {
            int[] resultArray = initialArray
                .Where(x => x % 2 == evenOrOdd)
                .Take(countToTake)
                .ToArray();

            return resultArray;
        }

        private static void PrintIndex(int indexToPrint)
        {
            if (indexToPrint == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexToPrint);
            }
        }

        private static int GetMinIndx(int[] initialArray, int evenOrOdd)
        {
            int minNumber = int.MaxValue;
            int indxMinNumber = -1;            

            for (int i = 0; i < initialArray.Length; i++)
            {
                int currentNum = initialArray[i];

                if (currentNum % 2 == evenOrOdd && currentNum <= minNumber)
                {
                    minNumber = initialArray[i];
                    indxMinNumber = i;
                }
            }
            return indxMinNumber;
        }

        private static int GetMaxIndx(int[] initialArray, int evenOrOdd)
        {
            int maxNumber = int.MinValue;
            int indxMaxNumber = -1;           

            for (int i = 0; i < initialArray.Length; i++)
            {
                int currentNum = initialArray[i];

                if (currentNum % 2 == evenOrOdd && currentNum >= maxNumber)
                {
                    maxNumber = initialArray[i];
                    indxMaxNumber = i;
                }
            }
            return indxMaxNumber;

        }

        private static int GetParity(string digitType)
        {
            int parity = digitType == "even" ? 0 : 1;

            return parity;
        }

        private static int[] ExchangeArray(int[] initialArray, int index)
        {
            int[] firstSubarray = initialArray.Take(index + 1).ToArray();
            int[] secondSubArray = initialArray.TakeLast(initialArray.Length - 1 - index).ToArray();

            initialArray = secondSubArray.Concat(firstSubarray).ToArray();

            return initialArray;
        }

        private static bool IsValidIndx(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
