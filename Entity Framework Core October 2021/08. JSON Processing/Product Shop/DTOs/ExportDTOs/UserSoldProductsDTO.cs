namespace ProductShop.DTOs.ExportDTOs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ICollection<SoldProductDTO> ProductsSold { get; set; }
    }
}
