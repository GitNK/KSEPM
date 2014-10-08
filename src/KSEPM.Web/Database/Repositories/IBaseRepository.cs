using System.Collections.Generic;
using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    interface IBaseRepository<T> where T : EntityBase
    {
        List<T> Get();
        T Get(int id);
        T Update(T obj);
        T Insert(T obj);
        List<T> Insert(List<T> objList);
        int Delete(T obj);
    }
}
