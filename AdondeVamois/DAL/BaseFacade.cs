using AutoMapper;
using AdondeVamos.Model.UnitOfWork;

namespace AdondeVamos.DAL
{
    public class BaseFacade
    {
        #region Fields
        protected IMapper mapper;
        protected IUnitOfWork UnitOfWork;
        #endregion

        #region Constructor
        public BaseFacade(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;           
            this.mapper = mapper;
        }
        #endregion

        #region Protected members
        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        protected T PerformTransactional<T>(TransactionalAction<T> Action, out int SaveResult)
        {
            return UnitOfWork.PerformTransactional<T>(Action, out SaveResult);
        }

        protected void PerformTransactional(TransactionalAction Action, out int SaveResult)
        {
            UnitOfWork.PerformTransactional(Action, out SaveResult);
        }
        #endregion
    }
}