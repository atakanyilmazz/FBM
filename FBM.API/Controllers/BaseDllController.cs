using FBM.Dll.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
namespace FBM.API.Controllers
{
    public class BaseDllController : ApiController
    {
        DllFunctions _func = new DllFunctions();
        [HttpGet, HttpPost]
        public int LdrCount()
        {//96
            int res = 0;
            
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://192.168.1.200:88/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var content = new StringContent(JsonConvert.SerializeObject(96), Encoding.UTF8, "application/json");
            //HttpResponseMessage resp = client.PostAsync($"CGI/CGITest.exe", content).Result;
            //resp.EnsureSuccessStatusCode();
            //var str = resp.Content.ReadAsStringAsync().Result;


            //res = Convert.ToInt32(str);

            return res;
        }

        [HttpGet, HttpPost]
        public int DeviceCount()
        {
            //string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            //string args = "97"; //hex karşılıgı
            //ProcessStartInfo p = new ProcessStartInfo(path, args);
            //p.CreateNoWindow = true;
            //p.UseShellExecute = false;
            //p.RedirectStandardOutput = true;
            //p.RedirectStandardError = true;
            //var process = Process.Start(p);
            //var output = new List<string>();

            //while (process.StandardOutput.Peek() > -1)
            //{
            //    output.Add(process.StandardOutput.ReadLine());
            //}

            //while (process.StandardError.Peek() > -1)
            //{
            //    output.Add(process.StandardError.ReadLine());
            //}
            //process.WaitForExit();
            int res = 0;
            //int.TryParse(output[0], out res);
            return res;
        }
        [HttpGet, HttpPost]
        public bool MixOn(int stationNo)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "101 " + stationNo;
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            bool res = false;
            bool.TryParse(output[0], out res);
            return res;
        }
        [HttpGet, HttpPost]
        public bool MixOff(int stationNo)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "102 " + stationNo;
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            bool res = false;
            bool.TryParse(output[0], out res);
            return res;
        }
        [HttpGet, HttpPost]
        public bool ReleaseBall(int stationNo)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "100 " + stationNo;
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            bool res = false;
            bool.TryParse(output[0], out res);
            return res;
        }
        [HttpGet, HttpPost]
        public bool SetMotor(List<int> values)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = $"99 {values[0]} {values[1]} {values[2]} {values[3]} {values[4]}";
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            bool res = false;
            bool.TryParse(output[0], out res);
            return res;
        }
        [HttpGet, HttpPost]
        public List<byte> GetMotor(int stationNo)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "98 " + stationNo;
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }
            process.WaitForExit();
            List<byte> result = new List<byte>();
            byte res = 0;
            if (byte.TryParse(output[0], out res))
            {
                result.Add(res);
            }
            if (byte.TryParse(output[1], out res))
            {
                result.Add(res);
            }
            if (byte.TryParse(output[2], out res))
            {
                result.Add(res);
            }
            if (byte.TryParse(output[3], out res))
            {
                result.Add(res);
            }
            return result;
        }
        [HttpGet, HttpPost]
        public void LampsOn(int castleNo, Color color)
        {
            //_func.LampsOn(castleNo, color);
        }
        [HttpGet, HttpPost]
        public void LampsOff()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "106";
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.RedirectStandardError = true;
            var process = Process.Start(p);
        }
        [HttpGet, HttpPost]
        public bool StartTraining(Guid id)
        {
            Process[] pname = Process.GetProcessesByName("FBM.Console");
            if (pname.Length == 0)
            {
                string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
                string args = "0 " + id.ToString();
                //string args = id.ToString();
                ProcessStartInfo p = new ProcessStartInfo(path,args);
                Process process = Process.Start(p);
                return true;
            }
            return false;
        }
        public void DeviceInfo()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/cgi-bin/FBM.Console.exe");
            string args = "107";
            ProcessStartInfo p = new ProcessStartInfo(path, args);
            
            var process = Process.Start(p);
        }
    }
}
