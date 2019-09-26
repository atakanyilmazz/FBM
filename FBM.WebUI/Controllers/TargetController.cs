using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using FBM.WebUI.Models.CastleM;
using FBM.WebUI.Models.TargetM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class TargetController : BaseController
    {
        public ActionResult Index()
        {
            TargetVM vm = new TargetVM();
            vm.List = ClientServiceProxy.TargetService().Get();
            return View(vm);
        }
        public PartialViewResult _TargetList()
        {
            List<Target> res = ClientServiceProxy.TargetService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Target vm = ClientServiceProxy.TargetService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            //vm.TrainLog = ClientServiceProxy.TrainLogService().GetByTargetId(id);
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Target vm = ClientServiceProxy.TargetService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            FillViewBag();
            return View(vm);
        }

        private void FillViewBag()
        {
            ViewBag.TrainingList = ClientServiceProxy.TrainingService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.ThrowingList = ClientServiceProxy.ThrowingService().Get().Select(x => new SelectListItem()
            {
                Text = x.Motor + " " + x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.CastleList = ClientServiceProxy.CastleService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Target entity) {
            try
            {
                ClientServiceProxy.TargetService().Put(entity.Id,entity);
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
        public ActionResult Create(Target entity)
        {
            try
            {
                entity = ClientServiceProxy.TargetService().Post(entity);
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
                ClientServiceProxy.TargetService().Delete(id);
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