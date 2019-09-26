using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data;
using FBM.Data.DTO;
using FBM.Data.Enum;
using System.Threading.Tasks;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class CastleController : BaseController<DbmDbContext, Castle>
    {
        public override Task<Castle> Post(Castle entity)
        {
            if (base.Context.Castle.Any(x => x.WallPosition == entity.WallPosition && x.CastlePosition == entity.CastlePosition && x.CastleFloor == entity.CastleFloor && x.StationId == entity.StationId))
            {
                throw new Exception("Bu kale ekli");
            }

            List<int> castleNoList = base.Context.Castle.OrderBy(x => x.CastleNo).Select(x => x.CastleNo).ToList();
            int castleNo = 0;
            for (int i = 0; i < castleNoList.Count; i++)
            {
                if (i != castleNoList[i])
                {
                    castleNo = i;
                    break;
                }
            }
            if (castleNoList.Count > 0 && castleNo == 0)
            {
                castleNo = castleNoList.Count;
            }
            entity.CastleNo = castleNo;

            return base.Post(entity);
        }

        public List<Castle> GetByStationId(Guid id)
        {
            return base.Context.Castle.Where(x => x.StationId == id).ToList();
        }

    }
}
