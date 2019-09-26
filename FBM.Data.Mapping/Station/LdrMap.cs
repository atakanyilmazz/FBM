using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Entity.Station;

namespace FBM.Data.Mapping.Station
{
   public class LdrMap : BaseEntityMap<Ldr>
    {
        public LdrMap()
        {
            ToTable("Ldr");
            Property(x => x.Axis).IsRequired();
            Property(x => x.WallPosition).IsRequired();

            HasRequired(x => x.Station).WithMany(x => x.Ldr).HasForeignKey(x => x.StationId);
        }
    }
}
