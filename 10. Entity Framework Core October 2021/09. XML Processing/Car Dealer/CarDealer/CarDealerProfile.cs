using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Task 01
            CreateMap<ImportSupplierDTO, Supplier>()
                .ForMember(s => s.IsImporter, 
                             opt => opt.MapFrom(s => bool.Parse(s.IsImporter)));

            //Task 02
            CreateMap<ImportPartDTO, Part>()
                .ForMember(p => p.Price,
                             opt => opt.MapFrom(ip => decimal.Parse(ip.Price)))
                .ForMember(p => p.Quantity,
                             opt => opt.MapFrom(ip => int.Parse(ip.Quantity)))
                .ForMember(p => p.SupplierId,
                             opt => opt.MapFrom(ip => int.Parse(ip.SupplierId)));

            //Task 03
            CreateMap<ImportCarDTO, Car>();
            //.ForMember(c => c.Make,
            //                opt => opt.MapFrom(ic => ic.Make))
            //.ForMember(c => c.Model,
            //                opt => opt.MapFrom(ic => ic.Model))
            //.ForMember(c => c.TravelledDistance,
            //                opt => opt.MapFrom(ic => ic.TravelledDistance));
            ////.ForMember(c => c.PartCars,
            ////                opt => opt.MapFrom(icp => icp.CarParts.Select(p => p.PartId)));
            ///

            //Task 04
            CreateMap<ImportCustomerDTO, Customer>()
                .ForMember(c => c.BirthDate,
                             opt => opt.MapFrom(ic => DateTime.Parse(ic.BirthDate, CultureInfo.InvariantCulture)))
                .ForMember(c => c.IsYoungDriver,
                             opt => opt.MapFrom(ic => bool.Parse(ic.IsYoungDriver)));

            //Task 05
            CreateMap<ImportSaleDTO, Sale>()
               .ForMember(s => s.CarId,
                            opt => opt.MapFrom(x => int.Parse(x.CarId)))
               .ForMember(s => s.CustomerId,
                            opt => opt.MapFrom(x => int.Parse(x.CustomerId)))
               .ForMember(s => s.Discount,
                            opt => opt.MapFrom(x => decimal.Parse(x.Discount)));


            //Task 06
            CreateMap<Car, ExportCarWithDistanceDTO>();

            //Task 07
            CreateMap<Car, ExportCarByMakeDTO>()
                .ForMember(ec => ec.Id,
                              opt => opt.MapFrom(c => c.Id.ToString()))
                .ForMember(ec => ec.TravelledDistance,
                              opt => opt.MapFrom(c => c.TravelledDistance.ToString()));

            //Task 08
            CreateMap<Supplier, ExportLocalSupplierDTO>()
                .ForMember(els => els.PartsCount,
                              opt => opt.MapFrom(s => s.Parts.Count));

            //Task 09
            CreateMap<Part, ExportPartNameAndPriceDTO>();
            CreateMap<Car, ExportCarWithPartsDTO>()
                .ForMember(ecp => ecp.Parts,
                               opt => opt.MapFrom(c => c.PartCars
                                                       .Select(cp => cp.Part)
                                                       .OrderByDescending(p => p.Price)));

            //Task 10
            CreateMap<Sale, ExportSalesByCustomerDTO>()
                .ForMember(esc => esc.FullName,
                                opt => opt.MapFrom(c => c.Customer.Name))
                .ForMember(esc => esc.BoughtCars,
                               opt => opt.MapFrom(c => c.Customer.Sales.Count))
                .ForMember(esc => esc.SpentMoney,
                               opt => opt.MapFrom(c => c.Car.PartCars.Sum(pc => pc.Part.Price)));

            //Task 11
            CreateMap<Car, ExportCarInfoDTO>();
            CreateMap<Sale, ExportSalesWithDiscountDTO>()
                .ForMember(esd => esd.Car,
                                opt => opt.MapFrom(s => s.Car))
                .ForMember(esd => esd.Discount,
                                opt => opt.MapFrom(s => s.Discount))
                .ForMember(esd => esd.CustomerName,
                                opt => opt.MapFrom(s => s.Customer.Name))
                .ForMember(esd => esd.Price,
                                opt => opt.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(esd => esd.PriceWithDiscount,
                                opt => opt.MapFrom(s => s.Car.PartCars
                                                        .Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100));

        }
    }
}
