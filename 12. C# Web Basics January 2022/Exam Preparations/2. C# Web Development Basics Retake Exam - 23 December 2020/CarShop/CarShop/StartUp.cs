namespace CarShop
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using CarShop.Contracts;
    using CarShop.Data;
    using CarShop.Data.Common;
    using CarShop.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            
            server.ServiceCollection
                .Add<ApplicationDbContext>()
                .Add<IRepository, Repository>()
                .Add<IValidationService, ValidationService>()
                .Add<IUserService, UserService>()
                .Add<ICarService, CarService>()
                .Add<IIssueService, IssueService>();
           
            await server.Start();
        }
    }
}