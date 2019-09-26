using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Players;
using FBM.Data.Entity.Train;
using FBM.WebUI.Models.TrainingM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class TrainingController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            TrainingVM vm = new TrainingVM();
            vm.List = ClientServiceProxy.TrainingService().Get();
            return View(vm);
        }
        public PartialViewResult _TrainingList()
        {
            List<Training> res = ClientServiceProxy.TrainingService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Training vm = ClientServiceProxy.TrainingService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.Target = ClientServiceProxy.TargetService().GetByTrainingId(id);
            vm.PlayerTraining = ClientServiceProxy.PlayerTrainingService().GetPlayerTrainingDTOTrainingId(id).Select(x => new PlayerTraining()
            {
                Id = x.Id,
                Player = new Player() { Name = x.PlayerName },
                Training = new Training() { Name = x.TrainingName },
                TrainingDate = x.TrainingDate,
                PlayerId = x.PlayerId,
                SpeedScore = x.SpeedScore,
                TimeScore = x.TimeScore,
                TrainingId = x.TrainingId
            }).ToList();
            
            return View(vm);
        }

        public ActionResult Edit(Guid id)
        {
            Training vm = ClientServiceProxy.TrainingService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Training entity) {
            try
            {
                ClientServiceProxy.TrainingService().Put(entity.Id,entity);
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
        public ActionResult Create(Training entity)
        {
            try
            {
                entity = ClientServiceProxy.TrainingService().Post(entity);
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
                ClientServiceProxy.TrainingService().Delete(id);
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