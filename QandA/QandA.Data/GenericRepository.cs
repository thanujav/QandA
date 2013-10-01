using QandA.Core.Domain;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        SqlContext _context;
        DbSet<T> _dbset;

        public GenericRepository(SqlContext context)
        {
            _context = context;
            _dbset = context.Set<T>();

        }
        public T SingleOrDefault(Func<T, bool> predicate)
        {
            return _dbset.Where(predicate).SingleOrDefault();
        }

        public T Add(T t)
        {
            return _dbset.Add(t);
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public List<T> GetPaged(int pageSize, int pageNum)
        {
            return _dbset.OrderBy("Id").Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        public int Count()
        {
            return _dbset.Count();
        }
    }
}
