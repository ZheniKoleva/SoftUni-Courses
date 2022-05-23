using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfDNA = int.Parse(Console.ReadLine());

            int[] bestDNA = new int[lengthOfDNA];
            int bestLength = 0;
            int maxSum = 0;
            int startIndex = -1;
            int bestSampleNumber = 1;

            int sampleNumber = 0;
            
            string line = Console.ReadLine();

            while (line != "Clone them!")
            {
                int[] currentDNA = line
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sampleNumber++;
                
                int currentSum = currentDNA.Sum();                

                int currentLength = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    int digit = currentDNA[i];

                    if (digit == 0)
                    {
                        continue;
                    }

                    currentLength = 1;
                    int indx = i;

                    for (int j = i + 1; j < currentDNA.Length; j++)
                    {
                        int nextDigit = currentDNA[j];

                        if (digit != nextDigit)
                        {
                            break;
                        }

                        currentLength++;
                    }

                    bool isBestDNAFound = false;

                    if (currentLength > bestLength)
                    {
                        isBestDNAFound = true;
                    }
                    else if (currentLength == bestLength && indx < startIndex)
                    {
                        isBestDNAFound = true;
                    }
                    else if (currentLength == bestLength && indx == startIndex && currentSum > maxSum)
                    {
                        isBestDNAFound = true;
                    }

                    if (isBestDNAFound)
                    {
                        bestLength = currentLength;
                        maxSum = currentSum;
                        startIndex = indx;
                        bestDNA = currentDNA;
                        bestSampleNumber = sampleNumber;
                    }

                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {maxSum}.");
            Console.WriteLine(string.Join(' ', bestDNA));
        }
    }
}
