using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FBM.Data.Entity.Station;

namespace FBM.Data.Mapping.Station
{
   public class CastleMap : BaseEntityMap<Castle>
    {
        public CastleMap()
        {
            ToTable("Castle");
            Property(x => x.WallPosition).IsRequired();
            Property(x => x.CastlePosition).IsRequired();
            Property(x => x.CastleFloor).IsRequired();

            HasRequired(x => x.Station).WithMany(x => x.Castle).HasForeignKey(x => x.StationId);
        }
    }
}
