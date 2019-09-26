using FBM.Dll.Service;
using FBM.Dll.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBM.WinUI
{
    public partial class Managing : Form
    {
        DllFunctions _func = new DllFunctions();
        public Managing()
        {
            InitializeComponent();
            _func.Initalize(null);
        }
        private void device_Click(object sender, EventArgs e)
        {
            lblDevice.Text = _func.GetStationDevicesCount().ToString();
            lblLdr.Text = _func.GetLdrDevicesCount().ToString();
        }
        private void sbM1_ValueChanged(object sender, EventArgs e)
        {
            lblSM1.Text = sbM1.Value.ToString();
        }
        private void sbM2_ValueChanged(object sender, EventArgs e)
        {
            lblSM2.Text = sbM2.Value.ToString();
        }
        private void sbM3_ValueChanged(object sender, EventArgs e)
        {
            lblSM3.Text = sbM3.Value.ToString();
        }
        private void sbM4_ValueChanged(object sender, EventArgs e)
        {
            lblSM4.Text = sbM4.Value.ToString();
        }
        private void GetFlags_Click(object sender, EventArgs e)
        {
            Flag flags = _func.GetFlag(Convert.ToInt32(nudUnitNumber.Value));
            label8.Text = flags.Values;
            checkBox1.CheckState = flags.Ball1 ? CheckState.Checked : CheckState.Unchecked;
            //checkBox2.CheckState = flags.Ball3 ? CheckState.Checked : CheckState.Unchecked;
            checkBox3.CheckState = flags.Release ? CheckState.Checked : CheckState.Unchecked;
            checkBox4.CheckState = flags.Mix ? CheckState.Checked : CheckState.Unchecked;
        }
        private void btnSetMotor_Click(object sender, EventArgs e)
        {
            List<byte> values = new List<byte>
            {
                Convert.ToByte(getUnitNumber()),
                Convert.ToByte(sbM1.Value),
                Convert.ToByte(sbM2.Value),
                Convert.ToByte(sbM3.Value),
                Convert.ToByte(sbM4.Value)
            };
            _func.SetMotor(values);
        }
        private void btnGetMotor_Click(object sender, EventArgs e)
        {
            List<byte> x = _func.GetMotor(getUnitNumber());
            pbM1.Value = x[0];
            sbM1.Value = x[0];
            lblM1.Text = x[0].ToString();
            pbM2.Value = x[1];
            sbM2.Value = x[1];
            lblM2.Text = x[1].ToString();
            pbM3.Value = x[2];
            sbM3.Value = x[2];
            lblM3.Text = x[2].ToString();
            pbM4.Value = x[3];
            sbM4.Value = x[3];
            lblM4.Text = x[3].ToString();
        }
        private void btnMixOff_Click(object sender, EventArgs e)
        {
            _func.MixOff(getUnitNumber());
        }
        private void btnMixOn_Click(object sender, EventArgs e)
        {
            _func.MixOn(getUnitNumber());
        }
        public int getUnitNumber()
        {
            return Convert.ToInt32(nudUnitNumber.Value);
        }
        private void Managing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _func.ReleaseBall(getUnitNumber());
        }
        public bool isLoop;
        private void button2_Click_1(object sender, EventArgs e)
        {
            isLoop = true;
            loop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isLoop = false;
        }
        private async void loop()
        {
            while (isLoop)
            {
                await Task.Delay(1000);
                listBox1.Items.Insert(0, _func.GetLdrCount());
            }
        }
        bool isLinearTest = false;
        int adet;
        private void button4_Click(object sender, EventArgs e)
        {
            isLinearTest = true;
            adet = 0;
            label4.Text = DateTime.Now.ToString();
            LinearTest();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isLinearTest = false;
        }
        public async void LinearTest()
        {
            int maxVal = Convert.ToInt32(textBox1.Text);
            int minVal = Convert.ToInt32(textBox2.Text);
            int stationNum = Convert.ToInt32(getUnitNumber());
            while (isLinearTest)
            {
                List<byte> values = new List<byte>
                {
                    Convert.ToByte(stationNum),
                    Convert.ToByte(maxVal),
                    Convert.ToByte(0),
                    Convert.ToByte(0),
                    Convert.ToByte(0)
                };
                _func.SetMotor(values);
                bool leave = false;
                while (leave == false)
                {
                    await Task.Delay(1000);
                    List<byte> x = _func.GetMotor(stationNum);
                    if (x[0] >= maxVal - 10)
                    {
                        leave = true;
                    }
                    else
                    {
                        _func.SetMotor(values);
                        await Task.Delay(500);
                    }
                }
                values = new List<byte>
                {
                    Convert.ToByte(stationNum),
                    Convert.ToByte(minVal),
                    Convert.ToByte(0),
                    Convert.ToByte(0),
                    Convert.ToByte(0)
                };
                _func.SetMotor(values);
                leave = false;
                while (leave == false)
                {
                    await Task.Delay(1000);
                    List<byte> xy = _func.GetMotor(stationNum);
                    if (xy[0] <= minVal + 5)
                    {
                        leave = true;
                    }
                    else
                    {
                        _func.SetMotor(values);
                       await Task.Delay(500);
                    }
                }
                adet++;
                label7.Text = adet.ToString();
            }
        }

    }
}
