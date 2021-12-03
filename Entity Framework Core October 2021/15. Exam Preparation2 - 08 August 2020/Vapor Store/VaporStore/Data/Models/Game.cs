namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using VaporStore.Common;

    public class Game
    {
        public Game()
        {
            Purchases = new HashSet<Purchase>();
            GameTags = new HashSet<GameTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), EntityConstants.Game_Price_Min_Value, EntityConstants.Game_Price_Max_Value)]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        [ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        [MinLength(EntityConstants.Game_GameTags_Min_Length)]
        public virtual ICollection<GameTag> GameTags { get; set; }

    }

}
