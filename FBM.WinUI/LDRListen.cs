using FBM.Data.DTO;
using FBM.Data.Entity.Station;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBM.WinUI
{
    public partial class LDRListen : Form
    {
        DllFunctions _func = new DllFunctions();
        bool isListening = false;
        public LDRListen()
        {
            InitializeComponent();
            _func.Initalize(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Listening";
            isListening = true;
            listen();
        }
        public async void listen()
        {
            while (isListening)
            {
                if (_func.IsBallPast())
                {
                    listBox1.Items.Insert(0, String.Format("Time -- {0}", DateTime.Now.ToString("hh:mm:ss.FFF")));
                    BallPassedDTO ballPassed = new BallPassedDTO();
                    BallPassStruct ballpassItem = _func.GetPassedBallInfo();
                    if (ballpassItem != null)
                    {
                        ballPassed.BallSpeed = ballpassItem.ballTime;
                        listBox1.Items.Insert(0, String.Format("BallTime -- {0}", ballPassed.BallSpeed));
                        
                        for (int k = 0; k < 40; k++)
                        {
                            if (ballpassItem.LDR[k] != 0)
                            {
                                BallPassedLdrItem ballPassedLdrItem = new BallPassedLdrItem();
                                ballPassedLdrItem.Ldr = new Ldr() { LdrUnitNo = k };
                                ballPassedLdrItem.BinaryValue = Convert.ToString(ballpassItem.LDR[k], 2);
                                string tempData = ballPassedLdrItem.BinaryValue;
                                while (tempData.Length < 8)
                                {
                                    tempData = "0" + tempData;
                                }
                                ballPassedLdrItem.BinaryValue = tempData;
                                ballPassed.BallPassedLdrItems.Add(ballPassedLdrItem);
                            }
                        }
                    }
                    foreach (var item in ballPassed.BallPassedLdrItems)
                    {
                        
                        item.BinaryValue.IndexOf('1');
                        item.BinaryValue.LastIndexOf('1');
                        listBox1.Items.Insert(0,String.Format("{0} - {1}", item.Ldr.LdrUnitNo, item.BinaryValue));
                    }
                    listBox1.Items.Insert(0,String.Format("------------------"));
                    
                }
                await Task.Delay(100);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Stopped";
            isListening = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
