using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.UnityCore
{
    public class ThrowBallDTO
    {
        public Guid ThrowingID { get; set; }
        public Throwing Throwing { get; set; }
    }
}
