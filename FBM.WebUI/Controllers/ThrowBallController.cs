using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.WebUI.Models.CastleM;
using FBM.WebUI.Models.ThrowingM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class ThrowBallController : BaseController
    {
        public ActionResult Index()
        {
            ThrowBallVM vm = new ThrowBallVM();
            vm.ThrowBallAltitude = ClientServiceProxy.ThrowBallAltitudeService().Get();
            vm.ThrowBallAngle = ClientServiceProxy.ThrowBallAngleService().Get();
            return View(vm);
        }
        public PartialViewResult _ThrowBallAltitudeList()
        {
            List<ThrowBallAltitude> res = ClientServiceProxy.ThrowBallAltitudeService().Get();
            return PartialView(res);
        }
        public PartialViewResult _ThrowBallAngleList()
        {
            List<ThrowBallAngle> res = ClientServiceProxy.ThrowBallAngleService().Get();
            return PartialView(res);
        }
        public ActionResult ThrowBallAltitudeDetails(Guid id)
        {
            ThrowBallAltitude vm = ClientServiceProxy.ThrowBallAltitudeService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Throwing = ClientServiceProxy.ThrowingService().GetByThrowBallAltitudeId(id);
            return View(vm);
        }
        public ActionResult ThrowBallAngleDetails(Guid id)
        {
            ThrowBallAngle vm = ClientServiceProxy.ThrowBallAngleService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Throwing = ClientServiceProxy.ThrowingService().GetByThrowBallAngleId(id);
            return View(vm);
        }
        public ActionResult ThrowBallAltitudeEdit(Guid id)
        {
            ThrowBallAltitude vm = ClientServiceProxy.ThrowBallAltitudeService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.AltitudeTypeList = ClientServiceProxy.AltitudeTypeService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }
        public ActionResult ThrowBallAngleEdit(Guid id)
        {
            ThrowBallAngle vm = ClientServiceProxy.ThrowBallAngleService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.AngleTypeList = ClientServiceProxy.AngleTypeService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThrowBallAltitudeEdit(ThrowBallAltitude entity)
        {
            try
            {
                ClientServiceProxy.ThrowBallAltitudeService().Put(entity.Id, entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.AltitudeTypeList = ClientServiceProxy.AltitudeTypeService().Get().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                return View(entity);
            }
            return RedirectToAction("ThrowBallAltitudeDetails", new { id = entity.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThrowBallAngleEdit(ThrowBallAngle entity)
        {
            try
            {
                ClientServiceProxy.ThrowBallAngleService().Put(entity.Id, entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.AngleTypeList = ClientServiceProxy.AngleTypeService().Get().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                return View(entity);
            }
            return RedirectToAction("ThrowBallAngleDetails", new { id = entity.Id });
        }
        public ActionResult ThrowBallAltitudeCreate()
        {
            ViewBag.AltitudeTypeList = ClientServiceProxy.AltitudeTypeService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        public ActionResult ThrowBallAngleCreate()
        {
            ViewBag.AngleTypeList = ClientServiceProxy.AngleTypeService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThrowBallAltitudeCreate(ThrowBallAltitude entity)
        {
            try
            {
                entity = ClientServiceProxy.ThrowBallAltitudeService().Post(entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return View(entity);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThrowBallAngleCreate(ThrowBallAngle entity)
        {
            try
            {
                entity = ClientServiceProxy.ThrowBallAngleService().Post(entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return View(entity);
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult ThrowBallAltitudeDelete(Guid id)
        {
            try
            {
                ClientServiceProxy.ThrowBallAltitudeService().Delete(id);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return Json(false);
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult ThrowBallAngleDelete(Guid id)
        {
            try
            {
                ClientServiceProxy.ThrowBallAngleService().Delete(id);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return Json(false);
            }
            return RedirectToAction("index");
        }

    }
}