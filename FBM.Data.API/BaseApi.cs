using FBM.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FBM.Data.API
{
    public abstract class BaseApi<T> where T : BaseEntity
    {
        private string _route;
        public string Route
        {
            get { return _route; }
            set { Route = _route; }
        }
        public static HttpClient client = new HttpClient();
        public BaseApi(string route)
        {
            _route = route;
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://192.168.1.107:88/");
            }
            try
            {
                HttpResponseMessage resp = client.GetAsync($"api/station/Get").Result;
                resp.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.107:88/");
            }
        }
        public  List<T> Get()
        {
            HttpResponseMessage resp = client.GetAsync($"api/{Route}/Get").Result;
            resp.EnsureSuccessStatusCode();
            string str = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<List<T>>(str);
            return res;
        }
        public T Get(Guid id)
        {
            HttpResponseMessage resp = client.GetAsync($"api/{Route}/Get/{id}").Result;
            resp.EnsureSuccessStatusCode();
            string str = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<T>(str);
            return res;
        }
        public T Post(T entity)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"api/{Route}/Post", content).Result;
            resp.EnsureSuccessStatusCode();
            string str = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<T>(str);
            return res;
        }
        public T Put(Guid id, T entity)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PutAsync($"api/{Route}/Put/{id}", content).Result;
            resp.EnsureSuccessStatusCode();
            string str = resp.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<T>(str);
            return res;
        }
        public void Delete(Guid id)
        {
            HttpResponseMessage resp = client.DeleteAsync($"api/{Route}/Delete/{id}").Result;
            resp.EnsureSuccessStatusCode();
        }
    }
}