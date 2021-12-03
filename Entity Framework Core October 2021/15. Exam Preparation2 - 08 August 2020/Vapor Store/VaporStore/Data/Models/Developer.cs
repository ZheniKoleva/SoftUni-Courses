﻿namespace VaporStore.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }

    }
}
