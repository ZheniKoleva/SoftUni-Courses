using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDTO
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
