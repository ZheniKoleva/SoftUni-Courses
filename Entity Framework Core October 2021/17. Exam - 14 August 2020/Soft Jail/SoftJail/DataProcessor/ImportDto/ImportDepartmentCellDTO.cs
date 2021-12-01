namespace SoftJail.DataProcessor.ImportDto
{    
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportDepartmentCellDTO
    {       
        [JsonProperty(nameof(Name))]
        [Required]
        [MaxLength(EntityConstants.Department_Name_Max_Length)]
        [MinLength(EntityConstants.Department_Name_Min_Length)]
        public string Name { get; set; }

        [JsonProperty(nameof(Cells))]
        [Required]
        public ImportCellDTO[] Cells { get; set; }

    }
}
