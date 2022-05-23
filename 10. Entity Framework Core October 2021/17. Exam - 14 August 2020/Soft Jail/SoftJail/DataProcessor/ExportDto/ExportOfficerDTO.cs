namespace SoftJail.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportOfficerDTO
    {
        [JsonProperty(nameof(OfficerName))]
        public string OfficerName { get; set; }

        [JsonProperty(nameof(Department))]
        public string Department { get; set; }
    }
}