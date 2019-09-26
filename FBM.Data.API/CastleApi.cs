using FBM.Data.DTO;
using FBM.Data.Entity.Station;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class CastleApi : BaseApi<Castle>
    {
        public CastleApi():base("Castle")
        {

        }
        public List<Castle> GetByStationId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Castle/GetByStationId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Castle>>().Result;
            return res;
        }
    }
}
