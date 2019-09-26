using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Throw
{
    public class ThrowBallAltitudeMap : BaseEntityMap<ThrowBallAltitude>
    {
        public ThrowBallAltitudeMap()
        {
            ToTable("ThrowBallAltitude");

            HasRequired(x => x.AltitudeType).WithMany(x => x.ThrowBallAltitude).HasForeignKey(x => x.AltitudeTypeId);
        }
    }
}
