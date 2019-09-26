using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data.Entity.Station;
using FBM.Data;
using System.Threading.Tasks;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class CastleLdrPointController : BaseController<DbmDbContext, CastleLdrPoint>
    {
        public override Task<CastleLdrPoint> Post(CastleLdrPoint entity)
        {
            if (base.Context.CastleLdrPoint.Any(x => x.CastleId == entity.CastleId && x.Axis == entity.Axis))
            {
                throw new Exception("Bu kale aynı axis ile daha önce eklenmiş");
            }
            return base.Post(entity);
        }
        public List<CastleLdrPoint> GetByCastleId(Guid id)
        {
            return base.Context.CastleLdrPoint.Where(x => x.CastleId == id).ToList();
        }
    }
}
