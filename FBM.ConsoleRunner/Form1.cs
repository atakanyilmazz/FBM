using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBM.ConsoleRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid id;
            int deneme;
            bool isGuid = Guid.TryParse(textBox1.Text,out id);
            if (isGuid)
            {
                Process[] pname = Process.GetProcessesByName("FBM.Console");
                if (pname.Length == 0)
                {
                    string path = "C:/inetpub/wwwAPI/cgi-bin/FBM.Console.exe";
                    string args = "0 " + id.ToString();
                    ProcessStartInfo p = new ProcessStartInfo(path, args);
                    Process process = Process.Start(p);
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
