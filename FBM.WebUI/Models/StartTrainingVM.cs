using FBM.Core.Resource;
using FBM.Data.Entity.Players;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FBM.WebUI.Models
{
    public class StartTrainingVM
    {
        [Display(Name = "Player", ResourceType = typeof(Resources))]
        public Guid PlayerId { get; set; }
        [Display(Name = "Training", ResourceType = typeof(Resources))]
        public Guid TrainingId { get; set; }
        public List<SelectListItem> PlayerList { get; set; }
        public List<SelectListItem> TrainingList { get; set; }
        public DeviceInfo DeviceInfo { get; set; }
    }
}