using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class MotorApi : BaseApi<Motor>
    {
        public MotorApi():base("Motor")
        {

        }
        public List<Motor> GetByStationId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Motor/GetByStationId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Motor>>().Result;
            return res;
        }
    }
}
