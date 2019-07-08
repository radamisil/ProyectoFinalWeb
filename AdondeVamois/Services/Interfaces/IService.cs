using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdondeVamos.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        T GetById(long id);
        T Add(T Entity);
        T DeleteById(long id);
    }
}