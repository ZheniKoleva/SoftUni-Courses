using Artillery.Data.Models;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Country))]
    public class ExportCountryDTO
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }

        [XmlAttribute(nameof(ArmySize))]
        public string ArmySize { get; set; }

    }
}