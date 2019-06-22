using System;
using System.Diagnostics.CodeAnalysis;
using System.Data.Entity.Validation;
using AdondeVamos.DAL;

namespace AdondeVamos.Model.UnitOfWork
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        public UnitOfWork(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public T PerformTransactional<T>(TransactionalAction<T> Action, out int SaveResult)
        {
            using (var dbContextTransaction = _dbContext.Database().BeginTransaction())
            {
                try
                {
                    //do some transactional action
                    var actionResult = Action();
                    SaveResult = _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return actionResult;
                }
                catch (DbEntityValidationException e)
                {
                    string erroresValidacion = "";
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        erroresValidacion = erroresValidacion + String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State) + "\r\n";
                        foreach (var ve in eve.ValidationErrors)
                        {
                            erroresValidacion = erroresValidacion + String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage) + "\r\n";
                        }
                    }
                    throw new Exception(erroresValidacion);
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public void PerformTransactional(TransactionalAction Action, out int SaveResult)
        {
            using (var dbContextTransaction = _dbContext.Database().BeginTransaction())
            {
                try
                {
                    //do some transactional action
                    Action();
                    SaveResult = _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
