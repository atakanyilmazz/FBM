using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data.Entity.Train;
using FBM.Data;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class TargetController : BaseController<DbmDbContext, Target>
    {
        public List<Target> GetByTrainingId(Guid id)
        {
            return base.Context.Target.Where(x => x.TrainingId == id).ToList();
        }
        public List<Target> GetByThrowingId(Guid id)
        {
            return base.Context.Target.Where(x => x.ThrowingId == id).ToList();
        }
        public List<Target> GetByCastleId(Guid id)
        {
            return base.Context.Target.Where(x => x.CastleId == id).ToList();
        }
    }
}
