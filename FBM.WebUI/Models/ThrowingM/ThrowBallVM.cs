using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Models.ThrowingM
{
    public class ThrowBallVM
    {
        public List<ThrowBallAltitude> ThrowBallAltitude { get; set; }
        public List<ThrowBallAngle> ThrowBallAngle { get; set; }
    }
}