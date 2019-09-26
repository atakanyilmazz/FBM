using FBM.Core.Resource;
using FBM.Data.API;
using FBM.Data.Entity.Players;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Train;
using FBM.WebUI.Models.CastleM;
using FBM.WebUI.Models.PlayerM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class PlayerController : BaseController
    {
        // GET: Station
        public ActionResult Index()
        {
            PlayerVM vm = new PlayerVM();
            vm.List = ClientServiceProxy.PlayerService().Get();
            return View(vm);
        }
        public PartialViewResult _PlayerList()
        {
            List<Player> res = ClientServiceProxy.PlayerService().Get();
            return PartialView(res);
        }
        public ActionResult Details(Guid id)
        {
            Player vm = ClientServiceProxy.PlayerService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            vm.PlayerTraining = ClientServiceProxy.PlayerTrainingService().GetPlayerTrainingDTOByPlayerId(id).Select(x=>new PlayerTraining() {
                Id =x.Id,
                Player = new Player() { Name = x.PlayerName },
                Training = new Training() {  Name = x.TrainingName},
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
            Player vm = ClientServiceProxy.PlayerService().Get(id);
            if (vm == null)
            {
                return RedirectToAction("index");
            }
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player entity) {
            try
            {
                ClientServiceProxy.PlayerService().Put(entity.Id,entity);
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
        public ActionResult Create(Player entity)
        {
            try
            {
                entity = ClientServiceProxy.PlayerService().Post(entity);
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
                ClientServiceProxy.PlayerService().Delete(id);
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