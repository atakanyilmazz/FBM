using FBM.Data;
using FBM.Data.DTO;
using FBM.Data.Entity;
using FBM.Data.Entity.Players;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using FBM.Data.Enum;
using FBM.Dll.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FBMConsoleCGI
{
    public class Program
    {

        static DllFunctions _func = new DllFunctions();
        static DbmDbContext db = new DbmDbContext();


        static void Main(string[] args)
        {
            if (System.Environment.GetEnvironmentVariable("REQUEST_METHOD").Equals("POST"))
            {
                string PostedData = "";
                int PostedDataLength = Convert.ToInt32(System.Environment.GetEnvironmentVariable("CONTENT_LENGTH"));
                if (PostedDataLength > 2048) PostedDataLength = 2048;   // Max length for POST data
                for (int i = 0; i < PostedDataLength; i++)
                    PostedData += Convert.ToChar(Console.Read()).ToString();

                FBM_Request request = (FBM_Request)Enum.Parse(typeof(FBM_Request), PostedData);
                _func.Initalize(null);
                //Console.Write("Content-Type: application/json\n\n");
                Console.Write("Content-Type: text/html\n\n");
                switch (request)
                {
                    case FBM_Request.REQUEST_GET_LDR_DEVICE_CNT:
                        Console.Write(JsonConvert.SerializeObject(_func.GetLdrCount()));
                        break;
                    case FBM_Request.REQUEST_GET_STATION_DEVICE_CNT:
                        Console.Write(JsonConvert.SerializeObject(_func.GetLdrDevicesCount()));
                        break;
                    case FBM_Request.REQUEST_GET_MOTOR_STATUS:
                        break;
                    case FBM_Request.REQUEST_SET_MOTORS:
                        break;
                    case FBM_Request.REQUEST_RELEASE:
                        break;
                    case FBM_Request.REQUEST_MIX_ON:
                        break;
                    case FBM_Request.REQUEST_MIX_OFF:
                        break;
                    case FBM_Request.REQUEST_GET_LAST_BALLSTATUS:
                        break;
                    case FBM_Request.REQUEST_GET_FLAGS:
                        break;
                    case FBM_Request.REQUEST_LAMP:
                        break;
                    case FBM_Request.REQUEST_LAMPS_OFF:
                        break;
                    case FBM_Request.REQUEST_START_TRAINING:
                        break;
                    default:
                        break;
                }
                _func.Revoke();
            }
            else
            {
                Console.Write("Content-Type: text/html\n\n");
            }
            Console.Write(JsonConvert.SerializeObject(2));
        }
    }
}
