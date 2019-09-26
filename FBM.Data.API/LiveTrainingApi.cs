using FBM.Data.DTO;
using FBM.Data.Entity;
using FBM.Data.Entity.Throw;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class LiveTrainingApi : BaseApi<LiveTraining>
    {
        public LiveTrainingApi():base("LiveTraining")
        {

        }
        public LiveTrainingDTO GetLiveTrainingDTO(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/LiveTraining/GetLiveTrainingDTO/{id}").Result;
            resp.EnsureSuccessStatusCode();
            //var res = resp.Content.ReadAsAsync<LiveTrainingDTO>().Result;
            string str = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<LiveTrainingDTO>(str);
            return res;
        }
    }
}
