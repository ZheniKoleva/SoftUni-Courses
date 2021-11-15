namespace ProductShop.DTOs.ExportDTOs
{
    using Newtonsoft.Json;

    public class ProductInRangeDTO
    {       
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

    }
}
