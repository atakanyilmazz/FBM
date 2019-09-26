using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Struct
{
    public struct StationFlag
    {
        [MarshalAs(UnmanagedType.U1, SizeConst = 2)]
       public byte command;
        [MarshalAs(UnmanagedType.Bool, SizeConst = 1)]
        public bool ball1;
        [MarshalAs(UnmanagedType.Bool, SizeConst = 1)]
        public bool ball3;
        [MarshalAs(UnmanagedType.Bool, SizeConst = 1)]
        public bool release;
        [MarshalAs(UnmanagedType.Bool, SizeConst = 1)]
        public bool mix;
        [MarshalAs(UnmanagedType.U1, SizeConst = 2)]
        public byte dummy;
    }
}
