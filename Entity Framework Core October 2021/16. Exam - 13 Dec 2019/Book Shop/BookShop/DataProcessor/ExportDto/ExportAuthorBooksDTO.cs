namespace BookShop.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportAuthorBooksDTO
    {
        [JsonProperty(nameof(BookName))]
        public string BookName { get; set; }

        [JsonProperty(nameof(BookPrice))]
        public string BookPrice { get; set; }

    }
}