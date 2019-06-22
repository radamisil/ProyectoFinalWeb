namespace AdondeVamos.Model.UnitOfWork
{
    public delegate T TransactionalAction<T>();
    public delegate void TransactionalAction();
    public interface IUnitOfWork
    {
        int SaveChanges();

        T PerformTransactional<T>(TransactionalAction<T> Action, out int SaveResult);
        void PerformTransactional(TransactionalAction Action, out int SaveResult);
    }
}
