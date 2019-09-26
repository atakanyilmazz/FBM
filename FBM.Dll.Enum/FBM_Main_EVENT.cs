using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Enum
{
    public enum FBM_Main_EVENT
    {
        EVENT_SEC_TICK = 0x20,              // parameter structure: DWORD *
        EVENT_BALL_PASSED = 0x40,           // parameter structure: 	struct	*{USHORT ballTime; char LDR[100];}
        EVENT_DEVICE_ATTACHED = 0x41,       // parameter structure: NULL
        EVENT_DEVICE_DETACHED = 0x42,       // parameter structure: NULL
        EVENT_LDR_BLOCKED = 0x43,           // parameter structure: NULL
        EVENT_LDR_CLEARED = 0x44,           // parameter structure: NULL
        EVENT_STATION_CNT_CHANGED = 0x45,   //parameter structure: char (newDeviceCount)
        EVENT_LDR_CNT_CHANGED = 0x46        //parameter structure: char (newDeviceCount)
    }
}
