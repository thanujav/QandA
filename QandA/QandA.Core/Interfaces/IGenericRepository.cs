using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        T SingleOrDefault(int p);
    }
}
