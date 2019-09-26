using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class ThrowBallAltitudeApi : BaseApi<ThrowBallAltitude>
    {
        public ThrowBallAltitudeApi():base("ThrowBallAltitude")
        {

        }
        public List<ThrowBallAltitude> GetByAltitudeTypeId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/ThrowBallAltitude/GetByAltitudeTypeId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<ThrowBallAltitude>>().Result;
            return res;
        }
    }
}
