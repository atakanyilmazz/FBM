using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class BallPassLdrPointItem
    {
        public BallPassLdrPointItem(Axis axis)
        {
            this.Axis = axis;
            FirstPoint = 0;
            LastPoint = 0;
        }
        public Axis Axis { get; private set; }
        public int FirstPoint { get; set; }
        public int LastPoint { get; set; }
    }
}
