using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data.Entity.Throw;
using FBM.Data;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class ThrowingController : BaseController<DbmDbContext, Throwing>
    {
        public List<Throwing> GetByMotorId(Guid id)
        {
            return base.Context.Throwing.Where(x => x.MotorId == id).ToList();
        }

        public List<Throwing> GetByThrowBallAngleId(Guid id)
        {
            return base.Context.Throwing.Where(x => x.ThrowBallAngleId == id).ToList();
        }
        public List<Throwing> GetByThrowBallAltitudeId(Guid id)
        {
            return base.Context.Throwing.Where(x => x.ThrowBallAltitudeId == id).ToList();
        }
    }
}
