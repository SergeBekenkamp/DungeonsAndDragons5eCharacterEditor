using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Datalayer.Repositories;
using DnD.Service.Interfaces;

namespace DnD.Service.Services
{
 

    public class CrudService<T> : ICrudService<T>, IDisposable where T : class
    {
        private bool disposed;
        protected IRepository<T> repo;

        public CrudService(IRepository<T> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<T> All()
        {
            return repo.All();
        }

      
        public virtual void Create(T obj)
        {
            repo.Create(obj);
        }

        public virtual int Delete(T obj)
        {
            return repo.Delete(obj);
        }

       public T Find(int objId)
        {
            return repo.Find(objId);
        }

        public T Find(string objId)
        {
            return repo.Find(objId);
        }

        public virtual int Update(T obj)
        {
            repo.Update(obj);
            repo.Save();
            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    repo = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~CrudService()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}
