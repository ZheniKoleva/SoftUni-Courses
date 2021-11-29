namespace TeisterMask.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    public class ExportTaskDTO
    {
        [JsonProperty("TaskName")]
        public string Name { get; set; }

        [JsonProperty("OpenDate")]
        public string OpenDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("LabelType")]
        public string LabelType { get; set; }

        [JsonProperty("ExecutionType")]
        public string ExecutionType { get; set; }   

    }
}
