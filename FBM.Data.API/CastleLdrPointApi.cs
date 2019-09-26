using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class CastleLdrPointApi :  BaseApi<CastleLdrPoint>
    {
        public CastleLdrPointApi():base("CastleLdrPoint")
        {

        }
        public List<CastleLdrPoint> GetByCastleId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/CastleLdrPoint/GetByCastleId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<CastleLdrPoint>>().Result;
            return res;
        }
    }
}
