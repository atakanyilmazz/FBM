using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data;
using System.Threading.Tasks;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class LdrController : BaseController<DbmDbContext, Ldr>
    {
        public override Task<Ldr> Post(Ldr entity)
        {
            if (base.Context.Ldr.Any(x => x.LdrUnitNo == entity.LdrUnitNo))
            {
                throw new Exception("Ldr ünit no daha önce eklenmiş");
            }
            return base.Post(entity);
        }
        public List<Ldr> GetByStationId(Guid id)
        {
            return base.Context.Ldr.Where(x => x.StationId == id).ToList();
        }
    }
}
