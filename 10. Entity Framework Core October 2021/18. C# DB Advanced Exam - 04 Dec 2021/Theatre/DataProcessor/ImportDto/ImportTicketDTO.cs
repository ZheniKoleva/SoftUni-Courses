namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class ImportTicketDTO
    {
        [Required]
        [Range(typeof(decimal), EntityConstants.Ticket_Price_Min_Value, EntityConstants.Ticket_Price_Max_Value)]
        public decimal Price { get; set; }

        [Required]
        [Range(EntityConstants.Ticket_RowNumber_Min_Value, EntityConstants.Ticket_RowNumber_Max_Value)]
        public sbyte RowNumber { get; set; }
           
        [Required]
        public int PlayId { get; set; }
    }

}