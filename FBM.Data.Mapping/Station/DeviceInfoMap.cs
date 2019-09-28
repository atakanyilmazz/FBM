using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Station
{
    public class DeviceInfoMap : BaseEntityMap<DeviceInfo>
    {
        public DeviceInfoMap()
        {
            ToTable("DeviceInfo");
            Property(x => x.LdrCount).IsRequired();
            Property(x => x.DeviceCount).IsRequired();

        }

    }
}
