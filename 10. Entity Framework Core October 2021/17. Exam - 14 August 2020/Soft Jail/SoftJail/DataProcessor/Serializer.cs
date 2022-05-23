namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            //var prisoners = context.Prisoners
            //    .Where(p => ids.Contains(p.Id))
            //    .OrderBy(p => p.FullName)
            //    .ThenBy(p => p.Id)
            //    .Select(p => new ExportPrisonerDTO
            //    {
            //        Id = p.Id,
            //        Name = p.FullName,
            //        CellNumber = p.Cell.CellNumber,
            //        TotalOfficerSalary = Math.Round(p.PrisonerOfficers
            //                            .Sum(po => po.Officer.Salary), 2),
            //        Officers = p.PrisonerOfficers
            //                .Select(op => op.Officer)
            //                .Select(o => new ExportOfficerDTO
            //                {
            //                    OfficerName = o.FullName,
            //                    Department = o.Department.Name
            //                })
            //                .OrderBy(o => o.OfficerName)
            //                .ToArray()
            //    })
            //    .ToArray();

            Prisoner[] dataToExport = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            ExportPrisonerDTO[] prisoners = dataToExport
                .AsQueryable()
                .ProjectTo<ExportPrisonerDTO>(Mapper.Configuration)
                .ToArray();

            string prisonersAsJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prisonersAsJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonersToFilter = prisonersNames
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerMailDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder dataToExport = new StringBuilder();

            using StringWriter writer = new StringWriter(dataToExport);

            Prisoner[] dataToexport = context.Prisoners
                .Where(p => prisonersToFilter.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            ExportPrisonerMailDTO[] exportPrisoners = dataToexport
                .AsQueryable()
                .ProjectTo<ExportPrisonerMailDTO>(Mapper.Configuration)
                .ToArray();

            serializer.Serialize(writer, exportPrisoners, namespaces);

            return dataToExport.ToString().TrimEnd();
        }
    }
}