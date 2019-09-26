using FBM.Dll.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBM.API.Controllers
{
    public class LdrDeviceCountController : BaseDllController
    {
        public int Get()
        {
            return base.LdrCount();
        }
    }
}
