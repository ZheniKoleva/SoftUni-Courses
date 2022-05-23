using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data.Common
{
    public class Repository: IRepository
    {
        private readonly FootballManagerDbContext dbContext;

        public Repository(FootballManagerDbContext context)
        {
            dbContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
