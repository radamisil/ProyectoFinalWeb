using AdondeVamos.DAL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AdondeVamos.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region fields
        private IDbContext _context;
        protected IDbSet<T> DbSet;

        #region Constructor
        public Repository(IDbContext dbContext)
        {
            _context = dbContext;
            DbSet = dbContext.Set<T>();
        }
        #endregion

        public T Insert(T entity)
        {
            return DbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return DbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        #endregion
    }
}