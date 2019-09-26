using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Throw
{
    public class AltitudeType : NamedEntity
    {
        public ICollection<ThrowBallAltitude> ThrowBallAltitude { get; set; }
    }
}
