using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Dll.Enum;
using System.Collections;
using FBM.Dll.Struct;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security;
using System.Drawing;

namespace FBM.Dll.Service
{
    public class DllFunctions : IDllFunctions
    {
        public FBM_Main_STATUS Initalize(MyCallBack val)
        {
            return DllService.FBMInitialize(null);
        }
        public string GetLdrCount()
        {
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_LDR_DEVICE_CNT, ptrbye);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
            {
                if (res.values != null)
                {
                    return res.status.ToString() + " " + res.values[0];
                }
            }
            return res.status.ToString();
        }
        public int GetLdrDevicesCount()
        {
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_LDR_DEVICE_CNT, ptrbye);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
            {
                if (res.values != null)
                {
                    return res.values[0];
                }
            }
            return 0;
        }
        public int GetStationDevicesCount()
        {
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_STATION_DEVICE_CNT, ptrbye);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.values != null)
            {
                return res.values[0];
            }
            return 0;
        }
        public BallPassStruct GetPassedBallInfo()
        {
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_LAST_BALLSTATUS, ptrbye);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.values != null)
            {
                BallPassStruct a = new BallPassStruct();
                a.ballTime = Convert.ToInt32(res.values[0] + (res.values[1] * 256));
                List<byte> x = res.values.ToList();
                x.RemoveRange(0, 2);
                a.LDR = x;
                return a;
            }
            return null;
        }
        public bool IsBallPast()
        {
            return DllService.IsBallPassed();
        }
        public bool MixOn(int stationNo)
        {
            IntPtr param = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(param, 0, stationNo);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_MIX_ON, param);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
                return true;
            return false;
        }
        public bool MixOff(int stationNo)
        {
            IntPtr param = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(param, 0, stationNo);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_MIX_OFF, param);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
                return true;
            return false;
        }
        [SecurityCritical]
        public bool ReleaseBall(int stationNo)
        {
            IntPtr param = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(param, 0, stationNo);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_RELEASE, param);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
                return true;
            return false;
        }
        public FBM_Main_STATUS Revoke()
        {
            return DllService.CBRevoke();
        }
        public FBM_Main_STATUS Auth(MyCallBack val)
        {
            return DllService.CBAuth(val);
        }
        public bool SetMotor(List<byte> values)
        {
            IntPtr param = Marshal.AllocHGlobal(20);
            Marshal.WriteByte(param, 0, values[0]);     //Station No
            Marshal.WriteByte(param, 1, values[1]);     //Motor 1 Yükseklik
            Marshal.WriteByte(param, 2, values[2]);     //Motor 2 Kullanılmıyor
            Marshal.WriteByte(param, 3, values[3]);     //Motor 3 Sol Motor
            Marshal.WriteByte(param, 4, values[4]);     //Motor 4 Sağ Motor
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_SET_MOTORS, param);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.status == FBM_Main_STATUS.STATUS_OK)
            {
                return true;
            }
            return true;
        }
        public List<byte> GetMotor(int stationNo)
        {
            IntPtr param = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(param, 0, stationNo);
            IntPtr ptr = Marshal.AllocHGlobal(260);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_MOTOR_STATUS, param);
            RequestStruct res = (RequestStruct)Marshal.PtrToStructure(ptr, typeof(RequestStruct));
            if (res.values != null)
            {
                return res.values.ToList();
            }
            return null;
        }
        public Flag GetFlag(int stationNo)
        {
            int StartByte = 4 + stationNo;
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            IntPtr ptr = Marshal.AllocHGlobal(65);
            ptr = DllService.FBMRequest(FBM_Request.REQUEST_GET_FLAGS, ptrbye);
            Flag res = new Flag();
            byte[] managedArray = new byte[13];
            Marshal.Copy(ptr, managedArray, 0, 13);
            byte values = managedArray[StartByte];
            char[] bitstr = Convert.ToString(values, 2).PadLeft(8, '0').ToArray().Reverse().ToArray();
            res.Values = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", bitstr[0], bitstr[1], bitstr[2], bitstr[3], bitstr[4], bitstr[5], bitstr[6], bitstr[7]);
            res.Command = managedArray[0];
            if (bitstr[4] == '1')
            {
                res.Mix = true;
            }
            if (bitstr[3] == '1')
            {
                res.Release = true;
            }
            if (bitstr[2] == '1')
            {
                res.Ball1 = true;
            }
            return res;
        }
        public void LampsOn(List<LampsOnDTO> vm)
        {
            this.SendLog("LampsOn", "Before");
            IntPtr ptrbye = Marshal.AllocHGlobal(((vm.Count * 3) * 3) + 1);
            int byteIndex = 0;
            Marshal.WriteByte(ptrbye, byteIndex, Convert.ToByte(vm.Count * 3));
            foreach (LampsOnDTO item in vm)
            {
                Marshal.WriteByte(ptrbye, byteIndex + 1, Convert.ToByte(item.CastleNo));
                Marshal.WriteByte(ptrbye, byteIndex + 2, Convert.ToByte((int)LampColor.RED));
                Marshal.WriteByte(ptrbye, byteIndex + 3, Convert.ToByte(item.Color.R));
                Marshal.WriteByte(ptrbye, byteIndex + 4, Convert.ToByte(item.CastleNo));
                Marshal.WriteByte(ptrbye, byteIndex + 5, Convert.ToByte((int)LampColor.GREEN));
                Marshal.WriteByte(ptrbye, byteIndex + 6, Convert.ToByte(item.Color.G));
                Marshal.WriteByte(ptrbye, byteIndex + 7, Convert.ToByte(item.CastleNo));
                Marshal.WriteByte(ptrbye, byteIndex + 8, Convert.ToByte((int)LampColor.BLUE));
                Marshal.WriteByte(ptrbye, byteIndex + 9, Convert.ToByte(item.Color.B));
                byteIndex += 9;
            }

            DllService.FBMRequest(FBM_Request.REQUEST_LAMP, ptrbye);
            this.SendLog("LampsOn", ptrbye.ToString());
            this.SendLog("LampsOn", "After");
        }
        public void LampsOff()
        {
            IntPtr ptrbye = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(ptrbye, 0, 1);
            DllService.FBMRequest(FBM_Request.REQUEST_LAMPS_OFF, ptrbye);
        }
        public void SendLog(string function, string text)
        {
            //DllService.FBMprintLog("_" + function + " - " + text);
        }
    }
}