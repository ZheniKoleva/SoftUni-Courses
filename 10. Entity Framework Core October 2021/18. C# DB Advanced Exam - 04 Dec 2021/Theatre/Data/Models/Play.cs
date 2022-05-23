namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common;
    using Enums;

    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Play_Title_Max_Lenght)]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        [Range(typeof(float), EntityConstants.Play_Rating_Min_Value, EntityConstants.Play_Rating_Max_Value)]
        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(EntityConstants.Play_Description_Max_Lenght)]
        public string Description { get; set; }

        [Required]
        [MaxLength(EntityConstants.Play_Screewriter_Max_Lenght)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }  

}
