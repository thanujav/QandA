using QandA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        T SingleOrDefault(Func<T,bool> predicate);

        T Add(T t);

        List<T> GetAll();

        List<T> GetPaged(int pageSize, int pageNum);
    }
}
