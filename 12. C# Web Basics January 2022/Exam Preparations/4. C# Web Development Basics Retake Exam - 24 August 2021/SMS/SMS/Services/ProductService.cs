using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public ProductService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isCreated, string error) Create(ProductCreateModel model)
        {
            bool isCreated = false;
            string errorString = string.Empty;

            var (isValid, error) = validationService.ValidateModel(model);

            if(!isValid)
            {
                return (isValid, error);
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception e)
            {
                errorString = "Product was not created";
            }


            return (isCreated, errorString);
        }

        public IEnumerable<ProductsListModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(x => new ProductsListModel()
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2"),
                })
                .ToList();
        }
    }
}
