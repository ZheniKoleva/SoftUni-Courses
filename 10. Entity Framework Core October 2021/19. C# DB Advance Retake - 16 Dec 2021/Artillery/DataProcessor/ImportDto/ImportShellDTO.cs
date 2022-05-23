namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Common;
    using System;

    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Artillery.Data.Models;


    [XmlType(nameof(Shell))]
    public class ImportShellDTO
    {   
        [Required]
        [Range(EntityConstants.Shell_ShellWeight_Min_Value, EntityConstants.Shell_ShellWeight_Max_Value)]
        [XmlElement(nameof(ShellWeight))]
        public double ShellWeight { get; set; }
       
        
        
        [Required]
        [MinLength(EntityConstants.Shell_Caliber_Min_Lenght)]
        [MaxLength(EntityConstants.Shell_Caliber_Max_Lenght)]
        [XmlElement(nameof(Caliber))]
        public string Caliber { get; set; }

    }
}
