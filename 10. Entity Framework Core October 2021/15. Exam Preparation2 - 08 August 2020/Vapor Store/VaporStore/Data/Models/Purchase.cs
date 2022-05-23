namespace VaporStore.Data.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    using Data.Models.Enums;

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Range(EntityConstants.Purchase_Type_Min_Value, EntityConstants.Purchase_Type_Max_Value)]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(EntityConstants.Purchase_ProductKey_Regex_Pattern)]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

    }
}
