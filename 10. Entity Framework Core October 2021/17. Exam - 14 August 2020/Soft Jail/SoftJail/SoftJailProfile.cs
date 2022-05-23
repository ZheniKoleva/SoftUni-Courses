namespace SoftJail
{    
    using System;
    using System.Linq;
    using System.Globalization;
    
    using AutoMapper;
    
    using Data.Models;
    using DataProcessor.ImportDto;
    using DataProcessor.ExportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {  
            CreateMap<ImportCellDTO, Cell>();

            CreateMap<ImportDepartmentCellDTO, Department>()
                .ForMember(d => d.Name, opt => opt.MapFrom(idc => idc.Name))
                .ForMember(d => d.Cells, opt => opt.MapFrom(idc => idc.Cells.Select(c => c)));

            CreateMap<ImportMailDTO, Mail>();

            CreateMap<ImportPrisonerMailDTO, Prisoner>()
                .ForMember(p => p.FullName, opt => opt.MapFrom(ipm => ipm.FullName))
                .ForMember(p => p.Nickname, opt => opt.MapFrom(ipm => ipm.Nickname))
                .ForMember(p => p.Age, opt => opt.MapFrom(ipm => ipm.Age))
                .ForMember(p => p.IncarcerationDate,
                                opt => opt.MapFrom(ipm => DateTime.ParseExact(ipm.IncarcerationDate,
                                "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(p => p.ReleaseDate,
                                 opt => opt.MapFrom(ipm => string.IsNullOrWhiteSpace(ipm.ReleaseDate)
                                 ? null
                                 : (DateTime?)DateTime.ParseExact(ipm.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(p => p.Bail, opt => opt.MapFrom(ipm => ipm.Bail))
                .ForMember(p => p.CellId, opt => opt.MapFrom(ipm => ipm.CellId))
                .ForMember(p => p.Mails, opt => opt.MapFrom(ipm => ipm.Mails.Select(m => m).ToArray()));

            CreateMap<ImportOfficerDTO, Officer>()
                .ForMember(o => o.FullName, opt => opt.MapFrom(iop => iop.Name))
                .ForMember(o => o.Salary, opt => opt.MapFrom(iop => iop.Money))
                .ForMember(o => o.DepartmentId, opt => opt.MapFrom(iop => iop.DepartmentId));

            CreateMap<Officer, ExportOfficerDTO>()
                .ForMember(eo => eo.OfficerName, opt => opt.MapFrom(o => o.FullName))
                .ForMember(eo => eo.Department, opt => opt.MapFrom(o => o.Department.Name));

            CreateMap<Prisoner, ExportPrisonerDTO>()
                .ForMember(ep => ep.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(ep => ep.Name, opt => opt.MapFrom(p => p.FullName))
                .ForMember(ep => ep.CellNumber, opt => opt.MapFrom(p => p.Cell.CellNumber))
                .ForMember(ep => ep.Officers, opt => opt.MapFrom(p => p.PrisonerOfficers
                                                                       .Select(op => op.Officer)
                                                                       .OrderBy(o => o.FullName)
                                                                       .Select(o => o)
                                                                       .ToArray()))
                .ForMember(ep => ep.TotalOfficerSalary, 
                               opt => opt.MapFrom(p => Math.Round(p.PrisonerOfficers
                                                                   .Sum(op => op.Officer.Salary), 2)));
                 

            CreateMap<Mail, ExportMailDTO>()
                .ForMember(em => em.Description, 
                                opt => opt.MapFrom(m => string.Join("", m.Description.Reverse())));

            CreateMap<Prisoner, ExportPrisonerMailDTO>()
                .ForMember(epm => epm.Id, opt => opt.MapFrom(p => p.Id.ToString()))
                .ForMember(epm => epm.Name, opt => opt.MapFrom(p => p.FullName))
                .ForMember(epm => epm.IncarcerationDate, 
                                    opt => opt.MapFrom(p => p.IncarcerationDate
                                                             .ToString("yyyy-MM-dd",CultureInfo.InvariantCulture)))
                .ForMember(epm => epm.Mails, 
                                    opt => opt.MapFrom(p => p.Mails.Select(m => m).ToArray()));

        }
    }
}
