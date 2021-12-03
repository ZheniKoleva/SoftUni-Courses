namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using VaporStore.Common;

    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityConstants.User_Username_Max_Length)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(EntityConstants.User_FullName_Regex_Pattern)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(EntityConstants.User_Age_Min_Value, EntityConstants.User_Age_Max_Value)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }
}
