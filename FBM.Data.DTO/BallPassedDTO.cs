using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class BallPassedDTO
    {
        public BallPassedDTO()
        {
            BallPassedLdrItems = new List<BallPassedLdrItem>();
        }
        public int BallSpeed { get; set; }
        public List<BallPassedLdrItem> BallPassedLdrItems { get; set; }
    }
}
