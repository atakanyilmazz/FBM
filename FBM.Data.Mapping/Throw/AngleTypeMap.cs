using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Throw
{
    public class AngleTypeMap : NamedEntityMap<AngleType>
    {
        public AngleTypeMap()
        {
            ToTable("AngleType");
        }
    }
}
