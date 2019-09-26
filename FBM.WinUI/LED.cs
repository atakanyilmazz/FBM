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

    public partial class LED : Form
    {
        public LED()
        {
            InitializeComponent();
        }
        DllFunctions _func = new DllFunctions();
        private bool isRgb = false;

        private void LED_Load(object sender, EventArgs e)
        {
            _func.SendLog("Initalize", _func.Initalize(null).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _func.LampsOff();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LampsOnDTO dto = new LampsOnDTO();
            dto.CastleNo = Convert.ToInt32(textBox1.Text);
            dto.Color = colorPickEdit1.Color;
            _func.LampsOn(new List<LampsOnDTO>() { dto });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = Color.Red;
                list.Add(dto);
            }
            _func.LampsOn(list);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = Color.Green;
                list.Add(dto);
            }
            _func.LampsOn(list);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = Color.Blue;
                list.Add(dto);
            }
            _func.LampsOn(list);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = colorPickEdit1.Color;
                list.Add(dto);
            }
            _func.LampsOn(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 18; i++) {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                if (i<6)
                {
                    dto.Color = Color.Blue;
                }
                else if (i<12)
                {
                    dto.Color = Color.Orange;
                }
                else
                {
                    dto.Color = Color.DarkBlue;
                }

                list.Add(dto);
            }
            _func.LampsOn(list);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (isRgb == false)
            {
                isRgb = true;
                rgbLoop();
            }
            else
            {
                isRgb = false;
            }
            
        }

        private async void rgbLoop()
        {
            while (isRgb)
            {
                RGBColor(Color.Red);
                await Task.Delay(2000);
                RGBColor(Color.Green);
                await Task.Delay(2000);
                RGBColor(Color.Blue);
                await Task.Delay(2000);
            }
            
        }

        private void RGBColor(Color c)
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = c;
                list.Add(dto);
            }
            _func.LampsOn(list);
        }
    }
}
