using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTO.ImportDTOs;
using CarDealer.DTO.ExportDTOs;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was deleted successfully!");
            context.Database.EnsureCreated();
            Console.WriteLine("Database was created successfully!");

            //Task 01. Import Suppliers
            string suppliersData = File.ReadAllText("Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(context, suppliersData));

            //Task 02. Import Parts
            string partsData = File.ReadAllText("Datasets/parts.json");
            Console.WriteLine(ImportParts(context, partsData));

            //Task 03. Import Cars
            string carsData = File.ReadAllText("Datasets/cars.json");
            Console.WriteLine(ImportCars(context, carsData));

            //Task 04. Import Customers
            string customersData = File.ReadAllText("Datasets/customers.json");
            Console.WriteLine(ImportCustomers(context, customersData));

            //Task 05. Import Sales
            string salesData = File.ReadAllText("Datasets/sales.json");
            Console.WriteLine(ImportSales(context, salesData));

            //Task 06. Export Ordered Customers
            string orderedCustomers = GetOrderedCustomers(context);
            File.WriteAllText("../../../DatasetsOutput/ordered-customers.json", orderedCustomers);

            //Task 07. Export Cars From Make Toyota
            string toyotaCars = GetCarsFromMakeToyota(context);
            File.WriteAllText("../../../DatasetsOutput/toyota-cars.json", toyotaCars);

            //Task 08. Export Local Suppliers
            string localSuppliers = GetLocalSuppliers(context);
            File.WriteAllText("../../../DatasetsOutput/local-suppliers.json", localSuppliers);

            //Task 09. Export Cars With Their List Of Parts
            string carsWithParts = GetCarsWithTheirListOfParts(context);
            File.WriteAllText("../../../DatasetsOutput/cars-and-parts.json", carsWithParts);

            //Task 10. Export Total Sales By Customer
            string salesByCustomer = GetTotalSalesByCustomer(context);
            File.WriteAllText("../../../DatasetsOutput/customers-total-sales.json", salesByCustomer);

            //Task 11. Export Sales With Applied Discount
            string salesWithDiscount = GetSalesWithAppliedDiscount(context);
            File.WriteAllText("../../../DatasetsOutput/sales-discounts.json", salesWithDiscount);
        }

        //Task 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            InitializeMapper();

            var sales = context.Sales
                .ProjectTo<ExportSalesDiscountDTO>(mapper.ConfigurationProvider)
                .Take(10);

            string salesToJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesToJson;
        }

        //Task 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeMapper();

            var sales = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .ProjectTo<ExportCustomerSalesDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(s => s.SpentMoney)
                .ThenByDescending(s => s.BoughtCars);

            var salesToJson = JsonConvert.SerializeObject(sales, new JsonSerializerSettings
            { 
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                { 
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });
            
            return salesToJson;
        }

        //Task 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        { 
            InitializeMapper();

            var carsWithParts = context.Cars                              
                .ProjectTo<ExportCarWithPartsDTO>(mapper.ConfigurationProvider);

            string carsWithPartsJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            return carsWithPartsJson;
        }

        //Task 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeMapper();

            var filteredSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportLocalSupplierDTO>(mapper.ConfigurationProvider);

            string suppleiersToJson = JsonConvert.SerializeObject(filteredSuppliers, Formatting.Indented);
            
            return suppleiersToJson;
        }

        //Task 07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            string searchedMake = "Toyota";

            InitializeMapper();

            var filteredCars = context.Cars
                .Where(c => c.Make.Equals(searchedMake))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarByMakeDTO>(mapper.ConfigurationProvider);

            string carsToJson = JsonConvert.SerializeObject(filteredCars, Formatting.Indented);
        
            return carsToJson;
        }

        //Task 06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InitializeMapper();

            var customers = context.Customers
                 .OrderBy(c => c.BirthDate)
                 .ThenBy(c => c.IsYoungDriver)
                 .ProjectTo<ExportCustomerDTO>(mapper.ConfigurationProvider);

            string customersToJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersToJson;        
        }

        //Task 05
        public static string ImportSales(CarDealerContext context, string inputJson)
        { 
            InitializeMapper();

            var salesData = JsonConvert.DeserializeObject<IEnumerable<ImportSaleDTO>>(inputJson);           

            var salesToImport = mapper.Map<IEnumerable<Sale>>(salesData);

            context.AddRange(salesToImport);
            context.SaveChanges();

            return $"Successfully imported {salesToImport.Count()}.";
        }

        //Task 04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        { 
            InitializeMapper();

            var customersData = JsonConvert.DeserializeObject<IEnumerable<ImportCustomerDTO>>(inputJson);

            var customersToImport = mapper.Map<IEnumerable<Customer>>(customersData);

            context.AddRange(customersToImport);
            context.SaveChanges();

            return $"Successfully imported {customersToImport.Count()}.";
        }

        //Task 03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var carsData = JsonConvert.DeserializeObject<IEnumerable<ImportCarDTO>>(inputJson);
           
            List<Car> carsToImport = new List<Car>();

           HashSet<int> existingParstsIds = context.Parts
                .Select(p => p.Id)
                .ToHashSet();

            foreach (var car in carsData)
            {
                Car currentCar = mapper.Map<Car>(car);                

                foreach (var partId in car.PartsId.Distinct())
                {
                    if (existingParstsIds.Contains(partId))
                    {
                        PartCar currentPart = new PartCar()
                        {
                            PartId = partId,
                            Car = currentCar
                        };

                        currentCar.PartCars.Add(currentPart);
                    }
                }

                carsToImport.Add(currentCar);
            }                       

            context.AddRange(carsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count()}.";
        }

        //Task 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var existingSupplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var partsData = JsonConvert.DeserializeObject<IEnumerable<ImportPartDTO>>(inputJson);

            var partsToImport = mapper.Map<IEnumerable<Part>>(partsData)
                .Where(p => existingSupplierIds.Contains(p.SupplierId));

            context.AddRange(partsToImport);
            context.SaveChanges();

            return $"Successfully imported {partsToImport.Count()}.";
        }

        //Task 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var supplierData = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierDTO>>(inputJson);

            var suppliersToImport = mapper.Map<IEnumerable<Supplier>>(supplierData);

            context.AddRange(suppliersToImport);
            context.SaveChanges();

            return $"Successfully imported {suppliersToImport.Count()}.";        
        }

        private static void InitializeMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnfg =>
            {
                cnfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}