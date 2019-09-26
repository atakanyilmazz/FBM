using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class TrainLogDTO
    {
        public bool isSuccess { get; set; }
        public int Speed { get; set; }
        public TimeSpan? Time { get; set; }
        public decimal SpeedScore { get; set; }
        public decimal TimeScore { get; set; }
        public int OrderNo { get; set; }
    }
}
