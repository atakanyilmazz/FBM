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
    public class TrainLogController : BaseController<DbmDbContext, TrainLog>
    {
        public List<TrainLog> GetByPlayerTrainingId(Guid id)
        {
            return base.Context.TrainLog.Where(x => x.PlayerTrainingId == id).ToList();
        }
        public List<TrainLog> GetByTargetId(Guid id)
        {
            return base.Context.TrainLog.Where(x => x.TargetId == id).ToList();
        }
    }
}
