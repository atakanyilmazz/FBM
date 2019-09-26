using FBM.Dll.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Struct
{
    public struct RequestStruct
    {
        public FBM_Main_STATUS status;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] values;
    }
}
