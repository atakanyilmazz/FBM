using FBM.Data.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FBM.Data.API
{
    public class AccountApi
    {

        public static HttpClient client = new HttpClient();
        public AccountApi()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://localhost:22228/");
            }
        }

        public void Register(RegisterBindingModel model)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"api/Account/Register", content).Result;
            resp.EnsureSuccessStatusCode();
        }

        public void Login(LoginBindingModel model)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"api/Account/Login", content).Result;
            resp.EnsureSuccessStatusCode();
        }
        public UserInfoViewModel GetUserInfo()
        {
            HttpResponseMessage resp = client.GetAsync($"api/Account/UserInfo").Result;
            try
            {
                resp.EnsureSuccessStatusCode();
                var res = resp.Content.ReadAsAsync<UserInfoViewModel>().Result;
                return res;
            }
            catch (Exception)
            {
                
            }

            return null;
            
        }
        public void Logout()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resp = client.PostAsync($"api/Account/Logout",null).Result;
            try
            {
                resp.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
