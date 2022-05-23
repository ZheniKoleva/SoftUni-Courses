namespace VaporStore.DataProcessor.Dto.Import
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Purchase")]
    public class ImportPurchaseDTO
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [XmlElement("Type")]
        [Required]       
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(EntityConstants.Purchase_ProductKey_Regex_Pattern)]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(EntityConstants.Card_Number_Regex_Pattern)]
        public string CardNumber { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}
