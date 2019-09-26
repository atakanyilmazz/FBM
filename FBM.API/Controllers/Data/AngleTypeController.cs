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
    public class AngleTypeController : BaseController<DbmDbContext, AngleType>
    {
        
    }
}
