namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    using VaporStore.Common;

    public class ImportCardDTO
     {
        [Required]
        [RegularExpression(EntityConstants.Card_Number_Regex_Pattern)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(EntityConstants.Card_Cvc_Regex_Pattern)]
        public string CVC { get; set; }

        [Required]       
        public string Type { get; set; }

    }
}
