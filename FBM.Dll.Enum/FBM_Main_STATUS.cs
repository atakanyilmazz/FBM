using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Enum
{
    public enum FBM_Main_STATUS
    {
        STATUS_OK = 0x40,
        STATUS_BUSY = 0x41,
        STATUS_NO_DEVICE = 0x42,
        STATUS_NO_INFO = 0x43,
        STATUS_CONN_BROKEN = 0x44,
        STATUS_LDR_BLOCKED = 0x45,
        STATUS_LDR_CLEAR = 0x46,
        STATUS_INVALID_ARG = 0x47,

        STATUS_ERR = 0x50,
        STATUS_NOT_INITIALIZED = 0x51,
        STATUS_REGISTERED_BEFORE = 0x52,
        STATUS_ERR_REGISTER = 0x53,
        STATUS_ERR_CREATING_WND = 0x54,
        STATUS_INVALID = 0x55,
        STATUS_SEND_SERIAL = 0x56,
        STATUS_OF = 0x57,
        STATUS_UNKNOWN_COMM = 0x58,
        STATUS_ERROR = 0x59
    }
}
