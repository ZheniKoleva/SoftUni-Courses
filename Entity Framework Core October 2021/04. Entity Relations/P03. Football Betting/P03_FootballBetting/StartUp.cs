namespace P03_FootballBetting
{
    using Microsoft.EntityFrameworkCore;
    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext db = new FootballBettingContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            db.Database.Migrate();
        }
    }
}
