using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface ICartService
    {
        IEnumerable<CartProductsListModel> AddToCart(string productId, string userId);

        void BuyProducts(string userId);

        IEnumerable<CartProductsListModel> GetProducts(string userId);
    }
}
