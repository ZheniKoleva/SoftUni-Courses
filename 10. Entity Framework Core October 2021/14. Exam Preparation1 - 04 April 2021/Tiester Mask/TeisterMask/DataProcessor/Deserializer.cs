namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    using AutoMapper;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Data.Models;
    using ImportDto;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDTO[]), root);

            ImportProjectDTO[] extractedData = null;

            using (StringReader reader = new StringReader(xmlString))
            {
                extractedData = (ImportProjectDTO[])serializer.Deserialize(reader);
            }

            ICollection<Project> projectsToImport = new HashSet<Project>();

            foreach (var projectInfo in extractedData)
            {
                if (!IsValid(projectInfo))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Project currentProject = Mapper.Map<Project>(projectInfo);

                ICollection<Task> currentProjectTasks = new HashSet<Task>();

                foreach (var taskInfo in projectInfo.TaskToImport)
                {
                    if (!IsValid(taskInfo))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task currentTask = Mapper.Map<Task>(taskInfo);

                    if (currentTask.OpenDate < currentProject.OpenDate ||
                        (currentProject.DueDate.HasValue && currentTask.DueDate > currentProject.DueDate))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentProjectTasks.Add(currentTask);

                }

                currentProject.Tasks = currentProjectTasks;

                projectsToImport.Add(currentProject);

                output.AppendLine(String.Format(SuccessfullyImportedProject,
                    currentProject.Name, currentProject.Tasks.Count));

            }

            context.Projects.AddRange(projectsToImport);
            context.SaveChanges();

            return output.ToString().TrimEnd();

        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Employee> employeesToImport = new HashSet<Employee>();

            var extractedData = JsonConvert.DeserializeObject<IEnumerable<ImportEmployeeDTO>>(jsonString);

            foreach (var employeeInfo in extractedData)
            {
                if (!IsValid(employeeInfo))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = Mapper.Map<Employee>(employeeInfo);

                ICollection<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();

                foreach (var taskId in employeeInfo.TasksId.Distinct())
                {
                    Task task = context.Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask currentTask = new EmployeeTask()
                    {
                        Task = task,
                        Employee = employee,
                    };

                    employeeTasks.Add(currentTask);
                }               

                employee.EmployeesTasks = employeeTasks;

                employeesToImport.Add(employee);

                output.AppendLine(String.Format(SuccessfullyImportedEmployee,
                   employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employeesToImport);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}