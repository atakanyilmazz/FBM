using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBM.API.Controllers
{
    public class StartTrainingController : BaseDllController
    {
        public bool Get(Guid id)
        {
            return base.StartTraining(id);
        }
    }
}