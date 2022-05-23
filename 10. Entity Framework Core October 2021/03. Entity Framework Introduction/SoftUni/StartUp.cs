using System;
using System.Globalization;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dataBase = new SoftUniContext();

            //Task 3
            string employeesFullInfo = GetEmployeesFullInformation(dataBase);
            Console.WriteLine(employeesFullInfo);

            //Task 4
            string employeesWithSalaryoOver50000 = GetEmployeesWithSalaryOver50000(dataBase);
            Console.WriteLine(employeesWithSalaryoOver50000);

            //Task 5
            string employeesFromResearch = GetEmployeesFromResearchAndDevelopment(dataBase);
            Console.WriteLine(employeesFromResearch);

            //Task 6
            string employeesAddresses = AddNewAddressToEmployee(dataBase);
            Console.WriteLine(employeesAddresses);

            //Task 7
            string employeesProjects = GetEmployeesInPeriod(dataBase);
            Console.WriteLine(employeesProjects);

            //Task 8
            string addresses = GetAddressesByTown(dataBase);
            Console.WriteLine(addresses);

            //Task 9
            string employee147Info = GetEmployee147(dataBase);
            Console.WriteLine(employee147Info);

            //Task 10
            string departmentsInfo = GetDepartmentsWithMoreThan5Employees(dataBase);
            Console.WriteLine(departmentsInfo);

            //Task 11
            string last10ProjectsInfo = GetLatestProjects(dataBase);
            Console.WriteLine(last10ProjectsInfo);

            //Task 12
            string employeesIncreasedSaalries = IncreaseSalaries(dataBase);
            Console.WriteLine(employeesIncreasedSaalries);

            //Task 13
            string employeesStartingWithSa = GetEmployeesByFirstNameStartingWithSa(dataBase);
            Console.WriteLine(employeesStartingWithSa);

            //Task 14
            string projectsLeft = DeleteProjectById(dataBase);
            Console.WriteLine(projectsLeft);

            //Task 15
            string deletedAddressesCount = RemoveTown(dataBase);
            Console.WriteLine(deletedAddressesCount);

        }

        //Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            string townToRemove = "Seattle";

            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name.Equals(townToRemove));

            int deletedCount = addressesToRemove.Count();               

            context.Employees
                .Where(e => addressesToRemove.Any(a => a.AddressId == e.AddressId))
                .ToList()
                .ForEach(e => e.AddressId = null);

            context.Addresses.RemoveRange(addressesToRemove);

            var townInfo = context.Towns
                .First(t => t.Name.Equals(townToRemove));

            context.Towns.Remove(townInfo);

            context.SaveChanges();

            return $"{deletedCount} addresses in {townToRemove} were deleted";
        }

        //Task 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            int projectIdToDelete = 2;

            var dataToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectIdToDelete);
            context.EmployeesProjects.RemoveRange(dataToDelete);

            var project = context.Projects.Find(projectIdToDelete);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projectsLeft = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            return string.Join(Environment.NewLine, projectsLeft);
        }

        //Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var empl in employees)
            {
                output.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        //Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesToChange = context.Employees
                .Where(e => departments.Contains(e.Department.Name));

            foreach (var empl in employeesToChange)
            {
                empl.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToChange
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var empl in employees)
            {
                output.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        //Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projectsInfo = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var project in projectsInfo)
            {
                output.AppendLine(project.Name)
                      .AppendLine(project.Description)
                      .AppendLine(project.StartDate);
            }

            return output.ToString().TrimEnd();
        }

        //Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsInfo = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    DepEmployees = d.Employees
                    .Select(de => new
                    {
                        de.FirstName,
                        de.LastName,
                        de.JobTitle
                    })
                    .OrderBy(de => de.FirstName)
                    .ThenBy(de => de.LastName)
                    .ToArray()
                })
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var dep in departmentsInfo)
            {
                output.AppendLine($"{dep.Name} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var empl in dep.DepEmployees)
                {
                    output.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var info = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(p => p)
                    .ToArray()
                })
                .SingleOrDefault();

            StringBuilder output = new StringBuilder();
            output.AppendLine($"{info.FirstName} {info.LastName} - {info.JobTitle}");

            foreach (var project in info.Projects)
            {
                output.AppendLine(project);
            }

            return output.ToString().TrimEnd();
        }

        //Task 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var a in addresses)
            {
                output.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return output.ToString().TrimEnd();
        }

        //Task 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeeProjects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                                  ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                  : "not finished"

                    })
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.EmployeeProjects)
                {
                    output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address addressToImport = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(addressToImport);

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName.Equals("Nakov"));

            employee.Address = addressToImport;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            return string.Join(Environment.NewLine, addresses);
        }

        //Task 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
              .Where(e => e.Department.Name.Equals("Research and Development"))
              .OrderBy(e => e.Salary)
              .ThenByDescending(e => e.FirstName)
              .Select(e => new
              {
                  e.FirstName,
                  e.LastName,
                  DepartmentName = e.Department.Name,
                  e.Salary
              })
              .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var empl in employees)
            {
                output.AppendLine($"{empl.FirstName} {empl.LastName} from {empl.DepartmentName} - ${empl.Salary:f2}");
            }

            return output.ToString().TrimEnd();

        }

        //Task 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
               .Where(e => e.Salary > 50000)
               .OrderBy(e => e.FirstName)
               .Select(e => new Employee
               {
                   FirstName = e.FirstName,                  
                   Salary = e.Salary
               })
               .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (Employee empl in employees)
            {
                output.AppendLine($"{empl.FirstName} - {empl.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new Employee
                {
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (Employee empl in employees)
            {
                output.AppendLine($"{empl.FirstName} {empl.LastName} {empl.MiddleName} {empl.JobTitle} {empl.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
