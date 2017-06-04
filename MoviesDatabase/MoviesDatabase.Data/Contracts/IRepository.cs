using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IQueryable<T> Entities { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
