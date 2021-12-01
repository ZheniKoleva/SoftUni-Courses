namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportCellDTO
    {
        [JsonProperty(nameof(CellNumber))]
        [Required]
        [Range(EntityConstants.Cell_CellNumber_Min, EntityConstants.Cell_CellNumber_Max)]
        public int CellNumber { get; set; }

        [JsonProperty(nameof(HasWindow))]
        [Required]
        public bool HasWindow { get; set; }

    }
}