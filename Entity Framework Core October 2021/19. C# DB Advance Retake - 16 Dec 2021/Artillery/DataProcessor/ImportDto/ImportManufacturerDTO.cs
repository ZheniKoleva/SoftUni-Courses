namespace Artillery.DataProcessor.ImportDto
{  
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Artillery.Common;
    using Artillery.Data.Models;


    [XmlType(nameof(Manufacturer))]
    public class ImportManufacturerDTO
    {
        [Required]
        [MinLength(EntityConstants.Manufacturer_Name_Min_Lenght)]
        [MaxLength(EntityConstants.Manufacturer_Name_Max_Lenght)]
        [XmlElement(nameof(ManufacturerName))]
        public string ManufacturerName { get; set; }

        [Required]
        [MinLength(EntityConstants.Manufacturer_Founded_Min_Lenght)]
        [MaxLength(EntityConstants.Manufacturer_Founded_Max_Lenght)]
        [XmlElement(nameof(Founded))]
        public string Founded { get; set; }


    }
}
