namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using System.Xml.Serialization;

    using Common;


    [XmlType("Cast")]
    public class ImportCastDTO
    {
        [Required]
        [MinLength(EntityConstants.Cast_FullName_Min_Lenght)]
        [MaxLength(EntityConstants.Cast_FullName_Max_Lenght)]
        [XmlElement(nameof(FullName))]
        public string FullName { get; set; }

        [Required]
        [XmlElement(nameof(IsMainCharacter))]
        public bool IsMainCharacter { get; set; }

        [Required]
        [MaxLength(EntityConstants.Cast_PhoneNumber_Max_Lenght)]
        [RegularExpression(EntityConstants.Cast_PhoneNumber_Regex_Pattern)]
        [XmlElement(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlElement(nameof(PlayId))]
        public int PlayId { get; set; }       
    }
}
