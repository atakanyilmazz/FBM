using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Throw
{
    public class ThrowBallAngleMap : BaseEntityMap<ThrowBallAngle>
    {
        public ThrowBallAngleMap()
        {
            ToTable("ThrowBallAngle");

            HasRequired(x => x.AngleType).WithMany(x => x.ThrowBallAngle).HasForeignKey(x => x.AngleTypeId);
        }
    }
}
