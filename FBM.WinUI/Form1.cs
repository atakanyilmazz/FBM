using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FBM.Data.Entity.Station;
using FBM.Data;
using FBM.Data.Entity.Throw;
using System.Data.Entity.Migrations;

namespace FBM.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            DbmDbContext context = new DbmDbContext();
            context.AltitudeType.AddOrUpdate(
   x => x.Name,
   new AltitudeType { Name = "ToHeat", Desctription = "Kafa Hizası" },
   new AltitudeType { Name = "ToChest", Desctription = "Göğüs Hizası" },
   new AltitudeType { Name = "ToFoot", Desctription = "Ayak Hizası" }
   );
            context.AngleType.AddOrUpdate(
                x => x.Name,
                new AngleType { Name = "ToLeft", Desctription = "Sola Falso" },
                new AngleType { Name = "ToRight", Desctription = "Sağa Falso" },
                new AngleType { Name = "Straight", Desctription = "Düz Atış" }
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new TrainingShow(Guid.Empty, Guid.Empty, Guid.Empty);
            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new LED();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new Managing();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new LDRListen();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form = new GoalForm();
            form.Show();
        }
    }
}