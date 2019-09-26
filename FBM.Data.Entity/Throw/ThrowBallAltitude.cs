using FBM.Core.Resource;
using FBM.Data.Entity.Throw;
using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Throw
{
    public class ThrowBallAltitude : BaseEntity
    {
        [Required]
        [Display(Name = "Floor", ResourceType = typeof(Resources))]
        public Floor Floor { get; set; }
        [Required]
        [Display(Name = "AltitudeType", ResourceType = typeof(Resources))]
        public Guid AltitudeTypeId { get; set; }
        [Required]
        [Display(Name = "Motor1State", ResourceType = typeof(Resources))]
        public int Motor1State { get; set; }
        [Required]
        [Display(Name = "Motor2State", ResourceType = typeof(Resources))]
        public int Motor2State { get; set; }

        [ForeignKey("AltitudeTypeId")]
        public virtual AltitudeType AltitudeType { get; set; }
        public ICollection<Throwing> Throwing { get; set; }
        public override string ToString()
        {
            return $"{this.AltitudeType.Name}";
        }
    }
}