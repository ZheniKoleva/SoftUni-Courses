namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    using Data;
    using Initializer;
  

    public class StartUp
    {
        public static void Main(string[] args)
        {            
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Task 2
            int producerId = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportAlbumsInfo(context, producerId));

            //Task 3
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportSongsAboveDuration(context, duration));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albums = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    Producer = a.Producer.Name,
                    AlbumPrice = a.Price,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter)
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.AlbumPrice);

            foreach (var album in albums)
            {
                output.AppendLine($"-AlbumName: {album.AlbumName}")
                     .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                     .AppendLine($"-ProducerName: {album.Producer}")
                     .AppendLine($"-Songs:");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    output.AppendLine($"---#{counter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:f2}")
                        .AppendLine($"---Writer: {song.SongWriter}");
                }

                output.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder output = new StringBuilder();

            var songs = context.Songs  
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture),
                    SongPerformer = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault()
                        
                })                
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.SongPerformer)
                .ToList();

            int counter = 1;

            foreach (var song in songs)
            {
                output.AppendLine($"-Song #{counter++}")
                      .AppendLine($"---SongName: {song.Name}")
                      .AppendLine($"---Writer: {song.WriterName}")
                      .AppendLine($"---Performer: {song.SongPerformer}")
                      .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                      .AppendLine($"---Duration: {song.Duration}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
