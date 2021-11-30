namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using Common;
    using Enums;

    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstant.Book_Name_Max_Length)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Range((double)EntityConstant.Book_Price_Min_Value, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Range(EntityConstant.Book_Pages_Min_Value, EntityConstant.Book_Pages_Max_Value)]
        public int Pages { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }

    }
}
