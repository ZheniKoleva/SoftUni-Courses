namespace ProductShop.DTOs.ExportDTOs
{
    using System.Collections.Generic;

    public class SoldProductsInfoDTO
    {
        public int Count => Products.Count;

        public ICollection<ProductInfoDTO> Products { get; set; }
    }
}
