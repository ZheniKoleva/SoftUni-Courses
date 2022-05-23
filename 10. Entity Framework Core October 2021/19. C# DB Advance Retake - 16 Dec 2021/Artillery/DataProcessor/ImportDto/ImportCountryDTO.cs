namespace Artillery.DataProcessor.ImportDto
{
    using System;

    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Artillery.Common;
    using Artillery.Data.Models;


    [XmlType(nameof(Country))]
    public class ImportCountryDTO
    {
        [Required]
        [MinLength(EntityConstants.Country_Name_Min_Lenght)]
        [MaxLength(EntityConstants.Country_Name_Max_Lenght)]
        [XmlElement(nameof(CountryName))]        
        public string CountryName { get; set; }

        [Required]
        [Range(EntityConstants.Country_ArmySize_Min_Value, EntityConstants.Country_ArmySize_Max_Value)]
        public int ArmySize { get; set; }


    }
}
