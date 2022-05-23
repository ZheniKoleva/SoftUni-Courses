namespace SoftJail.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportPrisonerDTO
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(CellNumber))]
        public int CellNumber { get; set; }

        [JsonProperty(nameof(Officers))]
        public ExportOfficerDTO[] Officers { get; set; }

        [JsonProperty(nameof(TotalOfficerSalary))]
        public decimal TotalOfficerSalary { get; set; }

    }
}
