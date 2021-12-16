namespace Theatre.DataProcessor.ImportDto
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using System.Xml.Serialization;

    using Common;
    using Data.Models.Enums;


    [XmlType("Play")]
    public class ImportPlayDTO
    {
        [Required]
        [MinLength(EntityConstants.Play_Title_Min_Lenght)]
        [MaxLength(EntityConstants.Play_Title_Max_Lenght)]
        [XmlElement(nameof(Title))]
        public string Title { get; set; }

        [Required]        
        public string Duration { get; set; }

        [Required]
        [Range(typeof(float), EntityConstants.Play_Rating_Min_Value, EntityConstants.Play_Rating_Max_Value)]
        public float Rating { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        [MaxLength(EntityConstants.Play_Description_Max_Lenght)]
        public string Description { get; set; }

        [Required]
        [MinLength(EntityConstants.Play_Screewriter_Min_Lenght)]
        [MaxLength(EntityConstants.Play_Screewriter_Max_Lenght)]
        public string Screenwriter { get; set; }
    }

}
