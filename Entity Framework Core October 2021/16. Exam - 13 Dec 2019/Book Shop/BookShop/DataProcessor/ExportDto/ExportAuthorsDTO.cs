namespace BookShop.DataProcessor.ExportDto
{   
    using Newtonsoft.Json;

    public class ExportAuthorsDTO
    {
        [JsonProperty(nameof(AuthorName))]
        public string AuthorName { get; set; }

        [JsonProperty(nameof(Books))]
        public ExportAuthorBooksDTO[] Books { get; set; }

    }
}
