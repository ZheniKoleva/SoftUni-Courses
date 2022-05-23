using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());

            List<Song> songsList = ReadSongs(songsCount);

            string printCriteria = Console.ReadLine();

            PrintSongs(songsList, printCriteria);
        }

        private static void PrintSongs(List<Song> songsList, string printCriteria)
        {
            if (printCriteria == "all")
            {
                Console.WriteLine(string.Join(Environment.NewLine, songsList));
            }
            else
            {
                List<Song> filtered = songsList.Where(song => song.TypeList == printCriteria).ToList();
                Console.WriteLine(string.Join(Environment.NewLine, filtered));
            }
        }

        private static List<Song> ReadSongs(int songsCount)
        {
            List<Song> songs = new List<Song>(songsCount);

            for (int i = 0; i < songsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                string album = tokens[0];
                string songName = tokens[1];
                string time = tokens[2];

                songs.Add(new Song(album, songName, time));                    
            }

            return songs;
        }
    }

    public class Song 
    {
        private string typelist;

        private string name;

        private string time;

        public Song(string album, string songName, string time)
        {
            this.TypeList = album;
            this.Name = songName;
            this.Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
