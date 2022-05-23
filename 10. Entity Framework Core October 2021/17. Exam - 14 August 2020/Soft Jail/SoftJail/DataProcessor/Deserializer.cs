namespace SoftJail.DataProcessor
{    
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using AutoMapper;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const  string ErrorMessage = "Invalid Data";

        private const string SuccessMessage_Department_Cell = "Imported {0} with {1} cells";

        private const string SuccessMessage_Prisoner_Mail = "Imported {0} {1} years old";

        private const string SuccessMessage_Officer = "Imported {0} ({1} prisoners)";


        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var extractedData = JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentCellDTO>>(jsonString);

            StringBuilder sb = new StringBuilder();

            var dataToImport = new HashSet<Department>();

            foreach (var departmentInfo in extractedData)
            {
                bool hasInvalidCell = false;

                if (!IsValid(departmentInfo)                     
                    || !departmentInfo.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cell in departmentInfo.Cells)
                {
                    if (!IsValid(cell))
                    {
                        sb.AppendLine(ErrorMessage);
                        hasInvalidCell = true;
                        break;
                    }
                }

                if (hasInvalidCell) 
                {
                    continue;
                }

                Department currentDepartment = Mapper.Map<Department>(departmentInfo);                
               
               dataToImport.Add(currentDepartment);

                sb.AppendLine(string.Format(SuccessMessage_Department_Cell, 
                    currentDepartment.Name, currentDepartment.Cells.Count));

            }

            context.Departments.AddRange(dataToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var extractedData = JsonConvert.DeserializeObject<IEnumerable<ImportPrisonerMailDTO>>(jsonString);

            StringBuilder sb = new StringBuilder();

            var dataToImport = new HashSet<Prisoner>();

            foreach (var prisonerInfo in extractedData)
            {
                bool hasInvalidMail = false;

                if (!IsValid(prisonerInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var mailInfo in prisonerInfo.Mails)
                {
                    if (!IsValid(mailInfo))
                    {                        
                        hasInvalidMail = true;
                        break;
                    }
                }

                if (hasInvalidMail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner currentPrisoner = Mapper.Map<Prisoner>(prisonerInfo);

                dataToImport.Add(currentPrisoner);

                sb.AppendLine(string.Format(SuccessMessage_Prisoner_Mail, 
                    currentPrisoner.FullName, currentPrisoner.Age));
            }

            context.Prisoners.AddRange(dataToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDTO[]), root);

            using StringReader reader = new StringReader(xmlString);

            ImportOfficerDTO[] extractedData = (ImportOfficerDTO[])serializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();
            HashSet<Officer> officersToImport = new HashSet<Officer>();

            foreach (var officerInfo in extractedData)
            {
                if (!IsValid(officerInfo))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object currentPosition;
                bool isValidEnumPosition = Enum.TryParse(typeof(Position), officerInfo.Position, out  currentPosition);
                object currentWeapon;
                bool isValidEnumWeapon = Enum.TryParse(typeof(Weapon), officerInfo.Weapon, out currentWeapon);

                if (!isValidEnumPosition || !isValidEnumWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer currentOfficer = Mapper.Map<Officer>(officerInfo);
                currentOfficer.Position = (Position)currentPosition;
                currentOfficer.Weapon = (Weapon)currentWeapon;

                OfficerPrisoner[] prisoners = officerInfo.Prisoners
                    .Select(p => new OfficerPrisoner
                    { 
                        PrisonerId = p.Id,
                        Officer = currentOfficer
                    })
                    .ToArray();
                
                currentOfficer.OfficerPrisoners = prisoners;

                officersToImport.Add(currentOfficer);

                sb.AppendLine(string.Format(SuccessMessage_Officer, 
                    currentOfficer.FullName, currentOfficer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();   
        }

        private static bool IsValid(object obj)
         {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}