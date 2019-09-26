using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Station
{
    public class MotorMap : BaseEntityMap<Motor>
    {
        public MotorMap()
        {
            ToTable("Motor");
            Property(x => x.StationId).IsRequired();
            Property(x => x.StationNo).IsRequired();
            Property(x => x.WallPosition).IsRequired();
            Property(x => x.Floor).IsRequired();

            HasRequired(x => x.Station).WithMany(x => x.Motor).HasForeignKey(x => x.StationId);
        }
    }
}
