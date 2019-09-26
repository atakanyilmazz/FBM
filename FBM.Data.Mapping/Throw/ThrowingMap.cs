using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Throw
{
    public class ThrowingMap : BaseEntityMap<Throwing>
    {
        public ThrowingMap()
        {
            ToTable("Throwing");
            Property(x => x.MotorId).IsRequired();
            Property(x => x.ThrowBallAngleId).IsRequired();
            Property(x => x.ThrowBallAltitudeId).IsRequired();

            HasRequired(x => x.ThrowBallAngle).WithMany(x => x.Throwing).HasForeignKey(x => x.ThrowBallAngleId);
            HasRequired(x => x.ThrowBallAltitude).WithMany(x => x.Throwing).HasForeignKey(x => x.ThrowBallAltitudeId);
            HasRequired(x => x.Motor).WithMany(x => x.Throwing).HasForeignKey(x => x.MotorId);

        }
    }
}
