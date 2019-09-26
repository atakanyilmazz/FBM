using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class LdrApi : BaseApi<Ldr>
    {
        public LdrApi():base("Ldr")
        {

        }
        public List<Ldr> GetByStationId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Ldr/GetByStationId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Ldr>>().Result;
            return res;
        }
    }
}
