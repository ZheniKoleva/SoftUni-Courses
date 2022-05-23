using System.Linq;
using AutoMapper;

using ProductShop.Models;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Task 01
            CreateMap<ImportUserDTO, User>();

            //Task 02
            CreateMap<ImportProductDTO, Product>();

            //Task 03
            CreateMap<ImportCategoryDTO, Category>();

            //Task 04
            CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //Task 05
            CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(p => p.Buyer, 
                                opt => opt.MapFrom(p => $"{p.Buyer.FirstName} {p.Buyer.LastName}"));

            //Task 06
            CreateMap<Product, ExportProductDTO>();
            CreateMap<User, ExportUserSoldProductsDTO>();

            //Task 07
            CreateMap<Category, ExportCategoryByProductCountDTO>()
                .ForMember(ecpc => ecpc.Count,
                                    opt => opt.MapFrom(c => c.CategoryProducts.Count))
                .ForMember(ecpc => ecpc.AveragePrice,
                                    opt => opt.MapFrom(c => c.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(ecpc => ecpc.TotalRevenue,
                                    opt => opt.MapFrom(c => c.CategoryProducts.Sum(cp => cp.Product.Price)));

            //Task 08
            CreateMap<User, ExportSoldProductsAsArrayDTO>()
                .ForMember(spa => spa.Count,
                                  opt => opt.MapFrom(u => u.ProductsSold.Count))
                .ForMember(spa => spa.Products,
                                  opt => opt.MapFrom(u => u.ProductsSold
                                                           .Select(p => p)
                                                           .OrderByDescending(p => p.Price)));

            CreateMap<User, ExportUserFullInfoDTO>()
                .ForMember(ufi => ufi.SoldProducts,
                                    opt => opt.MapFrom(u => u));

            CreateMap<ExportUserFullInfoDTO[], ExportAllUsersInfoDTO>()
                .ForMember(alu => alu.Count, opt => opt.MapFrom(x => x.Length))
                .ForMember(alu => alu.Users, opt => opt.MapFrom(x => x.Take(10)));
        }
    }
}
