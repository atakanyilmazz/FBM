using FBM.Data.DTO;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using FBM.Data.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FBM.Data.Entity.Players;
using MetroFramework.Forms;
using System.Diagnostics;
using FBM.Data.API;

namespace FBM.WinUI
{
    public partial class TrainingShow : MetroForm
    {
        DllFunctions _func = new DllFunctions();
        #region Değişlkenler
        private static Training _training;
        private static List<Ldr> _ldrList { get; set; }
        private static List<Castle> _castleList { get; set; }
        private static List<CastleLdrPoint> _castleLdrPoint { get; set; }
        private Player _player { get; set; }
        private Station _station { get; set; }
        private Castle _targetCastle { get; set; }
        private BallStatus BallStatus { get; set; }
        private PlayerTraining _playerTraining { get; set; }
        private DateTime _ballPassTime { get; set; }
        public int Tolerans { get { return 10; } }
        #endregion
        public TrainingShow(Guid stationId, Guid trainingId, Guid playerId)
        {
            InitializeComponent();
            stationId = ClientServiceProxy.StationService().Get().FirstOrDefault().Id;
            if (Debugger.IsAttached)
            {
                trainingId = ClientServiceProxy.TrainingService().Get().Where(x => x.Desctription == "DEMO").FirstOrDefault().Id;
                playerId = ClientServiceProxy.PlayerService().Get().Where(x => x.Desctription == "DEMO").FirstOrDefault().Id;
            }
            FillLists(stationId, trainingId, playerId);
        }
        private void TrainingShow_Load(object sender, EventArgs e)
        {
            GetGrids();
            this.BallStatus = BallStatus.Out;

            _func.Initalize(null);
            //if (!(Cef.IsInitialized))
            //{
            //    Cef.Initialize(new CefSettings());
            //}
            //ChromiumWebBrowser browser = new ChromiumWebBrowser("http://192.168.0.253/ImageViewer?Mode=Motion&Resolution=640x480&Quality=Standard&Interval=10");
            //browser.Width = 400;
            //browser.Height = 300;
            //browser.Top = 0;
            //panelControl1.Controls.Add(browser);
            //this.StartTraining();
        }
        public async void StartTraining()
        {
            _playerTraining = new PlayerTraining
            {
                Id = Guid.NewGuid(),
                PlayerId = _player.Id,
                TrainingId = _training.Id,
                TrainingDate = DateTime.Now
            };
            ClientServiceProxy.PlayerTrainingService().Post(_playerTraining);
            bool isFirst = true;
            int successGoalCount = 0;
            int unsuccessGoalCount = 0;
            DateTime thrownTime = default(DateTime);
            List<Target> targetList = _training.Target.ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                Target target = targetList[i];
                if (isFirst)
                {
                    isFirst = false;
                    SetMotor(target.Throwing);
                }
                //while (!CheckMotor(target.Throwing))
                //{
                //    await Task.Delay(100);
                //}
                _targetCastle = target.Castle;
                for (int j = 0; j < target.ThrowingCount; j++)
                {
                    await Task.Delay(Convert.ToInt32(_training.ThrowWaitingTime * 1000));
                    bool status = _func.ReleaseBall(target.Throwing.Motor.StationNo);
                    if (status)
                    {
                        BallStatus = BallStatus.Thrown;
                        thrownTime = DateTime.Now;
                        MakeColor(target.Castle, null, false);

                        if (targetList.Count != i + 1 && j == target.ThrowingCount - 1)
                        {
                            SetMotor(targetList[i + 1].Throwing);
                        }
                        decimal passedTime = 0;
                        while (BallStatus != BallStatus.Passed && passedTime < _training.ThrowTimeOut)
                        {
                            await Task.Delay(100);
                            passedTime += (decimal)0.1;
                            if (_func.IsBallPast())
                            {
                                BallStatus = BallStatus.Passed;
                            }
                        }
                        _ballPassTime = DateTime.Now;
                        if (BallStatus == BallStatus.Passed)
                        {
                            BallPassStruct ballpassItem = _func.GetPassedBallInfo();
                            if (ballpassItem == null)
                            {
                                BallStatus = BallStatus.Unsuccessful;
                            }
                            else
                            {
                                BallPassedDTO ballPassed = new BallPassedDTO();
                                ballPassed.BallSpeed = ballpassItem.ballTime;
                                for (int k = 0; k < _ldrList.Count; k++)
                                {
                                    if (ballpassItem.LDR[k] != 0)
                                    {
                                        BallPassedLdrItem ballPassedLdrItem = new BallPassedLdrItem();
                                        ballPassedLdrItem.Ldr = _ldrList.Where(x => x.LdrUnitNo == k).FirstOrDefault();
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
                                    if (ballPassed.BallPassedLdrItems.Count>1)
                                    {
                                        //goalCastle = ClientServiceProxy.CastleService().GetCastleByCastleLdrPoint(ballPassed);
                                    }

                                    TrainLog logItem = new TrainLog()
                                    {
                                        PlayerTrainingId = this._playerTraining.Id,
                                        TargetId = target.Id
                                    };
                                    if (goalCastle != null)
                                    {
                                        if (goalCastle.Id == _targetCastle.Id)
                                        {
                                            BallStatus = BallStatus.Success;
                                            MakeColor(target.Castle, null, true);
                                            
                                            successGoalCount++;
                                            logItem.isSuccess = true;
                                            logItem.Time = _ballPassTime - thrownTime;
                                            if (logItem.Time.Value.Seconds > _training.ThrowWaitingTime / 2)
                                            {
                                                logItem.TimeScore = 3;
                                            }
                                            else
                                            {
                                                logItem.TimeScore = 3 * _training.TimeScoreFactor;
                                            }
                                            if (ballPassed.BallSpeed > 5000)
                                            {
                                                logItem.SpeedScore = 3 * _training.SpeedScoreFactor;
                                            }
                                            else
                                            {
                                                logItem.SpeedScore = 3;
                                            }
                                            lbLogs.Items.Insert(0,  $"Gol Hız:{ballPassed.BallSpeed} Hız Puanı:{logItem.SpeedScore} Zaman Puanı:{logItem.TimeScore}");
                                        }
                                        else
                                        {
                                            //Top Geçti Ama Yanlış kale bea
                                            BallStatus = BallStatus.Unsuccessful;
                                            MakeColor(target.Castle, goalCastle, false);
                                            lbLogs.Items.Insert(0, "Gol Başarısız");
                                            unsuccessGoalCount++;
                                            logItem.isSuccess = false;
                                            logItem.TimeScore = 0;
                                            logItem.SpeedScore = 0;
                                            lbLogs.Items.Insert(0, $"Gol Başarısız Hız:{ballPassed.BallSpeed}");
                                        }
                                    }
                                    else
                                    {
                                        lbLogs.Items.Insert(0, "Kale tanımlı değil");
                                    }
                                    ClientServiceProxy.TrainLogService().Post(logItem);
                                }
                                catch (Exception)
                                {
                                    MakeColor(target.Castle, target.Castle, false);
                                    unsuccessGoalCount++;
                                    lbLogs.Items.Insert(0, "hatalı geçiş");
                                }
                            }
                        }
                        else
                        {
                            //timeOut
                            unsuccessGoalCount++;
                            lbLogs.Items.Insert(0, "Çok Yavaşsın top gitti");
                            MakeColor(target.Castle, target.Castle, false);
                        }
                        SetChartValues(successGoalCount, unsuccessGoalCount);
                        BallStatus = BallStatus.Out;
                    }
                    else
                    {
                        // Top Fırlatılamadı ne yapılcaksa onu yap. şimdilik bir sonraki atışa geçiliyor
                        isFirst = true;
                        continue;
                    }
                }
            }
        }
        private void GetCamera()
        {

        }
        private void FillLists(Guid stationId, Guid trainingId, Guid playerId)
        {
            try
            {
                //_station = ClientServiceProxy.StationService().Get(stationId);
                //if (_station == null)
                //{
                //    throw new Exception("İstasyon Bulunamadı");
                //}
                _training = ClientServiceProxy.TrainingService().Get(trainingId);
                if (_training == null)
                {
                    throw new Exception("Antreman Bulunamadı");
                }
                _player = ClientServiceProxy.PlayerService().Get(playerId);
                if (_player == null)
                {
                    throw new Exception("Oyuncu Bulunamadı");
                }
                _ldrList = ClientServiceProxy.LdrService().Get();
                if (!_ldrList.Any())
                {
                    throw new Exception("Ldrler eklenmeli");
                }
                //_castleList = ClientServiceProxy.CastleService().Get();
                //if (!_castleList.Any())
                //{
                //    throw new Exception("Kaleler eklenmeli");
                //}
                //_castleLdrPoint = ClientServiceProxy.CastleLdrPointService().Get();
                //if (!_castleLdrPoint.Any())
                //{
                //    throw new Exception("Kale konumları eklenmeli");
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata! Sayfa Kapatılacak", MessageBoxButtons.OK);
                this.Close();
            }
        }
        #region GridAndColor
        private void GetGrids()
        {
            for (int i = 0; i < 9; i++)
            {
                dgvW.Rows.Add(new DataGridViewRow());
                dgvE.Rows.Add(new DataGridViewRow());
            }
            for (int i = 0; i < 2; i++)
            {
                dgvN.Rows.Add(new DataGridViewRow());
                dgvS.Rows.Add(new DataGridViewRow());
            }
            dgvW.ClearSelection();
            dgvE.ClearSelection();
            dgvN.ClearSelection();
            dgvS.ClearSelection();
        }
        public void DgvClear(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }
        public void MakeColor(Castle targetCastle, Castle goalCastle, bool isTrueGoal)
        {
            _func.LampsOff();
            DgvClear(dgvE);
            DgvClear(dgvN);
            DgvClear(dgvW);
            DgvClear(dgvS);

            int r = 0, c = 0;
            Color toPaint = isTrueGoal ? Color.Green : Color.Blue;
            //_func.LampsOn(targetCastle.CastleNo, toPaint);
            switch (targetCastle.WallPosition)
            {
                case WallPosition.North:
                    switch (targetCastle.CastleFloor)
                    {
                        case Floor.Top:
                            r = 0;
                            break;
                        case Floor.Bottom:
                            r = 1;
                            break;
                    }
                    c = (Int32)targetCastle.CastlePosition - 1;
                    dgvN.Rows[r].Cells[c].Style.BackColor = toPaint;
                    break;
                case WallPosition.South:
                    switch (targetCastle.CastleFloor)
                    {
                        case Floor.Top:
                            r = 1;
                            break;
                        case Floor.Bottom:
                            r = 0;
                            break;
                    }
                    c = 9 - ((Int32)targetCastle.CastlePosition);
                    dgvS.Rows[r].Cells[c].Style.BackColor = toPaint;
                    break;
                case WallPosition.East:
                    switch (targetCastle.CastleFloor)
                    {
                        case Floor.Top:
                            c = 1;
                            break;
                        case Floor.Bottom:
                            c = 0;
                            break;
                    }
                    r = (Int32)targetCastle.CastlePosition - 1;
                    dgvE.Rows[r].Cells[c].Style.BackColor = toPaint;
                    break;
                case WallPosition.West:
                    switch (targetCastle.CastleFloor)
                    {
                        case Floor.Top:
                            c = 0;
                            break;
                        case Floor.Bottom:
                            c = 1;
                            break;
                    }
                    r = 9 - ((Int32)targetCastle.CastlePosition);
                    dgvW.Rows[r].Cells[c].Style.BackColor = toPaint;
                    break;
            }
            if (goalCastle != null && isTrueGoal == false)
            {
                r = 0; c = 0;
                toPaint = Color.Red;
                //_func.LampsOn(goalCastle.CastleNo, toPaint);
                switch (goalCastle.WallPosition)
                {
                    case WallPosition.North:
                        switch (goalCastle.CastleFloor)
                        {
                            case Floor.Top:
                                r = 0;
                                break;
                            case Floor.Bottom:
                                r = 1;
                                break;
                        }
                        c = (Int32)goalCastle.CastlePosition - 1;
                        dgvN.Rows[r].Cells[c].Style.BackColor = toPaint;
                        break;
                    case WallPosition.South:
                        switch (goalCastle.CastleFloor)
                        {
                            case Floor.Top:
                                r = 1;
                                break;
                            case Floor.Bottom:
                                r = 0;
                                break;
                        }
                        c = 9 - ((Int32)goalCastle.CastlePosition);
                        dgvS.Rows[r].Cells[c].Style.BackColor = toPaint;
                        break;
                    case WallPosition.East:
                        switch (goalCastle.CastleFloor)
                        {
                            case Floor.Top:
                                c = 1;
                                break;
                            case Floor.Bottom:
                                c = 0;
                                break;
                        }
                        r = (Int32)goalCastle.CastlePosition - 1;
                        dgvE.Rows[r].Cells[c].Style.BackColor = toPaint;
                        break;
                    case WallPosition.West:
                        switch (goalCastle.CastleFloor)
                        {
                            case Floor.Top:
                                c = 0;
                                break;
                            case Floor.Bottom:
                                c = 1;
                                break;
                        }
                        r = 9 - ((Int32)goalCastle.CastlePosition);
                        dgvW.Rows[r].Cells[c].Style.BackColor = toPaint;
                        break;
                }
            }
        }
        #endregion
        public void SetMotor(Throwing throwing)
        {
            //List<byte> values = new List<byte>
            //{
            //    throwing.Motor.StationNo,
            //    throwing.ThrowBallAltitude.Motor1State,
            //    throwing.ThrowBallAltitude.Motor2State,
            //    throwing.ThrowBallAngle.MotorLeftSpeed,
            //    throwing.ThrowBallAngle.MotorRightSpeed
            //};
            //_func.SetMotor(values);
        }
        public bool CheckMotor(Throwing throwing)
        {
            bool isOk = true;
            List<byte> motorStatus = _func.GetMotor(throwing.Motor.StationNo);
            int motorAltitude1 = Convert.ToInt32(motorStatus[0]);
            int motorAltitude2 = Convert.ToInt32(motorStatus[1]);
            int motorLeftSpeed = Convert.ToInt32(motorStatus[2]);
            int motorRightSpeed = Convert.ToInt32(motorStatus[3]);
            if (!(motorAltitude1 - GetTolerans(motorAltitude1) <= throwing.ThrowBallAltitude.Motor1State &&
                motorAltitude1 + GetTolerans(motorAltitude1) >= throwing.ThrowBallAltitude.Motor1State))
            {
                isOk = false;
            }
            if (!(motorLeftSpeed - GetTolerans(motorLeftSpeed) <= throwing.ThrowBallAngle.MotorLeftSpeed &&
                motorLeftSpeed + GetTolerans(motorLeftSpeed) >= throwing.ThrowBallAngle.MotorLeftSpeed))
            {
                isOk = false;
            }
            if (!(motorRightSpeed - GetTolerans(motorRightSpeed) <= throwing.ThrowBallAngle.MotorRightSpeed &&
                motorRightSpeed + GetTolerans(motorRightSpeed) >= throwing.ThrowBallAngle.MotorRightSpeed))
            {
                isOk = false;
            }
            return isOk;
        }
        public int GetTolerans(int val)
        {
            return (val / 100) * Tolerans;
        }
        public void SetChartValues(int success, int unsuccess)
        {
            cLogs.Series[0].Points[0].XValue = success;
            cLogs.Series[0].Points[0].YValues[0] = success;
            cLogs.Series[0].Points[1].XValue = unsuccess;
            cLogs.Series[0].Points[1].YValues[0] = unsuccess;
            if (success > 0)
            {
                cLogs.Series[0].Points[0].Label = String.Format("{0} %", Math.Round(Convert.ToDouble(((double)success * (double)100) / (double)((double)success + (double)unsuccess)), 2).ToString());
            }
            else
            {
                cLogs.Series[0].Points[0].Label = "";
            }
            if (unsuccess > 0)
            {
                cLogs.Series[0].Points[1].Label = String.Format("{0} %", Math.Round(Convert.ToDouble(((double)unsuccess * (double)100) / (double)((double)success + (double)unsuccess)), 2).ToString());
            }
            else
            {
                cLogs.Series[0].Points[1].Label = "";
            }
            cLogs.Series[0].Points[0].LegendText = String.Format("Başarılı {0}", success);
            cLogs.Series[0].Points[1].LegendText = String.Format("Başarısız {0}", unsuccess);
        }

        private void cLogs_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Managing();
            frm.Show();
        }
    }
}
