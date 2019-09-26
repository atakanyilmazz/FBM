using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class TargetApi : BaseApi<Target>
    {
        public TargetApi():base("Target")
        {

        }
        public List<Target> GetByTrainingId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Target/GetByTrainingId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Target>>().Result;
            return res;
        }
        public List<Target> GetByThrowingId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Target/GetByThrowingId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Target>>().Result;
            return res;
        }
        public List<Target> GetByCastleId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/Target/GetByCastleId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<Target>>().Result;
            return res;
        }
    }
}
