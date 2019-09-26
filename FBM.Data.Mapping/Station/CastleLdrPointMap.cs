using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Entity.Station;

namespace FBM.Data.Mapping.Station
{
    public class CastleLdrPointMap : BaseEntityMap<CastleLdrPoint>
    {
        public CastleLdrPointMap()
        {
            ToTable("CastleLdrPoint");
            Property(x => x.Axis).IsRequired();

            HasRequired(x => x.Castle).WithMany(x => x.CastleLdrPoint).HasForeignKey(x => x.CastleId);
        }
    }
}
