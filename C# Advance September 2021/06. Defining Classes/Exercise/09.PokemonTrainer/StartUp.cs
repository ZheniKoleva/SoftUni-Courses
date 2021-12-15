using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string line;

            while ((line = Console.ReadLine()) != "Tournament")
            {
                ExtractData(line, out string trainerName, out Pokemon pokemon);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((line = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(x => x.Element.Equals(line)))
                    {
                        trainer.Badges++;
                        continue;
                    }

                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;

                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            i--;
                        }
                    }

                }
            }

            var ordered = trainers.Values
                .OrderByDescending(x => x.Badges);

            Console.WriteLine(string.Join(Environment.NewLine, ordered));
        }

        private static void ExtractData(string line, out string trainerName, out Pokemon pokemon)
        {
            string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            trainerName = data[0];
            string pokemonName = data[1];
            string element = data[2];
            int pokemonHealth = int.Parse(data[3]);

            pokemon = new Pokemon(pokemonName, element, pokemonHealth);
        }
    }
}
