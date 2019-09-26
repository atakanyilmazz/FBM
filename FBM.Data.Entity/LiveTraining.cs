using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity
{
    public class LiveTraining : BaseEntity
    { 
        public bool isNew { get; set; }
        public bool isLive { get; set; }
        public Guid? PlayerTrainingId { get; set; }
        public DateTime? StartDate { get; set; }
        public LiveStatus LiveStatus { get; set; }
        public string R1 { get; set; }//enum wallposition-enum castleposition-enum floor - RGB
        public string R2 { get; set; }//enum wallposition-enum castleposition-enum floor - RGB
        public string StationNo { get; set; } //T00 Station No
        public int S0C { get; set; }
        public int S1C { get; set; }
        public int S2C { get; set; }
        public int S3C { get; set; }
        public int S4C { get; set; }
        public int S5C { get; set; }
        public int S6C { get; set; }
        public int S7C { get; set; }
        public int RemainingBall { get; set; }
        public int PassedBall { get; set; }
    }
}
