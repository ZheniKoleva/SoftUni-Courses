using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsFirstSector = int.Parse(Console.ReadLine());
            int seatsOddRows = int.Parse(Console.ReadLine());

            int seatsTotal = 0;            

            for (char sector = 'A'; sector <= lastSector; sector++)               
            {
                if (sector != 'A')
                {
                    rowsFirstSector++;
                }

                for (int rows = 1; rows <= rowsFirstSector; rows++)
                {
                    if (rows % 2 != 0)
                    {
                        for (char seats = 'a'; seats < 'a' + seatsOddRows; seats++)
                        {
                            Console.WriteLine($"{sector}{rows}{seats}");
                            seatsTotal++;
                        }
                    }
                    else
                    {
                        for (char seats = 'a'; seats < 'a' + seatsOddRows + 2; seats++)
                        {
                            Console.WriteLine($"{sector}{rows}{seats}");
                            seatsTotal++;
                        }
                    }
                }
            }

            Console.WriteLine(seatsTotal);
        }
    }
}
