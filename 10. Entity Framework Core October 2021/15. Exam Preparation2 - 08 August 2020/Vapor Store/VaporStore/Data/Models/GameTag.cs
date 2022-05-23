namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;    

    public class GameTag
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
