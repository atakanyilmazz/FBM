using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class ThrowingApi : BaseApi<Throwing>
    {
        public ThrowingApi():base("Throwing")
        {

        }
        public List<Throwing> GetByThrowBallAngleId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Throwing/GetByThrowBallAngleId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Throwing>>().Result;
            return res;
        }
        public List<Throwing> GetByMotorId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Throwing/GetByMotorId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Throwing>>().Result;
            return res;
        }
        public List<Throwing> GetByThrowBallAltitudeId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Throwing/GetByThrowBallAltitudeId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Throwing>>().Result;
            return res;
        }
    }
}
