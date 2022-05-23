namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;    

    using Common;

    public class Theatre
    {
        public Theatre()
        {            
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Theatre_Name_Max_Lenght)]
        public string Name { get; set; }

        [Range(EntityConstants.Theatre_NumberOfHalls_Min_Value, EntityConstants.Theatre_NumberOfHalls_Max_Value)] 
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(EntityConstants.Theatre_Director_Max_Lenght)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
