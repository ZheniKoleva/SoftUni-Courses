namespace P01_StudentSystem
{
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext studentSystem = new StudentSystemContext();

            studentSystem.Database.EnsureDeleted();            
            //studentSystem.Database.EnsureCreated();
            studentSystem.Database.Migrate();          
            
        }
    }
}
