namespace ProductShop.DTOs.ExportDTOs
{
    public class UserSoldProductsInfoDTO 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public SoldProductsInfoDTO SoldProducts { get; set; }

    }
}
