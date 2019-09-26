using FBM.Data;
using FBM.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FBM.API.Controllers
{
    public abstract class BaseController<C, T> : ApiController where C : DbContext, new() where T : BaseEntity
    {
        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }
        // GET api/values
        public async virtual Task<List<T>> Get()
        {
            return await _entities.Set<T>().ToListAsync();
        }

        // GET api/values/5
        public async virtual Task<T> Get(Guid id)
        {
            return await _entities.Set<T>().FindAsync(id);
        }

        // POST api/values
        public async virtual Task<T> Post([FromBody]T entity)
        {
            entity.Id = Guid.NewGuid();
            entity = _entities.Set<T>().Add(entity);
            await _entities.SaveChangesAsync();
            return entity;
        }

        // PUT api/values/5
        public async virtual Task<T> Put(Guid id, [FromBody]T entity)
        {
            T temp = await this.Get(id);
            _entities.Entry(temp).CurrentValues.SetValues(entity);
            await _entities.SaveChangesAsync();
            return await this.Get(id);
        }

        // DELETE api/values/5
        public async virtual Task<HttpResponseMessage> Delete(Guid id)
        {
            T temp = await this.Get(id);
            _entities.Set<T>().Remove(temp);
            await _entities.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
