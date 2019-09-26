using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class TrainLogApi : BaseApi<TrainLog>
    {
        public TrainLogApi():base("TrainLog")
        {

        }
        public List<TrainLog> GetByPlayerTrainingId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/TrainLog/GetByPlayerTrainingId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<TrainLog>>().Result;
            return res;
        }
        public List<TrainLog> GetByTargetId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/TrainLog/GetByTargetId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<TrainLog>>().Result;
            return res;
        }
    }
}
