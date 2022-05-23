namespace ProductShop
{
    using System.Linq;
    using AutoMapper;

    using DTOs.ImportDTOs;
    using DTOs.ExportDTOs;
    using Models;
    using System.Collections.Generic;

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
            CreateMap<Product, ProductInRangeDTO>()
                .ForMember(pr => pr.Seller,
                            opt => opt.MapFrom(p => $"{p.Seller.FirstName} {p.Seller.LastName}"));

            //Task 06
            CreateMap<Product, SoldProductDTO>();

            CreateMap<User, UserSoldProductsDTO>();

            //Task 07
            CreateMap<Category, CategoryInfoDTO>()
                .ForMember(c => c.Category,
                            opt => opt.MapFrom(c => c.Name))
                .ForMember(c => c.ProductsCount,
                            opt => opt.MapFrom(c => c.CategoryProducts.Count))
                .ForMember(c => c.AveragePrice,
                            opt => opt.MapFrom(c => c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2")))
                .ForMember(c => c.TotalRevenue,
                            opt => opt.MapFrom(c => c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")));

            //Task 8
            CreateMap<Product, ProductInfoDTO>();

            CreateMap<User, SoldProductsInfoDTO>()
                .ForMember(spi => spi.Products,
                            opt => opt.MapFrom(u => u.ProductsSold.Where(x => x.Buyer != null)));

            CreateMap<User, UserSoldProductsInfoDTO>()
                .ForMember(upi => upi.SoldProducts,
                        opt => opt.MapFrom(u => u));

            CreateMap<ICollection<UserSoldProductsInfoDTO>, TotalUserProductInfoDTO>()
                .ForMember(u => u.Users, opt => opt.MapFrom(x => x));               
                           
        }
    }
}
