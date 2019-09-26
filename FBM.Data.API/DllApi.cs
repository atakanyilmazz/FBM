using FBM.Dll.Struct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FBM.Data.API
{
    public class DllApi
    {
        public static HttpClient client = new HttpClient();
        public DllApi()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://localhost:88/");
            }
        }
        public bool MixOn(int StationNo)
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/MixOn?stationNo={StationNo}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<bool>().Result;
            return res;
        }
        public bool MixOff(int StationNo)
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/MixOff?stationNo={StationNo}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<bool>().Result;
            return res;
        }
        public bool ReleaseBall(int StationNo)
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/ReleaseBall?stationNo={StationNo}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<bool>().Result;
            return res;
        }
        public int LdrCount()
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/LdrCount").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<int>().Result;
            return res;
        }
        public int DeviceCount()
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/DeviceCount").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<int>().Result;
            return res;
        }
        public List<byte> GetMotor(int StationNo)
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/GetMotor?stationNo={StationNo}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<byte>>().Result;
            return res;
        }
        public void LampsOff()
        {
            HttpResponseMessage resp = client.GetAsync($"api/BaseDll/LampsOff").Result;
            resp.EnsureSuccessStatusCode();
        }
    }
}
