using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Gun))]
    public class ExportGunXmlDTO
    {
        [XmlAttribute(nameof(Manufacturer))]
        public string Manufacturer { get; set; }

        [XmlAttribute(nameof(GunType))]
        public string GunType { get; set; }

        [XmlAttribute(nameof(GunWeight))]
        public string GunWeight { get; set; }

        [XmlAttribute(nameof(BarrelLength))]
        public string BarrelLength { get; set; }


        [XmlAttribute(nameof(Range))]
        public string Range { get; set; }


        [XmlArray(nameof(Countries))]
        public ExportCountryDTO[] Countries { get; set; }
    }

  //    <Gun Manufacturer = "Krupp" GunType="Mortar" GunWeight="1291272" BarrelLength="8.31" Range="14258">
  //  <Countries>
  //    <Country Country = "Sweden" ArmySize="5437337" />
  //    <Country Country = "Portugal" ArmySize="9523599" />
  //  </Countries>
  //</Gun>

}
