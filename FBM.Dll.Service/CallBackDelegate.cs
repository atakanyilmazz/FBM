using System.Runtime.InteropServices;
using FBM.Dll.Enum;
using System;

namespace FBM.Dll.Service
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void MyCallBack(FBM_Main_EVENT eEvent);
}
