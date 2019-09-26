using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Station;
using FBM.WebUI.Helper;
using FBM.WebUI.Models.MotorM;
using FBM.WebUI.Models.StationM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class MotorController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            MotorVM vm = new MotorVM();
            vm.List = ClientServiceProxy.MotorService().Get();
            return View(vm);
        }
        public PartialViewResult _MotorList()
        {
            List<Motor> res = ClientServiceProxy.MotorService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Motor vm = ClientServiceProxy.MotorService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Throwing = ClientServiceProxy.ThrowingService().GetByMotorId(id);
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Motor vm = ClientServiceProxy.MotorService().Get(id);
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
        public ActionResult Edit(Motor entity) {
            try
            {
                ClientServiceProxy.MotorService().Put(entity.Id,entity);
                ShowMessage(MessageType.Success, Resources.MsgUpdate);
            }
            catch (Exception)
            {
                ShowMessage(MessageType.Danger, Resources.ErrorUpdate, 5);
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
        public ActionResult Create(Motor entity)
        {
            try
            {
                entity = ClientServiceProxy.MotorService().Post(entity);
                ShowMessage(MessageType.Success,Resources.MsgAdd);
            }
            catch (Exception)
            {
                ShowMessage(MessageType.Danger, Resources.ErrorAdd, 5);
                ViewBag.StationList = ClientServiceProxy.StationService().Get().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                return View(entity);
            }
            return RedirectToAction("index");
        }
        
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                ClientServiceProxy.MotorService().Delete(id);
                ShowMessage(MessageType.Success, Resources.MsgDelete);
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                ShowMessage(MessageType.Danger, Resources.ErrorDelete,5);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("index");
        }
    }
}