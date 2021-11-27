using System.Collections.Generic;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }        

        public virtual ICollection<Sale> Sales { get; set; }

        // 04. Product Migration
        public string Description  { get; set; }
    }
}
