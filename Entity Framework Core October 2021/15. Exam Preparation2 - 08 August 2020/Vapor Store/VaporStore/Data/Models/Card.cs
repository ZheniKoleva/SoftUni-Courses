namespace VaporStore.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    using Data.Models.Enums;

    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(EntityConstants.Card_Number_Regex_Pattern)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(EntityConstants.Card_Cvc_Regex_Pattern)]
        public string Cvc { get; set; }

        [Range(EntityConstants.Card_Type_Min_Value, EntityConstants.Card_Type_Max_Value)]
        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
