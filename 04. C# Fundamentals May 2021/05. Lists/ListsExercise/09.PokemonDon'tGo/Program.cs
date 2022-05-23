using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = ReadInput();

            int sumOfRemoved = 0;

            while (pokemons.Count > 0)
            {
                int removed = 0;
                int indx = int.Parse(Console.ReadLine());

                removed = TakeElementToRemove(pokemons, indx);              

                ChangeContent(pokemons, removed);

                sumOfRemoved += removed;
            }

            Console.WriteLine(sumOfRemoved);
        }

        private static int TakeElementToRemove(List<int> pokemons, int indx)
        {
            int removed = 0;

            if (indx < 0)
            {
                removed = pokemons[0];
                pokemons[0] = pokemons[pokemons.Count - 1];
            }
            else if (indx >= pokemons.Count)
            {
                removed = pokemons[pokemons.Count - 1];
                pokemons[pokemons.Count - 1] = pokemons[0];
            }
            else
            {
                removed = pokemons[indx];
                pokemons.RemoveAt(indx);
            }

            return removed;
        }

        private static void ChangeContent(List<int> pokemons, int removed)
        {
            int limit = pokemons.Count;
            
            for(int i = 0; i < limit; i++)
            {
                if (pokemons[i] <= removed)
                {
                    pokemons[i] += removed;
                }
                else if (pokemons[i] > removed)
                {
                    pokemons[i] -= removed;
                }
            }
        }

        private static List<int> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
