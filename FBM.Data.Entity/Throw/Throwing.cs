using FBM.Core.Resource;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Throw
{
    public class Throwing : BaseEntity
    {
        [Required]
        [Display(Name = "Motor", ResourceType = typeof(Resources))]
        public Guid MotorId { get; set; }
        [Required]
        [Display(Name = "ThrowBallAngle", ResourceType = typeof(Resources))]
        public Guid ThrowBallAngleId { get; set; }
        [Required]
        [Display(Name = "ThrowBallAltitude", ResourceType = typeof(Resources))]
        public Guid ThrowBallAltitudeId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources))]
        public string Name => $"{(this.ThrowBallAltitude != null ? ThrowBallAltitude.AltitudeType.Name : "")} {(this.ThrowBallAngle != null ? ThrowBallAngle.AngleType.Name : "")}";

        [ForeignKey("MotorId")]
        public virtual Motor Motor { get; set; }
        [ForeignKey("ThrowBallAngleId")]
        public virtual ThrowBallAngle ThrowBallAngle { get; set; }
        [ForeignKey("ThrowBallAltitudeId")]
        public virtual ThrowBallAltitude ThrowBallAltitude { get; set; }
        public ICollection<Target> Target { get; set; }
        //public override string ToString()
        //{
        //    return $"{ThrowBallAltitude.AltitudeType.Name} {ThrowBallAngle.AngleType.Name}";
        //}
    }
}
