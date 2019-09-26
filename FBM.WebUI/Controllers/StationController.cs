using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.WebUI.Models.StationM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class StationController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            StationVm vm = new StationVm();
            vm.List = ClientServiceProxy.StationService().Get();
            return View(vm);
        }
        public PartialViewResult _StationList()
        {
            List<Station> res = ClientServiceProxy.StationService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Station vm = ClientServiceProxy.StationService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Castle = ClientServiceProxy.CastleService().GetByStationId(id);
            vm.Ldr = ClientServiceProxy.LdrService().GetByStationId(id);
            vm.Motor = ClientServiceProxy.MotorService().GetByStationId(id);
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Station vm = ClientServiceProxy.StationService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Station entity) {
            try
            {
                ClientServiceProxy.StationService().Put(entity.Id,entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                return View(entity);
            }
            return RedirectToAction("Details", new { id = entity.Id });
        }

        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Station entity)
        {
            try
            {
                entity = ClientServiceProxy.StationService().Post(entity);
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
                ClientServiceProxy.StationService().Delete(id);
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