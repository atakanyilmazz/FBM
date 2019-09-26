using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Throw
{
    public class AltitudeTypeMap : NamedEntityMap<AltitudeType>
    {
        public AltitudeTypeMap()
        {
            ToTable("AltitudeType");
        }
    }
}
