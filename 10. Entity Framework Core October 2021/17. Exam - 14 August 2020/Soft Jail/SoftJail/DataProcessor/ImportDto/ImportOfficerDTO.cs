namespace SoftJail.DataProcessor.ImportDto
{
    using System;

    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Officer")]
    public class ImportOfficerDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(EntityConstants.Officer_FullName_Min_Length)]
        [MaxLength(EntityConstants.Officer_FullName_Max_Length)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(typeof(decimal), EntityConstants.Officer_Salary_Min, EntityConstants.Officer_Salary_Max)]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]       
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]        
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerIdDTO[] Prisoners { get; set; }

    }
}
