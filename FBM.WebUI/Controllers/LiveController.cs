using FBM.Data.API;
using FBM.Data.Entity;
using FBM.Data.Entity.Players;
using FBM.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using FBM.Data.Entity.Train;
using FBM.Data.DTO;
using FBM.Core.Resource;

namespace FBM.WebUI.Controllers
{
    public class LiveController : BaseController
    {
        public ActionResult Index(Guid? id)
        {
            base.CheckMobile();
            if (!id.HasValue)
            {
                return RedirectToAction("StartTraining");
            }
            LiveTrainingDTO vm = ClientServiceProxy.LiveTrainingService().GetLiveTrainingDTO(id.Value);
            ShowMessage(Helper.MessageType.Info, Resources.Training + " " +vm.PlayerName + " " + vm.TrainingName,duration:99999,closeable:false);
            return View(vm);
        }
        public ActionResult StartTraining()
        {
            base.CheckMobile();
            StartTrainingVM vm = new StartTrainingVM();
            vm = FillStartTrainingVm(vm);
            return View(vm);
        }
        [HttpPost]
        public ActionResult StartTraining(StartTrainingVM vm)
        {
            PlayerTraining playerTraining = new PlayerTraining()
            {
                PlayerId = vm.PlayerId,
                TrainingId = vm.TrainingId,
                TrainingDate = DateTime.Now
            };
            playerTraining = ClientServiceProxy.PlayerTrainingService().Post(playerTraining);
            bool res = ClientServiceProxy.PlayerTrainingService().StartTraining(playerTraining.Id);
            if (res == false)
            {
                ShowMessage(Helper.MessageType.Danger, Resources.ProgressRun, closeable: false);
                vm = FillStartTrainingVm(vm);
                return View(vm);
            }
            return RedirectToAction("index", new { id = playerTraining.Id });
        }
        public StartTrainingVM FillStartTrainingVm(StartTrainingVM vm)
        {
            vm.PlayerList = ClientServiceProxy.PlayerService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            vm.TrainingList = ClientServiceProxy.TrainingService().Get().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return vm;
        }


        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }

        public LiveTrainingDTO GetVm(Guid id,int responseId)
        {
            int? cID = MemoryCache.Default.Get("responseId") as int?;
            if (cID == null)
            {
                MemoryCache.Default.Add("responseId", responseId, DateTime.Now.AddSeconds(15));
            }
            int cId = Convert.ToInt32(cID);

            LiveTrainingDTO vm = MemoryCache.Default.Get("LiveTrainingDTO") as LiveTrainingDTO;
            if (vm != null)
            {
                if (responseId == cID)
                {
                    return vm;
                }
            }
            LiveTrainingDTO toCash = ClientServiceProxy.LiveTrainingService().GetLiveTrainingDTO(id);

            MemoryCache.Default.Add("LiveTrainingDTO", toCash, DateTime.Now.AddSeconds(15));

            return toCash;
        }


        public PartialViewResult _liveChart(Guid id, int responseId)
        {
            return PartialView(GetVm(id,responseId));
        }
        public PartialViewResult _liveGrid(Guid id, int responseId)
        {
            return PartialView(GetVm(id, responseId));
        }
        public PartialViewResult _liveChart2(Guid id, int responseId)
        {
            return PartialView(GetVm(id, responseId));
        }
        public JsonResult GetLiveDataJson()
        {
            LiveDataVM vm = new LiveDataVM();
            LiveTraining liveTraining = ClientServiceProxy.LiveTrainingService().Get().FirstOrDefault();
            if (liveTraining != null)
            {
                vm.isNew = liveTraining.isNew;
                vm.Val = (int)liveTraining.LiveStatus;
                vm.Id = liveTraining.PlayerTrainingId.ToString();
                if (string.IsNullOrEmpty(liveTraining.R1))
                {
                    vm.R1 = "-";
                }
                else
                {
                    vm.R1 = liveTraining.R1;
                }
                if (string.IsNullOrEmpty(liveTraining.R2))
                {
                    vm.R2 = "-";
                }
                else
                {
                    vm.R2 = liveTraining.R2;
                }
                vm.StationNo = liveTraining.StationNo;
                vm.S0C = liveTraining.S0C;
                vm.S1C = liveTraining.S1C;
                vm.S2C = liveTraining.S2C;
                vm.S3C = liveTraining.S3C;
                vm.S4C = liveTraining.S4C;
                vm.S5C = liveTraining.S5C;
                vm.S6C = liveTraining.S6C;
                vm.S7C = liveTraining.S7C;
                vm.isLive = liveTraining.isLive;
            }
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
}