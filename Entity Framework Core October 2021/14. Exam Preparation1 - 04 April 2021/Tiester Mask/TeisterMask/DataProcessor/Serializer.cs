namespace TeisterMask.DataProcessor
{
    using System;   
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    using System.Xml.Serialization;

    using Data;    
    using ExportDto;
    using TeisterMask.Data.Models;
    using System.Collections.Generic;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDTO[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            Project[] projects = context.Projects
                .Where(p => p.Tasks.Any())                
                .ToArray();

            ExportProjectDTO[] projectsToExport = Mapper.Map<ExportProjectDTO[]>(projects)
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            //ExportProjectDTO[] projectsToExport = context.Projects
            //    .Where(p => p.Tasks.Any())
            //    .ToArray()
            //    .OrderByDescending(p => p.Tasks.Count)
            //    .ThenBy(p => p.Name)
            //    .Select(p => new ExportProjectDTO
            //    {
            //        TasksCount = p.Tasks.Count,
            //        Name = p.Name,
            //        HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
            //        Tasks = p.Tasks
            //            .OrderBy(t => t.Name)
            //            .Select(t => new ExportXMLTaskDTO
            //            {
            //                Name = t.Name,
            //                LabelType = t.LabelType.ToString()
            //            })
            //            .ToArray()
            //    })
            //    .ToArray();

            StringBuilder result = new StringBuilder();

            using (StringWriter writer = new StringWriter(result))
            {
                xmlSerializer.Serialize(writer, projectsToExport, namespaces);
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var filteredEmployees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .ToList();

            filteredEmployees
                .ForEach(e => e.EmployeesTasks = e.EmployeesTasks
                                                 .Where(et => et.Task.OpenDate >= date)
                                                 .OrderByDescending(et => et.Task.DueDate)
                                                 .ToArray());

            ExportEmployeeDTO[] employeesToExport = Mapper.Map<ExportEmployeeDTO[]>(filteredEmployees)  
                .OrderByDescending(e => e.TasksToExport.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();  

            //ExportEmployeeDTO[] employeesToExport = context.Employees  
            //    .ToArray()
            //    .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
            //    .Select(e => new ExportEmployeeDTO
            //    {
            //        Username = e.Username,
            //        TasksToExport = e.EmployeesTasks
            //           .Where(et => et.Task.OpenDate >= date)
            //           .Select(et => et.Task)
            //           .OrderByDescending(et => et.DueDate)
            //           .ThenBy(et => et.Name)
            //           .Select(t => new ExportTaskDTO
            //           {
            //               Name = t.Name,
            //               OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
            //               DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
            //               LabelType = t.LabelType.ToString(),
            //               ExecutionType = t.ExecutionType.ToString(),
            //           })
            //           .ToArray()
            //    })
            //    .OrderByDescending(e => e.TasksToExport.Length)
            //    .ThenBy(e => e.Username)
            //    .Take(10)
            //    .ToArray();


            string outputAsJson = JsonConvert.SerializeObject(employeesToExport, Formatting.Indented);

            return outputAsJson;   
        }
    }
}