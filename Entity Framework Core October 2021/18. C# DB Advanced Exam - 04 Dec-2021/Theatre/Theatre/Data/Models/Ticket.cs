namespace Theatre.Data.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Ticket
    {        
        [Key]
        public int Id { get; set; }

        [Range(typeof(decimal), EntityConstants.Ticket_Price_Min_Value, EntityConstants.Ticket_Price_Max_Value)]
        public decimal Price { get; set; }

        [Range(EntityConstants.Ticket_RowNumber_Min_Value, EntityConstants.Ticket_RowNumber_Max_Value)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }


        [ForeignKey(nameof(Theatre))]
        public int TheatreId { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
}
