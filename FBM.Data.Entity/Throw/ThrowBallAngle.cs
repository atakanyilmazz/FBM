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
    public class ThrowBallAngle : BaseEntity
    {
        [Required]
        [Display(Name = "AngleType", ResourceType = typeof(Resources))]
        public Guid AngleTypeId { get; set; }
        [Required]
        [Display(Name = "MotorLeftSpeed", ResourceType = typeof(Resources))]
        public int MotorLeftSpeed { get; set; }
        [Required]
        [Display(Name = "MotorRightSpeed", ResourceType = typeof(Resources))]
        public int MotorRightSpeed { get; set; }

        [ForeignKey("AngleTypeId")]
        public virtual AngleType AngleType { get; set; }
        public ICollection<Throwing> Throwing { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string Name
        {
            get
            {
                return $"{(this.AngleType != null ? this.AngleType.Name:"")}";
            }
        }
        public override string ToString()
        {
            return $"{this.AngleType.Name}";
        }
    }
}
