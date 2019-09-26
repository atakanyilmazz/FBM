using FBM.Core.Resource;
using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Train
{
    public class Training : NamedEntity
    {
        [Required]
        [Display(Name = "ThrowWaitingTime", ResourceType = typeof(Resources))]
        public decimal ThrowWaitingTime { get; set; }
        [Required]
        [Display(Name = "ThrowTimeOut", ResourceType = typeof(Resources))]
        public decimal ThrowTimeOut { get; set; }
        [Required]
        [Display(Name = "TimeScoreFactor", ResourceType = typeof(Resources))]
        public decimal TimeScoreFactor { get; set; }
        [Required]
        [Display(Name = "SpeedScoreFactor", ResourceType = typeof(Resources))]
        public decimal SpeedScoreFactor { get; set; }


        public ICollection<Target> Target { get; set; }
        public ICollection<PlayerTraining> PlayerTraining { get; set; }
    }
}
