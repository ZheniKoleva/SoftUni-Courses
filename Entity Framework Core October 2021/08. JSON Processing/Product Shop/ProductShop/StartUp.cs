using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.DTOs.ExportDTOs;
using ProductShop.DTOs.ImportDTOs;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {   
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Database created successfully!");

            //Task 01.Import Users
            string usersData = File.ReadAllText("Datasets/users.json");
            string importedUsers = ImportUsers(context, usersData);
            Console.WriteLine(importedUsers);

            //Task 02.Import Products
            string productsData = File.ReadAllText("Datasets/products.json");
            string importedProducts = ImportProducts(context, productsData);
            Console.WriteLine(importedProducts);

            //Task 03.Import Categories
            string categoriesData = File.ReadAllText("Datasets/categories.json");
            string importedCategories = ImportCategories(context, categoriesData);
            Console.WriteLine(importedCategories);

            //Task 04.Import Categories and Products
            string categoriesAndProductsData = File.ReadAllText("Datasets/categories-products.json");
            string importedData = ImportCategoryProducts(context, categoriesAndProductsData);
            Console.WriteLine(importedData);

            //Task 05.Export Products In Range
            string productsInRange = GetProductsInRange(context);
            File.WriteAllText("../../../DatasetsExport/products-in-range.json", productsInRange);

            //Task 06. Export Sold Products
            string usersSoldProducts = GetSoldProducts(context);
            File.WriteAllText("../../../DatasetsExport/users-sold-products.json", usersSoldProducts);

            //Task 07. Export Categories By Products Count
            string categoriesInfo = GetCategoriesByProductsCount(context);
            File.WriteAllText("../../../DatasetsExport/categories-by-products.json", categoriesInfo);

            //Task 08. Export Users and Products
            string usersProductsInfo = GetUsersWithProducts(context);
            File.WriteAllText("../../../DatasetsExport/users-and-products.json", usersProductsInfo);

        }

        //Task 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IMapper mapper = InitializeMapper();
            
            List<UserSoldProductsInfoDTO> usersProducts = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                    .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                    .ProjectTo<UserSoldProductsInfoDTO>(mapper.ConfigurationProvider)
                    .ToList();

            TotalUserProductInfoDTO final = mapper.Map<TotalUserProductInfoDTO>(usersProducts);           

            JsonSerializerSettings jsonSettings = JsonSettings();           
            
            string convertToJson = JsonConvert.SerializeObject(final, jsonSettings);

            return convertToJson;
        }

        //Task 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var categoriesInfo = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoryInfoDTO>(config);                            

            JsonSerializerSettings jsonSettings = JsonSettings();

            string convertToJson = JsonConvert.SerializeObject(categoriesInfo, jsonSettings);

            return convertToJson;
        }

        //Task 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var usersSoldProducts = context.Users                
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserSoldProductsDTO>(config); 

            string convertToJson = JsonConvert.SerializeObject(usersSoldProducts, Formatting.Indented);

            return convertToJson;
        }       

        //Task 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductInRangeDTO>(config);

            string convertToJson = JsonConvert.SerializeObject(products, Formatting.Indented);
        
            return convertToJson;
        }

        //Task 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = InitializeMapper();

            IEnumerable<ImportCategoryProductDTO> extracted = JsonConvert.DeserializeObject<IEnumerable<ImportCategoryProductDTO>>(inputJson);
               
            IEnumerable<CategoryProduct> dataToImport = mapper.Map<IEnumerable<CategoryProduct>>(extracted);

            context.CategoryProducts.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = InitializeMapper();

            IEnumerable<ImportCategoryDTO> extracted = JsonConvert.DeserializeObject<IEnumerable<ImportCategoryDTO>>(inputJson)
                .Where(c => c.Name != null);

            IEnumerable<Category> categoriesToImport = mapper.Map<IEnumerable<Category>>(extracted);

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Count()}";
        }

        //Task 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = InitializeMapper();

            IEnumerable<ImportProductDTO> extracted = JsonConvert.DeserializeObject<IEnumerable<ImportProductDTO>>(inputJson);

            IEnumerable<Product> productsToImport = mapper.Map<IEnumerable<Product>>(extracted);

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {productsToImport.Count()}";
        }

        //Task 01 
        public static string ImportUsers(ProductShopContext context, string usersData)
        {
            IMapper mapper = InitializeMapper();

            IEnumerable<ImportUserDTO> extracted = JsonConvert.DeserializeObject<IEnumerable<ImportUserDTO>>(usersData);

            IEnumerable<User> usersToImport = mapper.Map<IEnumerable<User>>(extracted);

            context.Users.AddRange(usersToImport);
            context.SaveChanges();

            return $"Successfully imported {usersToImport.Count()}";
        }

        private static IMapper InitializeMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();                
            });

            IMapper mapper = new Mapper(config);

            return mapper;
        }

        private static JsonSerializerSettings JsonSettings()
        {
            return new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore // for Task 08
            };
        }
    }
}