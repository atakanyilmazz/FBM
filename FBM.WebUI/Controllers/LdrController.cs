using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.WebUI.Models.LdrM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class LdrController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            LdrVm vm = new LdrVm();
            vm.List = ClientServiceProxy.LdrService().Get();
            return View(vm);
        }
        public ActionResult Details(Guid id)
        {
            Ldr vm = ClientServiceProxy.LdrService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            return View(vm);
        }

        public PartialViewResult _LdrList()
        {
            List<Ldr> res = ClientServiceProxy.LdrService().Get();
            return PartialView(res);
        }

        public ActionResult Edit(Guid id)
        {
            Ldr vm = ClientServiceProxy.LdrService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ldr entity) {
            try
            {
                ClientServiceProxy.LdrService().Put(entity.Id,entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
                return View(entity);
            }
            return RedirectToAction("Details", new { id = entity.Id });
        }

        public ActionResult Create() {
            ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ldr entity)
        {
            try
            {
                entity = ClientServiceProxy.LdrService().Post(entity);
            }
            catch (Exception)
            {
                ShowMessage(Helper.MessageType.Warning, Resources.ErrorActionUnsuccess, 5);
                ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
                return View(entity);
            }
            return RedirectToAction("index");
        }
        
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                ClientServiceProxy.LdrService().Delete(id);
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