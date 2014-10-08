using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly KSEPMDbContext _context;

        protected BaseRepository(KSEPMDbContext context)
        {
            _context = context;
        }

        public virtual List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public virtual T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual List<T> Insert(List<T> objList)
        {
            _context.Set<T>().AddRange(objList);
            _context.SaveChanges();
            return objList;
        }

        public virtual int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);

            return _context.SaveChanges();
        }
    }
}
