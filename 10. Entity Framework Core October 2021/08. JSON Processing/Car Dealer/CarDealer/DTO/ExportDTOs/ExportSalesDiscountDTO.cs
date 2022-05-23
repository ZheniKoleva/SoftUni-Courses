namespace CarDealer.DTO.ExportDTOs
{
    using Newtonsoft.Json;

    public class ExportSalesDiscountDTO
    {
        [JsonProperty("car")]
        public ExportCarInfoDTO Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
           
    }
}
