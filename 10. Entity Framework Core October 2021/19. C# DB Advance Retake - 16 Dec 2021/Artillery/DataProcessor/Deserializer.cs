namespace Artillery.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;


    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;
  
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Countries");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCountryDTO[]), root);

            StringBuilder sb = new StringBuilder();
            HashSet<Country> coutriesToImport = new HashSet<Country>();

            using StringReader reader = new StringReader(xmlString);

            ImportCountryDTO[] extractedData = (ImportCountryDTO[])serializer.Deserialize(reader);

            foreach (var coutryInfo in extractedData)
            {
                if (!IsValid(coutryInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country
                {
                    CountryName = coutryInfo.CountryName,
                    ArmySize = coutryInfo.ArmySize,
                };

                coutriesToImport.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(coutriesToImport);
            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Manufacturers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportManufacturerDTO[]), root);

            StringBuilder sb = new StringBuilder();
            HashSet<Manufacturer> manufacturersToImport = new HashSet<Manufacturer>();

            HashSet<string> existingNames = context.Manufacturers
                .Select(x => x.ManufacturerName)
                .ToHashSet();

            using StringReader reader = new StringReader(xmlString);

            ImportManufacturerDTO[] extractedData = (ImportManufacturerDTO[])serializer.Deserialize(reader);

            foreach (var manufacturerInfo in extractedData)
            {
                if (!IsValid(manufacturerInfo) || existingNames.Contains(manufacturerInfo.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturerInfo.ManufacturerName,
                    Founded = manufacturerInfo.Founded,
                };

                existingNames.Add(manufacturerInfo.ManufacturerName);

                manufacturersToImport.Add(manufacturer);

                string[] locationData = manufacturerInfo.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .TakeLast(2)
                    .ToArray();

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, 
                    manufacturer.ManufacturerName, string.Join(", ", locationData)));
            }

            context.Manufacturers.AddRange(manufacturersToImport);
            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Shells");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportShellDTO[]), root);

            StringBuilder sb = new StringBuilder();
            HashSet<Shell> shelssToImport = new HashSet<Shell>();           

            using StringReader reader = new StringReader(xmlString);

            ImportShellDTO[] extractedData = (ImportShellDTO[])serializer.Deserialize(reader);

            foreach (var shellInfo in extractedData)
            {
                if (!IsValid(shellInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = shellInfo.ShellWeight,
                    Caliber = shellInfo.Caliber,
                };                

                shelssToImport.Add(shell);              

                sb.AppendLine(string.Format(SuccessfulImportShell,
                    shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shelssToImport);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            IEnumerable<ImportGunDTO> extractedData =
                JsonConvert.DeserializeObject<IEnumerable<ImportGunDTO>>(jsonString);

            StringBuilder sb = new StringBuilder();

            HashSet<Gun> gunsToImport = new HashSet<Gun>();

            foreach (var gunInfo in extractedData)
            {
                if (!IsValid(gunInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunType = Enum.Parse<GunType>(gunInfo.GunType);

                Gun gun = new Gun
                {
                    ManufacturerId = gunInfo.ManufacturerId,
                    GunWeight = gunInfo.GunWeight,
                    BarrelLength = gunInfo.BarrelLength,
                    NumberBuild = gunInfo.NumberBuild,
                    Range = gunInfo.Range,
                    GunType = gunType,
                    ShellId = gunInfo.ShellId,
                };

                HashSet<CountryGun> countires = new HashSet<CountryGun>();

                foreach (var item in gunInfo.CountriesId)
                {
                    CountryGun coutryGun = new CountryGun
                    {
                        CountryId = item.Id,
                        Gun = gun
                    };

                    countires.Add(coutryGun);
                }

                gun.CountriesGuns = countires;

                gunsToImport.Add(gun);

                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));

            }

            context.Guns.AddRange(gunsToImport);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
