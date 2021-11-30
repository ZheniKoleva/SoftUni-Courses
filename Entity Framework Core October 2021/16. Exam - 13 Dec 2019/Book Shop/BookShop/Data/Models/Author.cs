namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstant.Author_FirstName_Max_Length)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(EntityConstant.Author_LastName_Max_Length)]
        public string LastName { get; set; }        

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }

    }
}

