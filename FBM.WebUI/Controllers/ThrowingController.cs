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
    public class ThrowingController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            ThrowingVM vm = new ThrowingVM();
            vm.List = ClientServiceProxy.ThrowingService().Get();
            return View(vm);
        }
        public PartialViewResult _ThrowingList()
        {
            List<Throwing> res = ClientServiceProxy.ThrowingService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Throwing vm = ClientServiceProxy.ThrowingService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Target = ClientServiceProxy.TargetService().GetByCastleId(id);
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Throwing vm = ClientServiceProxy.ThrowingService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            FillViewBag();
            return View(vm);
        }

        private void FillViewBag()
        {
            ViewBag.MotorList = ClientServiceProxy.MotorService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.ThrowBallAngleList = ClientServiceProxy.ThrowBallAngleService().Get().Select(x => new SelectListItem()
            {
                Text = x.AngleType.Name,
                Value = x.Id.ToString()
            });
            ViewBag.ThrowBallAltitudeList = ClientServiceProxy.ThrowBallAltitudeService().Get().Select(x => new SelectListItem()
            {
                Text = x.AltitudeType.Name,
                Value = x.Id.ToString()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Throwing entity) {
            try
            {
                ClientServiceProxy.ThrowingService().Put(entity.Id,entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                FillViewBag();
                return View(entity);
            }
            return RedirectToAction("Details", new { id = entity.Id });
        }

        public ActionResult Create() {
            FillViewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Throwing entity)
        {
            try
            {
                entity = ClientServiceProxy.ThrowingService().Post(entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return View(entity);
            }
            return RedirectToAction("index");
        }
        
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                ClientServiceProxy.ThrowingService().Delete(id);
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