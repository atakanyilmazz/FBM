using FBM.Data;
using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FBM.API.Controllers.Data
{
    public class DeviceInfoController : BaseController<DbmDbContext, DeviceInfo>
    {
        public override Task<List<DeviceInfo>> Get()
        {
            BaseDllController bdc = new BaseDllController();

            bdc.DeviceInfo();

            return base.Get();
        }

    }
}