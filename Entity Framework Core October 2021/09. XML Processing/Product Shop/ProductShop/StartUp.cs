using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        private static string destinationFolder = "../../../DatasetsExport/";
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            ResetDatabase(context);

            //Task 01.Import Users
            string usersXML = File.ReadAllText("Datasets/users.xml");
            Console.WriteLine(ImportUsers(context, usersXML));

            //Task 02. Import Products
            string productsXML = File.ReadAllText("Datasets/products.xml");
            Console.WriteLine(ImportProducts(context, productsXML));

            //Task 03. Import Categories
            string categoriesXML = File.ReadAllText("Datasets/categories.xml");
            Console.WriteLine(ImportCategories(context, categoriesXML));

            //Task 04. Import Categories and Products
            string categoriesAndProductsXML = File.ReadAllText("Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(context, categoriesAndProductsXML));

            //Task 05. Export Products In Range
            string productsInRange = GetProductsInRange(context);
            File.WriteAllText(destinationFolder + "products-in-range.xml", productsInRange);

            //Task 06. Export Sold Products
            string usersSoldProducts = GetSoldProducts(context);
            File.WriteAllText(destinationFolder + "users-sold-products.xml", usersSoldProducts);

            //Task 07. Export Categories By Products Count
            string categoriesByProductsCount = GetCategoriesByProductsCount(context);
            File.WriteAllText(destinationFolder + "categories-by-products.xml", categoriesByProductsCount);

            //Task 08. Export Users and Products
            string usersAndProducts = GetUsersWithProducts(context);
            File.WriteAllText(destinationFolder + "users-and-products.xml", usersAndProducts);

        }

        //Task 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializeMapper();

            //Works locally, but gudge doesn't "like" it 
            ExportUserFullInfoDTO[] usersFullInfo = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .ProjectTo<ExportUserFullInfoDTO>(mapper.ConfigurationProvider)
                .ToArray();

            ExportAllUsersInfoDTO finalResult = mapper.Map<ExportAllUsersInfoDTO>(usersFullInfo);

            //For Gudge!!!!!!!!!
            //ExportUserFullInfoDTO[] usersFullInfo = context.Users
            //    .ToArray()    // because of gudge
            //    .Where(u => u.ProductsSold.Any())
            //    .OrderByDescending(u => u.ProductsSold.Count)
            //    .Take(10)
            //    .Select(u => new ExportUserFullInfoDTO
            //    {
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        Age = u.Age,
            //        SoldProducts = new ExportSoldProductsAsArrayDTO
            //        {
            //            Count = u.ProductsSold.Count,
            //            Products = u.ProductsSold
            //            .Select(p => new ExportProductDTO
            //            {
            //                Name = p.Name,
            //                Price = p.Price
            //            })
            //            .OrderByDescending(p => p.Price)
            //            .ToArray()
            //        }
            //    })
            //    .ToArray();

            //ExportAllUsersInfoDTO finalResult = new ExportAllUsersInfoDTO
            //{
            //    Count = context.Users.Count(u => u.ProductsSold.Any()),
            //    Users = usersFullInfo
            //};

            XmlSerializer serializer = InitializeSerializer("Users", typeof(ExportAllUsersInfoDTO));

            string output = GenerateOutput(finalResult, serializer);           

            return output;
        }

        //Task 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        { 
            InitializeMapper();

            ExportCategoryByProductCountDTO[] categories = context.Categories
                .ProjectTo<ExportCategoryByProductCountDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("Categories", typeof(ExportCategoryByProductCountDTO[]));
            
            string output = GenerateOutput(categories, serializer);           

            return output;

        }

        //Task 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeMapper();

            ExportUserSoldProductsDTO[] usersSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserSoldProductsDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("Users", typeof(ExportUserSoldProductsDTO[]));                        

            string output = GenerateOutput(usersSoldProducts, serializer);
          
            return output;
        
        }

        //Task 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            const decimal MIN_PRICE = 500;
            const decimal MAX_Price = 1000;

            InitializeMapper();

            ExportProductInRangeDTO[] products = context.Products
                .Where(p => p.Price >= MIN_PRICE && p.Price <= MAX_Price)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("Products", typeof(ExportProductInRangeDTO[]));           

            string output = GenerateOutput(products, serializer);            

            return output;
        }       

        //Task 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("CategoryProducts", typeof(ImportCategoryProductDTO[]));
            
            ImportCategoryProductDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportCategoryProductDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<CategoryProduct> dataToImport = mapper.Map<IEnumerable<CategoryProduct>>(extractedData)
                .Where(cp => context.Categories.Find(cp.CategoryId) != null 
                          && context.Products.Find(cp.ProductId) != null);

            context.CategoryProducts.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Categories", typeof(ImportCategoryDTO[]));            

            ImportCategoryDTO[] extractedCategories = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedCategories = (ImportCategoryDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<Category> categoriesToImport = mapper.Map<IEnumerable<Category>>(extractedCategories)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Count()}";
        }

        //Task 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Products", typeof(ImportProductDTO[]));           

            ImportProductDTO[] extractedProducts = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedProducts = (ImportProductDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();
            IEnumerable<Product> productsToImport = mapper.Map<IEnumerable<Product>>(extractedProducts);

            context.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {productsToImport.Count()}";
        }

        //Task 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Users", typeof(ImportUserDTO[]));

            ImportUserDTO[] extractedUsers = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedUsers = (ImportUserDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<User> users = mapper.Map<IEnumerable<User>>(extractedUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static string GenerateOutput<T>(T dtoData, XmlSerializer serializer)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            StringBuilder output = new StringBuilder();

            using (StringWriter writer = new StringWriter(output))
            {
                serializer.Serialize(writer, dtoData, namespaces);
            }

            return output.ToString().TrimEnd();
        }

        private static XmlSerializer InitializeSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(dtoType, root);

            return serializer;
        }

        private static void InitializeMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnfg => 
            {
                cnfg.AddProfile<ProductShopProfile>();            
            });
        
            mapper = config.CreateMapper();
        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was deleted successfully");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was created successfully");
        }

    }
}