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
    public class MotorController : BaseController<DbmDbContext, Motor>
    {
        public override Task<Motor> Post(Motor entity)
        {
            if (base.Context.Motor.Any(x => x.StationNo == entity.StationNo))
            {
                throw new Exception("Bu motor no kullanılmakta var olan veriyi güncelleyiniz");
            }
            else if (base.Context.Motor.Any(x => x.Floor == entity.Floor && x.WallPosition == entity.WallPosition && x.StationId == entity.StationId))
            {
                throw new Exception("Aynı konuma 2 tane motor eklenemez");
            }
            return base.Post(entity);
        }
        public List<Motor> GetByStationId(Guid id)
        {
            return base.Context.Motor.Where(x => x.StationId == id).ToList();
        }
    }
}
