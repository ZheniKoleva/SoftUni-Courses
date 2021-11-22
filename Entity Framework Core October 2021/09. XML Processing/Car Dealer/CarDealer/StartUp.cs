using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{   
    public class StartUp
    {
        private static IMapper mapper;
        private static string destinationFolder = "../../../DatasetsExport/";

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            ResetDatabase(context);

            //Task 01. Import Suppliers
            string suppliersToImport = File.ReadAllText("Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliersToImport));

            //Task 02. Import Parts
            string partsToImport = File.ReadAllText("Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, partsToImport));

            //Task 03. Import Cars
            string carsToImport = File.ReadAllText("Datasets/cars.xml");
            Console.WriteLine(ImportCars(context, carsToImport));

            //Task 04. Import Customers
            string customersToImport = File.ReadAllText("Datasets/customers.xml");
            Console.WriteLine(ImportCustomers(context, customersToImport));

            //Task 05. Import Sales
            string salesToImport = File.ReadAllText("Datasets/sales.xml");
            Console.WriteLine(ImportSales(context, salesToImport));

            //Task 06. Export Cars With Distance
            string carsWithDistance = GetCarsWithDistance(context);
            File.WriteAllText(destinationFolder + "cars.xml", carsWithDistance);

            //Task 07. Export Cars From Make BMW
            string carsFromMake = GetCarsFromMakeBmw(context);
            File.WriteAllText(destinationFolder + "bmw-cars.xml", carsFromMake);

            //Task 08. Export Local Suppliers
            string localSuppliers = GetLocalSuppliers(context);
            File.WriteAllText(destinationFolder + "local-suppliers.xml", localSuppliers);

            //Task 09. Export Cars With Their List Of Parts
            string carsWithParts = GetCarsWithTheirListOfParts(context);
            File.WriteAllText(destinationFolder + "cars-and-parts.xml", carsWithParts);

            //Task 10. Export Total Sales By Customer
            string salesByCustomer = GetTotalSalesByCustomer(context);
            File.WriteAllText(destinationFolder + "customers-total-sales.xml", salesByCustomer);

            //Task 11. Export Sales With Applied Discount
            string salesWithDiscount = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(destinationFolder + "sales-discounts.xml", salesWithDiscount);

        }

        //Task 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            InitializeMapper();

            ExportSalesWithDiscountDTO[] sales = context.Sales                
                .ProjectTo<ExportSalesWithDiscountDTO>(mapper.ConfigurationProvider)                
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("sales", typeof(ExportSalesWithDiscountDTO[]));

            string dataToExport = GenerateXMLOutput(sales, serializer);

            return dataToExport;
        }

        //Task 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeMapper();

            ExportSalesByCustomerDTO[] customers = context.Sales
                .Where(c => c.Customer.Sales.Any())                
                .ProjectTo<ExportSalesByCustomerDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("customers", typeof(ExportSalesByCustomerDTO[]));

            string dataToExport = GenerateXMLOutput(customers, serializer);

            return dataToExport;

        }

        //Task 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InitializeMapper();

            ExportCarWithPartsDTO[] cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("cars", typeof(ExportCarWithPartsDTO[]));

            string dataToExport = GenerateXMLOutput(cars, serializer);

            return dataToExport;
        }

        //Task 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeMapper();

            ExportLocalSupplierDTO[] suppliers = context.Suppliers
                .Where(s => !s.IsImporter)                
                .ProjectTo<ExportLocalSupplierDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("suppliers", typeof(ExportLocalSupplierDTO[]));

            string dataToExport = GenerateXMLOutput(suppliers, serializer);
           
            return dataToExport;
        }

        //Task 07
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            string searchedMake = "BMW";

            InitializeMapper();

            ExportCarByMakeDTO[] cars = context.Cars
                .Where(c => c.Make.Equals(searchedMake))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)                
                .ProjectTo<ExportCarByMakeDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("cars", typeof(ExportCarByMakeDTO[]));

            string dataToExport = GenerateXMLOutput(cars, serializer);

            return dataToExport;
        }

        //Task 06
        public static string GetCarsWithDistance(CarDealerContext context)
        { 
            long distanceFilter = 2_000_000;
            InitializeMapper();

            ExportCarWithDistanceDTO[] cars = context.Cars
                .Where(c => c.TravelledDistance > distanceFilter)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer serializer = InitializeSerializer("cars", typeof(ExportCarWithDistanceDTO[]));

            string dataToExport = GenerateXMLOutput(cars, serializer);

            return dataToExport;
        }       

        //Task 05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Sales", typeof(ImportSaleDTO[]));

            ImportSaleDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportSaleDTO[])serializer.Deserialize(reader);
            }            

            InitializeMapper();

            IEnumerable<Sale> dataToImport = mapper.Map<IEnumerable<Sale>>(extractedData)
                .Where(s => context.Cars.Any(c => c.Id == s.CarId));

            context.Sales.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 04
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Customers", typeof(ImportCustomerDTO[]));

            ImportCustomerDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportCustomerDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<Customer> dataToImport = mapper.Map<IEnumerable<Customer>>(extractedData);

            context.Customers.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 03
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Cars", typeof(ImportCarDTO[]));

            ImportCarDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportCarDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            HashSet<Car> dataToImport = new HashSet<Car>();            

            IEnumerable<int> existingParts = context.Parts.Select(x => x.Id);          

            foreach (var carSet in extractedData)
            {
                Car currentCar = mapper.Map<Car>(carSet);

                PartCar[] carParts = carSet.CarParts
                    .Where(id => existingParts.Contains(id.PartId))
                    .Select(id => id.PartId)
                    .Distinct()
                    .Select(id => new PartCar
                    {
                        PartId = id,
                        Car = currentCar
                    })
                    .ToArray();

                currentCar.PartCars = carParts;
                
                dataToImport.Add(currentCar);
            }

            context.Cars.AddRange(dataToImport);
            context.SaveChanges();            

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 02
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Parts", typeof(ImportPartDTO[]));

            ImportPartDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportPartDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<Part> dataToImport = mapper.Map<IEnumerable<Part>>(extractedData)
                .Where(p => context.Suppliers.Find(p.SupplierId) != null);

            context.Parts.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        //Task 01
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = InitializeSerializer("Suppliers", typeof(ImportSupplierDTO[]));

            ImportSupplierDTO[] extractedData = null;

            using (StringReader reader = new StringReader(inputXml))
            {
                extractedData = (ImportSupplierDTO[])serializer.Deserialize(reader);
            }

            InitializeMapper();

            IEnumerable<Supplier> dataToImport = mapper.Map<IEnumerable<Supplier>>(extractedData);

            context.Suppliers.AddRange(dataToImport);
            context.SaveChanges();

            return $"Successfully imported {dataToImport.Count()}";
        }

        private static string GenerateXMLOutput<T>(T dtoData, XmlSerializer serializer)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

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
                cnfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was deleted successfully");

            context.Database.EnsureCreated();
            Console.WriteLine("Datavbase was created successfully");
        }
    }
}