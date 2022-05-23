namespace _09.PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
                
        public override string ToString() => $"{Name} {Badges} {Pokemons.Count}";       
    }
}
