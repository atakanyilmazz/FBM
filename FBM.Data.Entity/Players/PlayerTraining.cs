using FBM.Core.Resource;
using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Players
{
    public class PlayerTraining : BaseEntity
    {
        [Required]
        [Display(Name = "Player", ResourceType = typeof(Resources))]
        public Guid PlayerId { get; set; }
        [Required]
        [Display(Name = "Training", ResourceType = typeof(Resources))]
        public Guid TrainingId { get; set; }
        [Required]
        [Display(Name = "TrainingDate", ResourceType = typeof(Resources))]
        public DateTime TrainingDate { get; set; }
        [Display(Name = "TimeScore", ResourceType = typeof(Resources))]
        public decimal? TimeScore{ get; set; }
        [Display(Name = "SpeedScore", ResourceType = typeof(Resources))]
        public decimal? SpeedScore { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }
        public List<TrainLog> TrainLog { get; set; }
    }
}
