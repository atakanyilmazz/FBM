using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Models
{
    public class LiveDataVM
    {
        public bool isLive { get; set; }
        public bool isNew { get; set; }
        public int Val { get; set; }
        public string Id { get; set; }
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string StationNo { get; set; } //T00 Station No
        public int S0C { get; set; }
        public int S1C { get; set; }
        public int S2C { get; set; }
        public int S3C { get; set; }
        public int S4C { get; set; }
        public int S5C { get; set; }
        public int S6C { get; set; }
        public int S7C { get; set; }
    }
}