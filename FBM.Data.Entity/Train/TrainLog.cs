using FBM.Core.Resource;
using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Train
{
    public class TrainLog : BaseEntity
    {
        [Required]
        [Display(Name = "PlayerTraining", ResourceType = typeof(Resources))]
        public Guid PlayerTrainingId { get; set; }
        [Required]
        [Display(Name = "Target", ResourceType = typeof(Resources))]
        public Guid TargetId { get; set; }
        [Required]
        [Display(Name = "isSuccess", ResourceType = typeof(Resources))]
        public bool isSuccess { get; set; }
        [Display(Name = "Time", ResourceType = typeof(Resources))]
        public TimeSpan? Time { get; set; }
        [Required]
        [Display(Name = "Speed", ResourceType = typeof(Resources))]
        public int Speed { get; set; }
        [Required]
        [Display(Name = "TimeScore", ResourceType = typeof(Resources))]
        public decimal TimeScore { get; set; }
        [Required]
        [Display(Name = "SpeedScore", ResourceType = typeof(Resources))]
        public decimal SpeedScore { get; set; }
        [Display(Name = "OrderNo", ResourceType = typeof(Resources))]
        public int OrderNo { get; set; }

        [ForeignKey("PlayerTrainingId")]
        public virtual PlayerTraining PlayerTraining { get; set; }
        [ForeignKey("TargetId")]
        public virtual Target Target { get; set; }
    }
}
