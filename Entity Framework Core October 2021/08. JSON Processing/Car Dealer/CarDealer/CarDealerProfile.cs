namespace CarDealer
{
    using System.Linq;
    using System.Globalization;
    using AutoMapper;

    using CarDealer.Models;
    using CarDealer.DTO.ImportDTOs;
    using CarDealer.DTO.ExportDTOs;


    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Task 01
            CreateMap<ImportSupplierDTO, Supplier>();

            //Task 02
            CreateMap<ImportPartDTO, Part>();

            //Task 03
            CreateMap<ImportCarDTO, Car>();                

            //Task 04
            CreateMap<ImportCustomerDTO, Customer>();

            //Task 05
            CreateMap<ImportSaleDTO, Sale>();

            //Task 06
            CreateMap<Customer, ExportCustomerDTO>()
                .ForMember(ec => ec.BirthDate,
                             opt => opt.MapFrom(c => 
                             c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            //Task 07
            CreateMap<Car, ExportCarByMakeDTO>();

            //Task 08
            CreateMap<Supplier, ExportLocalSupplierDTO>()
                .ForMember(els => els.PartsCount,
                                opt=> opt.MapFrom(s => s.Parts.Count));

            //Task 09
            CreateMap<PartCar, ExportPartNamePriceDTO>()
                .ForMember(pi => pi.Name,
                              opt => opt.MapFrom(pc => pc.Part.Name))
                .ForMember(pi => pi.Price,
                              opt => opt.MapFrom(pc => $"{pc.Part.Price:f2}"));               
            CreateMap<Car, ExportCarInfoDTO>();
            CreateMap<Car, ExportCarWithPartsDTO>()
                .ForMember(ecp => ecp.Car,
                               opt => opt.MapFrom(c => c))
                .ForMember(ecp => ecp.PartCars,
                               opt => opt.MapFrom(c => c.PartCars));

            //Task 10
            CreateMap<Customer, ExportCustomerSalesDTO>()
                .ForMember(ec => ec.FullName,
                              opt => opt.MapFrom(c => c.Name))
                .ForMember(ec => ec.BoughtCars,
                              opt => opt.MapFrom(c => c.Sales.Count))
                .ForMember(ec => ec.SpentMoney,
                              opt => opt.MapFrom(c => c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))));

            //Task 11
            CreateMap<Sale, ExportSalesDiscountDTO>()
                .ForMember(esd => esd.Car,
                                opt => opt.MapFrom(s => s.Car))
                .ForMember(esd => esd.CustomerName,
                                opt => opt.MapFrom(s => s.Customer.Name))
                .ForMember(esd => esd.Discount, 
                                opt => opt.MapFrom(s => $"{s.Discount:f2}"))
                .ForMember(esd => esd.Price,
                                opt => opt.MapFrom(s => $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}"))
                .ForMember(esd => esd.PriceWithDiscount, 
                                opt => opt.MapFrom(s => 
                                  $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100):f2}"));
                
        }
    }
}
