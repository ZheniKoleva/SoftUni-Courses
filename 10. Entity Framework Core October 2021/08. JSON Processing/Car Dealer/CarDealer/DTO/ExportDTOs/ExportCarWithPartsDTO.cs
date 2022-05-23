namespace CarDealer.DTO.ExportDTOs
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class ExportCarWithPartsDTO
    {
        [JsonProperty("car")]
        public ExportCarInfoDTO Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartNamePriceDTO> PartCars { get; set; }

    }
}
