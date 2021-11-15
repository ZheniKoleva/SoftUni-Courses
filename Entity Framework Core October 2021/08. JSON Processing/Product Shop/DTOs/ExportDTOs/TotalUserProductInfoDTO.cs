namespace ProductShop.DTOs.ExportDTOs
{
    using System.Collections.Generic;

    public class TotalUserProductInfoDTO
    {
        public int UsersCount => Users.Count;

        public ICollection<UserSoldProductsInfoDTO> Users { get; set; }

    }
}
