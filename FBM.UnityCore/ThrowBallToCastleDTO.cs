using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.UnityCore
{
    public class ThrowBallToCastleDTO
    {
        public Guid throwID { get; set; }
        public Guid castleID { get; set; }
        public Target target { get; set; }
    }
}
