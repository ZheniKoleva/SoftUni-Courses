namespace TeisterMask.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportEmployeeDTO
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Tasks")]
        public ExportTaskDTO[] TasksToExport { get; set; }

    }
}
