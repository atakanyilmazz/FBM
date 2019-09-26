using FBM.Data.API;
using FBM.Data.DTO;
using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Controllers
{
    public class PlayerTrainingController : BaseController
    {
        public PartialViewResult _PlayerTrainingList()
        {
            List<PlayerTraining> res = ClientServiceProxy.PlayerTrainingService().Get();
            return PartialView(res);
        }

        public ActionResult Result(Guid id)
        {
            LiveTrainingDTO vm = ClientServiceProxy.LiveTrainingService().GetLiveTrainingDTO(id);
            return View(vm);
        }
    }
}