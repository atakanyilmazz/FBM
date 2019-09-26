using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Struct
{
    public class Flag
    {
        public byte Command { get; set; }
        public bool Ball1 { get; set; } = false;
        public bool Ball3 { get; set; } = false;
        public bool Release { get; set; } = false;
        public bool Mix { get; set; } = false;
        public byte Dummy { get; set; }
        public  string Values { get; set; }
    }
}
