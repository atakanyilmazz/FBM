using FBM.Data.Entity.Throw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class ThrowBallAngleApi : BaseApi<ThrowBallAngle>
    {
        public ThrowBallAngleApi():base("ThrowBallAngle")
        {

        }
        public List<ThrowBallAngle> GetByAngleTypeId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/ThrowBallAngle/GetByAngleTypeId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<ThrowBallAngle>>().Result;
            return res;
        }
    }
}
