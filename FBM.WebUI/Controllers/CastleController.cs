using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.WebUI.Models.CastleM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class CastleController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            CastleVM vm = new CastleVM();
            vm.List = ClientServiceProxy.CastleService().Get();
            return View(vm);
        }
        public PartialViewResult _CastleList()
        {
            List<Castle> res = ClientServiceProxy.CastleService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Castle vm = ClientServiceProxy.CastleService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.CastleLdrPoint = ClientServiceProxy.CastleLdrPointService().GetByCastleId(id);
            vm.Target = ClientServiceProxy.TargetService().GetByCastleId(id);
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Castle vm = ClientServiceProxy.CastleService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Castle entity) {
            try
            {
                ClientServiceProxy.CastleService().Put(entity.Id,entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                return View(entity);
            }
            return RedirectToAction("Details", new { id = entity.Id });
        }

        public ActionResult Create() {
            ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Castle entity)
        {
            try
            {
                entity = ClientServiceProxy.CastleService().Post(entity);
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
                ClientServiceProxy.CastleService().Delete(id);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("index");
        }
    }
}