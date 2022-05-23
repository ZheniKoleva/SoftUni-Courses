namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Collections.Generic;
    
    using Newtonsoft.Json;

    public class ExportGameByGenreDTO
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Genre))]
        public string Genre { get; set; }

        [JsonProperty(nameof(Games))]
        public ICollection<ExportGameInfoDTO> Games { get; set; }

        [JsonProperty(nameof(TotalPlayers))]
        public int TotalPlayers { get; set; }

    }
}
