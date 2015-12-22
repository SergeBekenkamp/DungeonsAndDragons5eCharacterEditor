using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Service.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        IEnumerable<T> All();
        void Create(T obj);
        int Delete(T obj);
        T Find(int objId);
        T Find(string objId);
        int Update(T obj);
    }
}
