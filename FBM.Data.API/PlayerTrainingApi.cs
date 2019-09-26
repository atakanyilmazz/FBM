using FBM.Data.DTO;
using FBM.Data.Entity.Players;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class PlayerTrainingApi : BaseApi<PlayerTraining>
    {
        public PlayerTrainingApi():base("PlayerTraining")
        {

        }

        public bool StartTraining(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/StartTraining/Get/{id}").Result;
            resp.EnsureSuccessStatusCode();
            string resx = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<bool>(resx);
            return res;
        }
        public List<PlayerTraining> GetByPlayerId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/PlayerTraining/GetByPlayerId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<PlayerTraining>>().Result;
            return res;
        }
        public List<PlayerTrainingDTO> GetPlayerTrainingDTOByPlayerId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/PlayerTraining/GetPlayerTrainingDTOByPlayerId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<PlayerTrainingDTO>>().Result;
            return res;
        }
        public List<PlayerTraining> GetByTrainingId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/PlayerTraining/GetByTrainingId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<PlayerTraining>>().Result;
            return res;
        }

        public List<PlayerTrainingDTO> GetPlayerTrainingDTOTrainingId(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/PlayerTraining/GetPlayerTrainingDTOTrainingId/{id}").Result;
            resp.EnsureSuccessStatusCode();
            var res = resp.Content.ReadAsAsync<List<PlayerTrainingDTO>>().Result;
            return res;
        }
    }
}
