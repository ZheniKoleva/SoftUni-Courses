using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;       

        public CartService(IRepository _repo)
        {
            repo = _repo;           
        }

        public IEnumerable<CartProductsListModel> AddToCart(string productId, string userId)
        { 
            User user = repo.All<User>()
                .Where(x => x.Id == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.Products)
                .FirstOrDefault();

            Product product = repo.All<Product>()
                .FirstOrDefault(x => x.Id == productId);

            user.Cart.Products.Add(product);            

            try
            {
                repo.SaveChanges();
                
            }
            catch (Exception)
            {                               
            }

            IEnumerable<CartProductsListModel> products = user.Cart.Products
                .Select(x => new CartProductsListModel()
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2")
                })
                .ToList();

            return products;
        }

        public void BuyProducts(string userId)
        {
            User user = repo.All<User>()
               .Where(x => x.Id == userId)
               .Include(x => x.Cart)
               .ThenInclude(x => x.Products)
               .FirstOrDefault();

            user.Cart.Products.Clear();

            repo.SaveChanges();
        }

        public IEnumerable<CartProductsListModel> GetProducts(string userId)
        {
            User user = repo.All<User>()
             .Where(x => x.Id == userId)
             .Include(x => x.Cart)
             .ThenInclude(x => x.Products)
             .FirstOrDefault();

            return user.Cart.Products
                .Select(x => new CartProductsListModel()
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2")
                })
                .ToList();
        }
    }
}
