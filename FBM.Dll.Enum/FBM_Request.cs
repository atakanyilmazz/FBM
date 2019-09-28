using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Dll.Enum
{
    public enum FBM_Request
    {
        REQUEST_GET_LDR_DEVICE_CNT = 0x60,      // parameters  in: none  /  out: char* count
        REQUEST_GET_STATION_DEVICE_CNT = 0x61,  // parameters  in: none  /  out: char* count
        REQUEST_GET_MOTOR_STATUS = 0x62,        // parameters  in: char* station_no  /  out: char* motors[4] 
        REQUEST_SET_MOTORS = 0x63,              // parameters  in: struct * {char station_no, motors[4]}  /  out: none
        REQUEST_RELEASE = 0x64,                 // parameters in:char* station_no  /  out: none
        REQUEST_MIX_ON = 0x65,                  // parameters in: char* station_no  /  out: none
        REQUEST_MIX_OFF = 0x66,                 // parameters in: char* station_no  /  out: none
        REQUEST_GET_LAST_BALLSTATUS = 0x67,     //parameters in: none  / out: byte[102]
        REQUEST_GET_FLAGS = 0x68,               //parameters in:none / out: byte[Station Count]
        REQUEST_LAMP = 0x69,                    //parameters in: byte count, count times (byte lamp_no, LampColor colour_no, byte value) / out: none
        REQUEST_LAMPS_OFF = 0x6A,                //parameters in: none / out: none
        REQUEST_Device_Info = 0x6B,                //parameters in: none / out: none
        REQUEST_START_TRAINING = 0,
    }
}
