namespace VaporStore.DataProcessor.Dto.Import
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using VaporStore.Common;

    public class ImportGameDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), EntityConstants.Game_Price_Min_Value, EntityConstants.Game_Price_Max_Value)]
        public decimal Price { get; set; }
        
        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string  Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(EntityConstants.Game_GameTags_Min_Length)]
        public string[] Tags { get; set; }

    }

    
    //•	Name – text(required)
    //•	Price – decimal (non-negative, minimum value: 0) (required)
    //•	ReleaseDate – Date(required)
    //•	DeveloperId – integer, foreign key(required)
    //•	Developer – the game’s developer(required)
    //•	GenreId – integer, foreign key(required)
    //•	Genre – the game’s genre(required)
    //•	Purchases - collection of type Purchase
    //•	GameTags - collection of type GameTag.Each game must have at least one tag.
}
