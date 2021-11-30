namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json; 

    public class ImportBookId
    {
        [JsonProperty(nameof(Id))]        
        public int? Id { get; set; }

    }
}