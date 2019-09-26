using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FBM.Data
{
    public interface IBaseRep<T> where T : class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> Get();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Post(T entity);
        List<T> AddRange(List<T> entitys);
        T Get(Guid id);
        void Delete(T entity);
        void Delete(Guid id);
        void Put(T entity);
        int Save();
        Task<int> SaveAsync();
        void Put(Guid id, T entity);
    }
}
