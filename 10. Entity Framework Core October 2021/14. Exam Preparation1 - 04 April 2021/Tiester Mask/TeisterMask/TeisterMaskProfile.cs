namespace TeisterMask
{
    using System;
    using System.Linq;
    using System.Globalization;
    
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ImportDto;
    using DataProcessor.ExportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            CreateMap<ImportEmployeeDTO, Employee>()
                .ForMember(e => e.Username, opt => opt.MapFrom(ie => ie.Username))               
                .ForMember(e => e.Email, opt => opt.MapFrom(ie => ie.Email))                
                .ForMember(e => e.Phone, opt => opt.MapFrom(ie => ie.Phone));

            CreateMap<ImportTaskDTO, Task>()
                .ForMember(t => t.Name, opt => opt.MapFrom(it => it.Name))
                .ForMember(t => t.OpenDate, opt => opt.MapFrom(it => 
                                DateTime.ParseExact(it.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(t => t.DueDate, opt => opt.MapFrom(it => 
                                DateTime.ParseExact(it.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(t => t.ExecutionType, opt => opt.MapFrom(it => it.ExecutionType))
                .ForMember(t => t.LabelType, opt => opt.MapFrom(it => it.LabelType));

            CreateMap<ImportProjectDTO, Project>()
                .ForMember(p => p.Name, opt => opt.MapFrom(ip => ip.Name))
                .ForMember(p => p.OpenDate,opt => opt.MapFrom(ip => 
                                DateTime.ParseExact(ip.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(p => p.DueDate, opt => opt.MapFrom(ip => 
                                string.IsNullOrWhiteSpace(ip.DueDate) 
                                ? null 
                                : (DateTime?)DateTime.ParseExact(ip.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));


            CreateMap<Task, ExportTaskDTO>()
                .ForMember(et => et.Name, 
                                opt => opt.MapFrom(t => t.Name))
                .ForMember(et => et.OpenDate, 
                                opt => opt.MapFrom(t => t.OpenDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(et => et.DueDate, 
                                opt => opt.MapFrom(t => t.DueDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(et => et.LabelType, 
                                opt => opt.MapFrom(t => t.LabelType.ToString()))
                .ForMember(et => et.ExecutionType, 
                                opt => opt.MapFrom(t => t.ExecutionType.ToString()));


            CreateMap<Employee, ExportEmployeeDTO>()
                .ForMember(ee => ee.Username, opt => opt.MapFrom(e => e.Username))
                .ForMember(ee => ee.TasksToExport,
                                opt => opt.MapFrom(e => e.EmployeesTasks
                                                        .Select(et => et.Task) 
                                                        .ToArray()));


            CreateMap<Task, ExportXMLTaskDTO>()
                .ForMember(et => et.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(et => et.LabelType, opt => opt.MapFrom(t => t.LabelType.ToString()));


            CreateMap<Project, ExportProjectDTO>()
                .ForMember(ep => ep.TasksCount, opt => opt.MapFrom(p => p.Tasks.Count))
                .ForMember(ep => ep.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(ep => ep.HasEndDate, opt => opt.MapFrom(p => p.DueDate.HasValue ? "Yes" : "No"))
                .ForMember(ep => ep.Tasks, opt => opt.MapFrom(p => p.Tasks
                                                                    .ToArray()
                                                                    .OrderBy(t => t.Name)
                                                                    .ToArray()));

        }
    }
}
