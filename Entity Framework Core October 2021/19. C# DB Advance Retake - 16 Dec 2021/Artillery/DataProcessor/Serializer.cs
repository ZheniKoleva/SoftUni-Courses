namespace Artillery.DataProcessor
{
    using System.IO;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;   

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsToExport = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .ToArray()
                .Select(x => new ExportShellDTO
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                            .Where(g => g.GunType == GunType.AntiAircraftGun)
                            .OrderByDescending(g => g.GunWeight)
                            .Select(g => new ExportGunJsonDto
                            {
                                GunType = g.GunType.ToString(),
                                GunWeight = g.GunWeight,
                                BarrelLength = g.BarrelLength,
                                Range = g.Range > 3000 ? "Long-range" : "Regular range"
                            })
                            .ToArray()
                })
                .ToArray()
                .OrderBy(s => s.ShellWeight);


            return JsonConvert.SerializeObject(shellsToExport, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlRootAttribute root = new XmlRootAttribute("Guns");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportGunXmlDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder xmlOutput = new StringBuilder();
            using StringWriter writer = new StringWriter(xmlOutput);


            ExportGunXmlDTO[] gunsToExport = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(x => new ExportGunXmlDTO
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunWeight = x.GunWeight.ToString(),
                    GunType = x.GunType.ToString(),
                    BarrelLength = x.BarrelLength.ToString(),
                    Range = x.Range.ToString(),
                    Countries = x.CountriesGuns
                                 .Where(c => c.Country.ArmySize > 4500000)
                                 .OrderBy(c => c.Country.ArmySize)
                                 .Select(c => new ExportCountryDTO
                                 {
                                     CountryName = c.Country.CountryName,
                                     ArmySize = c.Country.ArmySize.ToString()
                                 })
                                 .ToArray()
                })
                .ToArray();

            serializer.Serialize(writer, gunsToExport, namespaces);

            return xmlOutput.ToString();
        }
    }
}
