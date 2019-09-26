using FBM.Data;
using FBM.Data.DTO;
using FBM.Data.Entity;
using FBM.Data.Entity.Station;
using FBM.Data.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBM.WinUI
{
    public partial class GoalForm : Form
    {
        public GoalForm()
        {
            InitializeComponent();
        }
        DllFunctions _func = new DllFunctions();
        DbmDbContext db = new DbmDbContext();
        public bool listening = false;
        List<Ldr> ldrList;
        private void GoalForm_Load(object sender, EventArgs e)
        {
            _func.Initalize(null);
            ldrList = db.Ldr.ToList();
        }
        public Castle GetCastleByCastleLdrPoint(BallPassedDTO ballPassedDTO)
        {
            if (ballPassedDTO.BallPassedLdrItems.Count < 2)
            {
                throw new Exception("Hatalı nesne geçişi");
            }
            List<BallPassLdrPointItem> ballPassLdrPointItems = new List<BallPassLdrPointItem>() { new BallPassLdrPointItem(Axis.X), new BallPassLdrPointItem(Axis.Y) };
            foreach (BallPassedLdrItem ballPassedLdrItem in ballPassedDTO.BallPassedLdrItems.OrderBy(x => x.Ldr.LdrUnitNo).ToList())
            {
                int beforePoint = GetLdrBeforePoint(ballPassedLdrItem.Ldr);
                int startLdrPoint = beforePoint + ballPassedLdrItem.FirstLdrPoint;
                int LastLdrPoint = beforePoint + ballPassedLdrItem.LastLdrPoint;
                if (ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.FirstPoint < startLdrPoint).Any())
                {
                    ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.FirstPoint < startLdrPoint).FirstOrDefault().FirstPoint = startLdrPoint;
                }
                if (ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.LastPoint < LastLdrPoint).Any())
                {
                    ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.LastPoint < LastLdrPoint).FirstOrDefault().LastPoint = LastLdrPoint;
                }
            }
            if (ballPassLdrPointItems.Any(x => x.FirstPoint == 0 || x.LastPoint == 0))
            {
                throw new Exception("Hatalı nesne geçişi 2");
            }
            BallPassLdrPointItem xItem = ballPassLdrPointItems.Where(x => x.Axis == Axis.X).First();
            BallPassLdrPointItem yItem = ballPassLdrPointItems.Where(x => x.Axis == Axis.Y).First();
            List<Castle> castleList = new List<Castle>();
            castleList.AddRange(db.CastleLdrPoint.Where(x => x.Axis == xItem.Axis &&
            x.StartPoint <= xItem.FirstPoint && x.EndPoint >= xItem.FirstPoint &&
            x.StartPoint <= xItem.LastPoint && x.EndPoint >= xItem.LastPoint).Select(x => x.Castle).ToList());
            castleList.AddRange(db.CastleLdrPoint.Where(x => x.Axis == yItem.Axis &&
            x.StartPoint <= yItem.FirstPoint && x.EndPoint >= yItem.FirstPoint &&
            x.StartPoint <= yItem.LastPoint && x.EndPoint >= yItem.LastPoint).Select(x => x.Castle).ToList());
            Guid id = castleList.GroupBy(x => x.Id).Select(g => new { g.Key, Count = g.Count() }).ToList().Where(x => x.Count == 2).Select(x => x.Key).FirstOrDefault();
            if (id != null || id != Guid.Empty)
            {
                Castle castle = castleList.Where(x => x.Id == id).FirstOrDefault();
                return castle;
            }
            throw new Exception("Hatalı castle ve castle point eşleşmesi");
        }
        public int GetLdrBeforePoint(Ldr ldr)
        {
            int beforeLdrCount = db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition).Any() ? db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition)
                .Sum(x => x.LaserCount) : 0;
            return beforeLdrCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listening = true;
            listeningMet();
        }
        public async void listeningMet()
        {
            while (listening)
            {
                while (!_func.IsBallPast())
                {
                    if (listening == false)
                    {
                        break;
                    }
                    await Task.Delay(100);
                }
                if (listening == false)
                {
                    break;
                }
                BallPassStruct ballpassItem = _func.GetPassedBallInfo();
                if (ballpassItem != null)
                {
                    BallPassedDTO ballPassed = new BallPassedDTO();
                    ballPassed.BallSpeed = ballpassItem.ballTime;
                    for (int k = 0; k < ldrList.Count; k++)
                    {
                        if (ballpassItem.LDR[k] != 0)
                        {
                            BallPassedLdrItem ballPassedLdrItem = new BallPassedLdrItem();
                            ballPassedLdrItem.Ldr = ldrList.Where(x => x.LdrUnitNo == k).FirstOrDefault();
                            if (ballPassedLdrItem.Ldr == null)
                            {
                                throw new Exception("Ldrler düzgün eklenmemiş");
                            }
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
                    try
                    {
                        Castle goalCastle = null;
                        if (ballPassed.BallPassedLdrItems.Count() > 1)
                        {
                            goalCastle = GetCastleByCastleLdrPoint(ballPassed);
                        }
                        if (goalCastle != null)
                        {
                            label2.Text = String.Format("{0} , {1}", goalCastle.CastlePosition.ToString(), goalCastle.CastleFloor.ToString());
                        }
                        else
                        {
                            label2.Text = "Kale tanımlı değil";
                        }
                    }
                    catch (Exception)
                    {
                        label2.Text = "Hatalı Geçiş";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listening = false;
        }
    }
}