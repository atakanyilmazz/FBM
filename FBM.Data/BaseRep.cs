using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FBM.Data.Entity;

namespace FBM.Data
{
    public abstract class BaseRep<C, T> : IBaseRep<T> where T : BaseEntity where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual T Post(T entity)
        {
            entity.Id = Guid.NewGuid();
            return _entities.Set<T>().Add(entity);
        }
        public virtual void Delete(T entity)
        {
            if (entity.Id != null)
            {
                if (entity.Id != Guid.Empty)
                {
                    T temp = this.Get(entity.Id);
                    _entities.Set<T>().Remove(temp);
                }
            }
        }
        public virtual void Put(T entity)
        {
            if (entity.Id != null)
            {
                if (entity.Id != Guid.Empty)
                {
                    T temp = this.Get(entity.Id);
                    _entities.Entry(temp).CurrentValues.SetValues(entity);
                }
            }
        }

        public virtual int Save()
        {
            return _entities.SaveChanges();
        }
        public virtual async Task<int> SaveAsync()
        {
            return await _entities.SaveChangesAsync();
        }

        public T Get(Guid id)
        {
            return _entities.Set<T>().Find(id);
        }

        public List<T> AddRange(List<T> entitys)
        {
            foreach (T entity in entitys)
            {
                this.Post(entity);
            }
            return entitys;
        }

        public IEnumerable<T> Get()
        {
            IEnumerable<T> query = _entities.Set<T>();
            return query;
        }

        public void Delete(Guid id)
        {
            T temp = this.Get(id);
            _entities.Set<T>().Remove(temp);
        }

        public void Put(Guid id, T entity)
        {
            T temp = this.Get(id);
            _entities.Entry(temp).CurrentValues.SetValues(entity);
        }

    }
}
