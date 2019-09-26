using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Station
{
    public class StationMap : NamedEntityMap<Entity.Station.Station>
    {
        public StationMap()
        {
            ToTable("Station");
        }
    }
}
