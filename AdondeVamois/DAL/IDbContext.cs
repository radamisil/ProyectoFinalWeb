using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AdondeVamos.DAL
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        Database Database();
        int SaveChanges();
        bool CanUpdate();
    }
}