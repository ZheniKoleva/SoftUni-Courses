namespace Git
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using Git.Contarcts;
    using Git.Data;
    using Git.Data.Common;
    using Git.Services;
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
                .Add<IRepository, DbRepository>()
                .Add<IValidationService, ValidationService>()
                .Add<IUserService, UserService>()
                .Add<IRepositoryService, RepositoryService>()
                .Add<ICommitService, CommitService>();
            
            await server.Start();
        }
    }
}
