using FBM.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MixOn(int val) {
            return Json(ClientServiceProxy.DllService().MixOn(val).ToString(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MixOff(int val)
        {
            return Json(ClientServiceProxy.DllService().MixOff(val).ToString(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ReleaseBall(int val)
        {
            return Json(ClientServiceProxy.DllService().ReleaseBall(val).ToString(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetLdrCount()
        {
            return Json(ClientServiceProxy.DllService().LdrCount().ToString(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetDeviceCount()
        {
            return Json(ClientServiceProxy.DllService().DeviceCount().ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}