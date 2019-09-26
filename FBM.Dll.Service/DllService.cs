using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FBM.Dll.Enum;
using FBM.Dll.Struct;

namespace FBM.Dll.Service
{
    public class DllService
    {
        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "Initialize", CallingConvention = CallingConvention.StdCall)]
        public static extern FBM_Main_STATUS FBMInitialize([MarshalAs(UnmanagedType.FunctionPtr)] MyCallBack callback);

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "IsAttached", CallingConvention = CallingConvention.StdCall)]
        public static extern bool FBMIsAttached();

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "IsBroken", CallingConvention = CallingConvention.StdCall)]
        public static extern bool FBMIsBroken();

        //[DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "printLog", CallingConvention = CallingConvention.StdCall)]
        //public static extern bool FBMprintLog(string msg);

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "CBRevoke", CallingConvention = CallingConvention.StdCall)]
        public static extern FBM_Main_STATUS CBRevoke();

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "CBAuth", CallingConvention = CallingConvention.StdCall)]
        public static extern FBM_Main_STATUS CBAuth(Delegate callback);

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "IsBallPassed", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IsBallPassed();

        [DllImport("FBM_DLL.dll", CharSet = CharSet.Auto, EntryPoint = "Request", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FBMRequest(FBM_Request request, IntPtr valIn);
    }
}