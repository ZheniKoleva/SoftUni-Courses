using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(ReadData());

            while (songs.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    string songToAdd = command[4..];

                    if (songs.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                        continue;
                    }

                    songs.Enqueue(songToAdd);
                }

            }

            Console.WriteLine("No more songs!");

        }

        private static IEnumerable<string> ReadData()
        {
            return Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
