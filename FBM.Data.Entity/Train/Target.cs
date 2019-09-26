using FBM.Core.Resource;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Train
{
    public class Target : BaseEntity
    {
        [Required]
        [Display(Name = "Training", ResourceType = typeof(Resources))]
        public Guid TrainingId { get; set; }
        [Required]
        [Display(Name = "Throwing", ResourceType = typeof(Resources))]
        public Guid ThrowingId { get; set; }
        [Required]
        [Display(Name = "Castle", ResourceType = typeof(Resources))]
        public Guid CastleId { get; set; }
        [Required]
        [Display(Name = "ThrowingCount", ResourceType = typeof(Resources))]
        public decimal ThrowingCount { get; set; }

        [ForeignKey("TrainingId")]
        public virtual Training Training { get; set; }
        [ForeignKey("ThrowingId")]
        public virtual Throwing Throwing { get; set; }
        [ForeignKey("CastleId")]
        public virtual Castle Castle { get; set; }
        public ICollection<TrainLog> TrainLog { get; set; }
    }
}
