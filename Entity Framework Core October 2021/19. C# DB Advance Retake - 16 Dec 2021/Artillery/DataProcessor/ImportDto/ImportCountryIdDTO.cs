namespace Artillery.DataProcessor.ImportDto
{
    using Newtonsoft.Json;

    public class ImportCountryIdDTO
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }
    }
}