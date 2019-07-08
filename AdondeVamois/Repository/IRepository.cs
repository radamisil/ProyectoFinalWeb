using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdondeVamos.Repository
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        T Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
    }
}