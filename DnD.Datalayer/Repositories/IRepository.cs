using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Datalayer.Repositories
{
    public interface IRepository<TObject>
    {
        IQueryable<TObject> All();
        TObject Create(TObject obj);
        int Delete(TObject obj);
        int Delete(Expression<Func<TObject, bool>> predicate);
        IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate);

        IQueryable<TObject> Filter<TKey>(
            Expression<Func<TObject, bool>> filter,
            out int total,
            int index = 0,
            int size = 50);

        TObject Find(int id);
        TObject Find(params object[] keys);
        TObject Find(Expression<Func<TObject, bool>> predicate);
        void Ignore(TObject t);
        int Update(TObject obj);
        void Save();
    }
}
