using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class BallPassedLdrItem
    {
        public Ldr Ldr { get; set; }
        public string BinaryValue { get; set; }
        public int FirstLdrPoint { get { return 8 - this.BinaryValue.LastIndexOf("1"); } }
        public int LastLdrPoint { get { return 8 - this.BinaryValue.IndexOf("1"); } }
    }
}
