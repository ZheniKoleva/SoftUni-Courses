namespace BookShop.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class ExportBookDTO
    {
        [XmlAttribute(nameof(Pages))]
        public string Pages { get; set; }

        [XmlElement(nameof(Name))]
        public string Name { get; set; }

        [XmlElement(nameof(Date))]
        public string Date { get; set; }

    }
}
