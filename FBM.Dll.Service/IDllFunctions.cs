using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Dll.Enum;

namespace FBM.Dll.Service
{
    public interface IDllFunctions
    {
        FBM_Main_STATUS Initalize(MyCallBack val);
        int GetLdrDevicesCount();
        int GetStationDevicesCount();
        bool MixOn(int stationNo);
        bool MixOff(int stationNo);
        bool ReleaseBall(int stationNo);

    }
}
