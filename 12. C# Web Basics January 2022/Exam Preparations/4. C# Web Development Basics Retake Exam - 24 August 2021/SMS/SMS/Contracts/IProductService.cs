using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool isCreated, string error) Create(ProductCreateModel model);

        IEnumerable<ProductsListModel> GetProducts();
      
    }
}
