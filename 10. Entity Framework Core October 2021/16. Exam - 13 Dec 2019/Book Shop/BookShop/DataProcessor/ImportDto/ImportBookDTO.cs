namespace BookShop.DataProcessor.ImportDto
{
    using System;

    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Book")]
   public class ImportBookDTO
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MaxLength(EntityConstant.Book_Name_Max_Length)]
        [MinLength(EntityConstant.Book_Name_Min_Length)]
        public string Name { get; set; }

        [XmlElement(nameof(Genre))]
        [Required]
        [Range(EntityConstant.Book_Genre_Min_Value, EntityConstant.Book_Genre_Max_Value)]
        public int Genre { get; set; }

        [XmlElement(nameof(Price))]
        [Required]
        [Range((double)EntityConstant.Book_Price_Min_Value, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [XmlElement(nameof(Pages))]
        [Required]
        [Range(EntityConstant.Book_Pages_Min_Value, EntityConstant.Book_Pages_Max_Value)]
        public int Pages { get; set; }

        [XmlElement(nameof(PublishedOn))]
        [Required]
        public string PublishedOn { get; set; }

    }
}
