namespace VaporStore.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;

    public class ExportGameInfoDTO
    {       
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Title))]
        public string Title { get; set; }

        [JsonProperty(nameof(Developer))]
        public string Developer { get; set; }

        [JsonProperty(nameof(Tags))]
        public string Tags { get; set; }

        [JsonProperty(nameof(Players))]
        public int Players { get; set; }

    }
}