using FBM.Data;
using FBM.Data.DTO;
using FBM.Data.Entity;
using FBM.Data.Entity.Players;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using FBM.Data.Enum;
using FBM.Dll.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FBM.Console
{
    public class Program
    {
        static DllFunctions _func = new DllFunctions();
        static DbmDbContext db = new DbmDbContext();
        static List<Station> _stations = new List<Station>();
        [DllImport("Kernel32")]
        private static extern void SetConsoleCtrlHandler(EventHandler handler);
        private delegate void EventHandler();
        static EventHandler _handler;
        private static void OnClose()
        {
            ShutDown();
            _func.Revoke();
        }
        static void Main(string[] args)
        {
            _handler += new EventHandler(OnClose);
            SetConsoleCtrlHandler(_handler);
            if (args.Count() == 0)
            {
                args = new string[1];
                args[0] = "2a569f44-edf5-e711-80ce-005056b9d9cf";
            }
            //FBM_Request request = (FBM_Request)Enum.Parse(typeof(FBM_Request), args[0]);
            FBM_Request request = FBM_Request.REQUEST_START_TRAINING;
            switch (request)
            {
                case FBM_Request.REQUEST_START_TRAINING:
                    Guid playerTrainingId;
                    if (Guid.TryParse(args[0], out playerTrainingId))
                    {
                        StartTraining(playerTrainingId);
                    }
                    break;
                case FBM_Request.REQUEST_MIX_ON:
                    ConnectDevice();
                    System.Console.WriteLine(_func.MixOn(Convert.ToInt32(args[1])));
                    break;
                case FBM_Request.REQUEST_MIX_OFF:
                    ConnectDevice();
                    System.Console.WriteLine(_func.MixOff(Convert.ToInt32(args[1])));
                    break;
                case FBM_Request.REQUEST_GET_LDR_DEVICE_CNT:
                    ConnectDevice();
                    System.Console.WriteLine(_func.GetLdrDevicesCount());
                    break;
                case FBM_Request.REQUEST_GET_STATION_DEVICE_CNT:
                    ConnectDevice();
                    System.Console.WriteLine(_func.GetStationDevicesCount());
                    break;
                case FBM_Request.REQUEST_RELEASE:
                    ConnectDevice();
                    System.Console.WriteLine(_func.ReleaseBall(Convert.ToInt32(args[1])));
                    break;
                case FBM_Request.REQUEST_LAMPS_OFF:
                    ConnectDevice();
                    _func.LampsOff();
                    break;
                case FBM_Request.REQUEST_SET_MOTORS:
                    ConnectDevice();
                    List<byte> x = new List<byte>();
                    x.Add(Convert.ToByte(args[1]));
                    x.Add(Convert.ToByte(args[2]));
                    x.Add(Convert.ToByte(args[3]));
                    x.Add(Convert.ToByte(args[4]));
                    x.Add(Convert.ToByte(args[5]));
                    System.Console.WriteLine(_func.SetMotor(x));
                    break;
                case FBM_Request.REQUEST_GET_MOTOR_STATUS:
                    ConnectDevice();
                    List<byte> res = _func.GetMotor(Convert.ToInt32(args[1]));
                    foreach (byte val in res)
                    {
                        System.Console.WriteLine(val);
                    }
                    break;
            }
        }
        private static void StartTraining(Guid PlayerTrainingId)
        {
            System.Console.WriteLine("Program Başlatılıyor");
            System.Console.WriteLine("live data siliniyor");
            DeleteLiveData();
            System.Console.WriteLine("live data silindi");
            System.Console.WriteLine("Antreman Aranıyor");
            PlayerTraining playerTraining = db.PlayerTraining.Find(PlayerTrainingId);
            if (playerTraining == null)
            {
                System.Console.WriteLine("Antreman Bulunamadı Program Kapatılacak " + PlayerTrainingId.ToString());
                System.Console.ReadKey();
                Environment.Exit(0);
            }
            System.Console.WriteLine("Antreman bulundu");

            List<TrainLog> logToDelete = db.TrainLog.Where(x => x.PlayerTrainingId == playerTraining.Id).ToList();
            foreach (var item in logToDelete)
            {
                db.TrainLog.Remove(item);
            }
            db.SaveChanges();
            if (playerTraining == null)
            {
                return;
            }
            Player player = playerTraining.Player;
            Training training = playerTraining.Training;
            if (player == null || training == null)
            {
                return;
            }
            LiveTraining liveTraining = new LiveTraining()
            {
                Id = Guid.NewGuid(),
                isLive = true,
                isNew = true,
                PlayerTrainingId = playerTraining.Id,
                StartDate = DateTime.Now,
                LiveStatus = LiveStatus.Starting
            };
            db.LiveTraining.Add(liveTraining);
            db.SaveChanges();

            training.Target = db.Target.Where(x => x.TrainingId == training.Id).ToList();
            ConnectDevice();
            System.Console.WriteLine("Donanıma bağlanıldı");
            System.Console.WriteLine("\n");
            _func.LampsOff();
            System.Console.WriteLine("Işıklar Kapandı");
            System.Console.WriteLine("\n");

            List<Target> targetList = training.Target.ToList();
            System.Console.WriteLine("Target Listesi Alındı");
            System.Console.WriteLine("\n");
            SetMotor(targetList[0].Throwing);
            SetMotor(targetList[0].Throwing);
            SetMotor(targetList[0].Throwing);

            System.Console.WriteLine("Toplar Kontorol Ediliyor");
            CheckBalls();
            System.Console.WriteLine("Toplar Kontorol Edildi");
            System.Console.WriteLine("\n");
            List<Ldr> ldrList = db.Ldr.ToList();
            System.Console.WriteLine("Ldr Listesi Alındı");
            System.Console.WriteLine("\n");
            bool isFirst = true;
            DateTime thrownTime = default(DateTime);
            
            for (int i = 0; i < targetList.Count; i++)
            {
                Target target = targetList[i];
                if (isFirst)
                {
                    isFirst = false;
                    SetMotor(target.Throwing);
                    SetMotor(target.Throwing);
                    SetMotor(target.Throwing);
                    System.Console.WriteLine("Motorlara Hız Verildi");
                    System.Console.WriteLine("\n");
                }
                
                while (!CheckMotor(target.Throwing))
                {
                    SetMotor(target.Throwing);
                    System.Console.WriteLine("Hız Kontrolü Yapılmakta");
                    System.Console.WriteLine("\n");
                    Thread.Sleep(100);
                }
                System.Console.WriteLine("Motorlar Istenen Hızda");
                System.Console.WriteLine("\n");
                Castle targetCastle = target.Castle;
                for (int j = 0; j < target.ThrowingCount; j++)
                {
                    Thread.Sleep(Convert.ToInt32(training.ThrowWaitingTime) * 1000);
                    bool status = ThrowBall(target).Result;
                    if (status)
                    {
                        System.Console.WriteLine("Top Atıldı");
                        //Task.Delay(1000);
                        _stations[target.Throwing.Motor.StationNo].BallCount--;
                        FillBalls(target.Throwing.Motor.StationNo);
                        System.Console.WriteLine($"{target.Throwing.Motor.StationNo}. Ünite Kalan Top Sayısı {GetCurrentBallCount(_stations[target.Throwing.Motor.StationNo].BallCount)}");
                        System.Console.WriteLine("\n");
                        TrainLog forNoting = db.TrainLog.Where(x => x.isSuccess == true).FirstOrDefault();
                        if (forNoting != null)
                        {
                            db.Entry(forNoting).Entity.Speed = forNoting.Speed + 1;
                            db.SaveChanges();
                        }
                        SetLiveStatus(liveTraining, LiveStatus.BallThrown, targetCastle, null, target.Throwing.Motor.StationNo);

                        BallStatus ballStatus = BallStatus.Thrown;
                        Thread.Sleep(500);
                        thrownTime = DateTime.Now;
                        MakeColor(target.Castle, null, ballStatus);
                        Thread.Sleep(500);
                        if (targetList.Count != i + 1 && j == target.ThrowingCount - 1)
                        {
                            SetMotor(targetList[i + 1].Throwing);
                        }
                        decimal passedTime = 0;
                        TrainLog logItem = new TrainLog()
                        {
                            PlayerTrainingId = playerTraining.Id,
                            TargetId = target.Id
                        };
                        BallPassStruct ballpassItem = new BallPassStruct();
                        while (ballStatus != BallStatus.Passed && passedTime < training.ThrowTimeOut)
                        {
                            Thread.Sleep(100);
                            passedTime += (decimal)0.1;
                            if (_func.IsBallPast())
                            {
                                ballpassItem = _func.GetPassedBallInfo();
                                byte c = 0;
                                for (int v = 0; v < 200; v++)
                                {
                                    c += ballpassItem.LDR[v];
                                }
                                if (c > 0)
                                {
                                    ballStatus = BallStatus.Passed;
                                }
                            }
                            if (training.ThrowTimeOut / 2 == passedTime)
                            {
                                MakeColor(target.Castle, null, BallStatus.HalfTime);
                                SetLiveStatus(liveTraining, LiveStatus.HalfTime, targetCastle, null, target.Throwing.Motor.StationNo);
                            }
                        }
                        DateTime ballPassTime = DateTime.Now;

                        if (ballStatus == BallStatus.Passed)
                        {
                            if (ballpassItem == null)
                            {
                                ballStatus = BallStatus.Unsuccessful;
                            }
                            else
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
                                        if (goalCastle.Id == targetCastle.Id)
                                        {
                                            ballStatus = BallStatus.Success;
                                            MakeColor(target.Castle, target.Castle, ballStatus);

                                            logItem.isSuccess = true;
                                            logItem.Time = ballPassTime - thrownTime;
                                            logItem.Speed = ballPassed.BallSpeed;
                                            if (logItem.Time.Value.Seconds > training.ThrowWaitingTime / 2)
                                            {
                                                logItem.TimeScore = 3;
                                            }
                                            else
                                            {
                                                logItem.TimeScore = 3 * training.TimeScoreFactor;
                                            }
                                            if (ballPassed.BallSpeed > 5000)
                                            {
                                                logItem.SpeedScore = 3 * training.SpeedScoreFactor;
                                            }
                                            else
                                            {
                                                logItem.SpeedScore = 3;
                                            }
                                            System.Console.WriteLine($"Gol Hız:{ballPassed.BallSpeed} Hız Puanı:{logItem.SpeedScore} Zaman Puanı:{logItem.TimeScore}");
                                            db.TrainLog.Add(logItem);
                                            db.SaveChanges();
                                            SetLiveStatus(liveTraining, LiveStatus.GoalSuccess, targetCastle, null, null);
                                        }
                                        else
                                        {
                                            //Top Geçti Ama Yanlış kale bea
                                            ballStatus = BallStatus.Unsuccessful;
                                            MakeColor(target.Castle, goalCastle, ballStatus);
                                            logItem.isSuccess = false;
                                            logItem.TimeScore = 0;
                                            logItem.SpeedScore = 0;
                                            System.Console.WriteLine($"Gol Başarısız Hız:{ballPassed.BallSpeed}");
                                            db.TrainLog.Add(logItem);
                                            db.SaveChanges();
                                            SetLiveStatus(liveTraining, LiveStatus.GoalUnSuccess, targetCastle, goalCastle, null);
                                        }
                                    }
                                    else
                                    {
                                        logItem.isSuccess = false;
                                        logItem.TimeScore = 0;
                                        logItem.SpeedScore = 0;
                                        System.Console.WriteLine("Kale tanımlı değil");
                                        MakeColor(target.Castle, null, BallStatus.Passed);
                                        db.TrainLog.Add(logItem);
                                        db.SaveChanges();
                                        SetLiveStatus(liveTraining, LiveStatus.GoalUnSuccess, targetCastle, null, null);
                                    }
                                }
                                catch (Exception)
                                {
                                    MakeColor(target.Castle, null, BallStatus.Passed);
                                    logItem.isSuccess = false;
                                    logItem.TimeScore = 0;
                                    logItem.SpeedScore = 0;
                                    db.TrainLog.Add(logItem);
                                    db.SaveChanges();
                                    SetLiveStatus(liveTraining, LiveStatus.GoalUnSuccess, targetCastle, null, null);
                                    System.Console.WriteLine("Hatalı geçiş");
                                }
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Zaman Geçti");
                            MakeColor(target.Castle, null, BallStatus.Passed);
                            logItem.isSuccess = false;
                            logItem.TimeScore = 0;
                            logItem.SpeedScore = 0;
                            db.TrainLog.Add(logItem);
                            db.SaveChanges();
                            SetLiveStatus(liveTraining, LiveStatus.GoalUnSuccess, targetCastle, null, null);
                        }
                        ballStatus = BallStatus.Out;
                    }
                    else
                    {
                        System.Console.WriteLine($"Top Atılamadı LDR {_func.GetLdrCount()}");
                        // Top Fırlatılamadı ne yapılcaksa onu yap. şimdilik bir sonraki atışa geçiliyor
                        isFirst = true;
                        continue;
                    }
                }
            }
            Thread.Sleep(3000);
            SetLiveStatus(liveTraining, LiveStatus.End, null, null, null);
            ShutDown();
            if (Debugger.IsAttached)
            {
                System.Console.ReadKey();
            }
            Environment.Exit(0);
        }
        private static void CheckBalls()
        {
            for (int i = 0; i < 8; i++)
            {
                _func.MixOn(i);
            }
            StartingAnimation();
            for (int i = 0; i < 8; i++)
            {
                Station station = new Station();
                Flag flag = _func.GetFlag(i);
                if (flag.Ball1 == false)
                {
                    station.HasBall = false;
                    station.BallCount = 0;
                }
                else
                {
                    station.HasBall = true;
                    if (flag.Ball3 == false)
                    {
                        station.BallCount = -1;
                    }
                    else
                    {
                        station.BallCount = 4;
                    }
                }
                _stations.Add(station);
            }
        }

        private static void StartingAnimation()
        {


            BlinkColor(Color.Red,3,0.2);
            BlinkColor(Color.Yellow,3,0.2);
            BlinkColor(Color.Green, 3, 0.2);



            //int sayac = 0;
            //double saniye = 10;
            //while (saniye>0)
            //{
            //    List<LampsOnDTO> list = new List<LampsOnDTO>();
            //    for (int i = 0; i < 71; i++)
            //    {
            //        LampsOnDTO dto = new LampsOnDTO();
            //        dto.CastleNo = i;
            //        dto.Color = Color.FromArgb(255-sayac,0,0);
            //        list.Add(dto);
            //    }
            //    _func.LampsOn(list);
            //    sayac += 5;
            //    if (sayac>255)
            //    {
            //        sayac = 255;
            //    }
            //    saniye -= 0.2;
            //    Thread.Sleep(200);
            //}
            //_func.LampsOff();



        }

        private static void BlinkColor(Color c,double s,double s2)
        {
            int sayac = 0;
            double saniye = s;
            while (saniye > 0)
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
                sayac += Convert.ToInt32(255/(s/s2));
                if (sayac > 255)
                {
                    sayac = 255;
                }
                saniye -= s2;
                Thread.Sleep(Convert.ToInt32(s2*1000));
            }
            _func.LampsOff();
        }

        private static void ShutDown()
        {
            List<LampsOnDTO> list = new List<LampsOnDTO>();
            for (int i = 0; i < 71; i++)
            {
                LampsOnDTO dto = new LampsOnDTO();
                dto.CastleNo = i;
                dto.Color = Color.Red;
                list.Add(dto);
            }
            for (int i = 0; i < 10; i++)
            {
                _func.LampsOn(list);
                Thread.Sleep(200);
                _func.LampsOff();
            }
            
            List<byte> values = new List<byte> { 0, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 1, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 2, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 3, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 4, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 5, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 6, 6, 0, 0, 0 };
            _func.SetMotor(values);
            values = new List<byte> { 7, 6, 0, 0, 0 };
            _func.SetMotor(values);
            _func.MixOff(0);
            _func.MixOff(1);
            _func.MixOff(2);
            _func.MixOff(3);
            _func.MixOff(4);
            _func.MixOff(5);
            _func.MixOff(6);
            _func.MixOff(7);
            Task.Delay(10000);
            
        }
        private static Task<bool> ThrowBall(Target target)
        {
            if (_stations[target.Throwing.Motor.StationNo].HasBall == false)
            {
                System.Console.WriteLine($"{target.Throwing.Motor.StationNo}. Ünite Top Yok Kontrol Ediliyor");
                FillBalls(target.Throwing.Motor.StationNo);
                if (_stations[target.Throwing.Motor.StationNo].HasBall == false)
                {
                    System.Console.WriteLine($"{target.Throwing.Motor.StationNo}. Ünite Top Atılamadı Ünitede Top Bulunmuyor");
                    return Task.FromResult(false);
                }
            }
            System.Console.WriteLine($"{target.Throwing.Motor.StationNo}. Ünite Mevcut Top Sayısı {GetCurrentBallCount(_stations[target.Throwing.Motor.StationNo].BallCount)}");
            bool status = _func.ReleaseBall(target.Throwing.Motor.StationNo);
            if (status == false)
            {

            }
            return Task.FromResult(status);
        }
        private static string GetCurrentBallCount(int? count)
        {
            return ((count < 0) ? "Bilinmiyor" : count.ToString());
        }
        private static bool FillBalls(int stationNo)
        {
            Flag flag = _func.GetFlag(stationNo);
            if (flag.Ball3 == true)
            {
                _stations[stationNo].HasBall = true;
                _stations[stationNo].BallCount = 4;
                if (flag.Mix == false)
                {
                    _func.MixOn(stationNo);
                }
                return _stations[stationNo].HasBall;
            }
            else if (flag.Ball1 == true)
            {
                _stations[stationNo].HasBall = true;
                if (flag.Mix == false)
                {
                    _func.MixOn(stationNo);
                }
                return _stations[stationNo].HasBall;
            }
            else if (flag.Mix == false)
            {
                _func.MixOn(stationNo);
                Task.Delay(5000);
            }

            flag = _func.GetFlag(stationNo);
            if (flag.Ball3 == true)
            {
                _stations[stationNo].HasBall = true;
                _stations[stationNo].BallCount = 4;
            }
            else
            {
                if (flag.Ball1 == false)
                {
                    _stations[stationNo].HasBall = false;
                    _stations[stationNo].BallCount = 0;
                }
                else
                {
                    _stations[stationNo].HasBall = true;
                }
            }
            return _stations[stationNo].HasBall;
        }
        private async static void BeSureHasBalls(Target target)
        {
            int sayac = 10;
            x:
            Flag flag = _func.GetFlag(target.Throwing.Motor.StationNo);
            if (sayac > 20)
            {
                if (flag.Ball1 == true)
                {
                    _stations[target.Throwing.Motor.StationNo].HasBall = true;
                    if (flag.Ball3 == false)
                    {
                        _stations[target.Throwing.Motor.StationNo].BallCount = 3;
                    }
                    else
                    {
                        _stations[target.Throwing.Motor.StationNo].BallCount = -1;
                    }
                }
                else
                {
                    _stations[target.Throwing.Motor.StationNo].HasBall = false;
                    _stations[target.Throwing.Motor.StationNo].BallCount = 0;
                }

            }
            if (sayac != 0)
            {

                if (flag.Ball3 == false)
                {
                    if (flag.Mix == true)
                    {
                        sayac++;
                    }
                    _func.MixOn(target.Throwing.Motor.StationNo);
                }
                else
                {
                    sayac--;
                    await Task.Delay(500);
                }
                goto x;
            }
        }
        private static void ConnectDevice()
        {
            _func.Initalize(null);
        }
        private static void DeleteLiveData()
        {
            List<LiveTraining> ltList = db.LiveTraining.ToList();
            System.Console.WriteLine($"Bulunan Veri adet {ltList.Count}");
            foreach (var item in ltList)
            {
                System.Console.WriteLine($"nesne {item.Id} silindi");
                db.Entry(item).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }
       static List<Castle> caslist;
        public static Castle GetCastleByCastleLdrPoint(BallPassedDTO ballPassedDTO)
        {
            if (ballPassedDTO.BallPassedLdrItems.Count < 2)
            {
                throw new Exception("Hatalı nesne geçişi");
            }
            Castle goal = new Castle();

            BallPassedLdrItem xldr = ballPassedDTO.BallPassedLdrItems.Where(x => x.Ldr.Axis == Axis.X).FirstOrDefault();
            BallPassedLdrItem yldr = ballPassedDTO.BallPassedLdrItems.Where(x => x.Ldr.Axis == Axis.Y).FirstOrDefault();

            int xpoint = GetLdrBeforePoint(xldr.Ldr) + xldr.FirstLdrPoint;
            int ypoint = GetLdrBeforePoint(yldr.Ldr) + yldr.FirstLdrPoint;

            caslist = db.Castle.Where(x=>x.WallPosition == xldr.Ldr.WallPosition).ToList();
            foreach (Castle item in caslist)
            {
                if (item.CastleLdrPoint.Where(x=> x.StartPoint<=xpoint && x.EndPoint>= xpoint && x.Axis == Axis.X).Any() && item.CastleLdrPoint.Where(x => x.StartPoint <= ypoint && x.EndPoint >= ypoint && x.Axis == Axis.Y).Any())
                {
                    goal = item;
                    break;
                }
            }
        

            return goal;
        }
        public static int GetLdrBeforePoint(Ldr ldr)
        {
            int beforeLdrCount = db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition).Any() ? db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition)
                .Sum(x => x.LaserCount) : 0;
            return beforeLdrCount;
        }
        public static void SetMotor(Throwing throwing)
        {
            List<byte> values = new List<byte>
            {
                Convert.ToByte(throwing.Motor.StationNo),
                Convert.ToByte(throwing.ThrowBallAltitude.Motor1State),
                Convert.ToByte(throwing.ThrowBallAltitude.Motor2State),
                Convert.ToByte(throwing.ThrowBallAngle.MotorLeftSpeed),
                Convert.ToByte(throwing.ThrowBallAngle.MotorRightSpeed)
            };
            _func.SetMotor(values);
        }
        public static bool CheckMotor(Throwing throwing)
        {
            bool isOk = true;
            List<byte> motorStatus = _func.GetMotor(throwing.Motor.StationNo);
            int motorAltitude1 = Convert.ToInt32(motorStatus[0]);
            int motorAltitude2 = Convert.ToInt32(motorStatus[1]);
            int motorLeftSpeed = Convert.ToInt32(motorStatus[2]);
            int motorRightSpeed = Convert.ToInt32(motorStatus[3]);
            //if (motorAltitude1 < throwing.ThrowBallAltitude.Motor1State - 3)
            //{
            //    isOk = false;
            //}
            if (motorLeftSpeed < throwing.ThrowBallAngle.MotorLeftSpeed - 25)
            {
                isOk = false;
            }
            if (motorRightSpeed < throwing.ThrowBallAngle.MotorRightSpeed - 25)
            {
                isOk = false;
            }
            //if (!(motorAltitude1 - GetTolerans(motorAltitude1) <= throwing.ThrowBallAltitude.Motor1State &&
            //    motorAltitude1 + GetTolerans(motorAltitude1) >= throwing.ThrowBallAltitude.Motor1State))
            //{
            //    isOk = false;
            //}
            //if (!(motorLeftSpeed - GetTolerans(motorLeftSpeed) <= throwing.ThrowBallAngle.MotorLeftSpeed &&
            //    motorLeftSpeed + GetTolerans(motorLeftSpeed) >= throwing.ThrowBallAngle.MotorLeftSpeed))
            //{
            //    isOk = false;
            //}
            //if (!(motorRightSpeed - GetTolerans(motorRightSpeed) <= throwing.ThrowBallAngle.MotorRightSpeed &&
            //    motorRightSpeed + GetTolerans(motorRightSpeed) >= throwing.ThrowBallAngle.MotorRightSpeed))
            //{
            //    isOk = false;
            //}
            return isOk;
        }
        public static int GetTolerans(int val)
        {
            return (val / 100) * 10;
        }
        public static void MakeColor(Castle targetCastle, Castle goalCastle, BallStatus bs)
        {
            _func.LampsOff();
            List<LampsOnDTO> vm = new List<LampsOnDTO>();
            LampsOnDTO l1 = new LampsOnDTO()
            {
                CastleNo = targetCastle.CastleNo
            };
            LampsOnDTO l2 = new LampsOnDTO();

            switch (bs)
            {
                case BallStatus.Thrown:
                    l1.Color = Color.Blue;
                    vm.Add(l1);
                    _func.LampsOn(vm);
                    break;
                case BallStatus.Success:
                    l1.Color = Color.Green;
                    vm.Add(l1);
                    _func.LampsOn(vm);
                    break;
                case BallStatus.Unsuccessful:
                    l1.Color = Color.Red;
                    l2.CastleNo = goalCastle.CastleNo;
                    l2.Color = Color.Purple;
                    vm.Add(l1);
                    vm.Add(l2);
                    _func.LampsOn(vm);
                    break;
                case BallStatus.HalfTime:
                    l1.Color = Color.Yellow;
                    vm.Add(l1);
                    _func.LampsOn(vm);
                    break;
                default:
                    l1.Color = Color.Red;
                    vm.Add(l1);
                    _func.LampsOn(vm);
                    break;
            }
        }
        public static void SetLiveStatus(LiveTraining entity, LiveStatus liveStatus, Castle c1, Castle c2, int? stationNo)
        {
            db.Entry(entity).Entity.R1 = "-";
            db.Entry(entity).Entity.R2 = "-";
            db.Entry(entity).Entity.StationNo = "";
            //enum wallposition-enum castleposition-enum floor - RGB
            if (c1 != null)
            {
                if (liveStatus == LiveStatus.BallThrown)
                {
                    db.Entry(entity).Entity.R1 = String.Format("C{0}{2}{1}-blue", (int)c1.WallPosition, (int)c1.CastlePosition, (int)c1.CastleFloor);
                    db.Entry(entity).Entity.StationNo = $"T00{stationNo}";
                }
                else if (liveStatus == LiveStatus.HalfTime)
                {
                    db.Entry(entity).Entity.R1 = String.Format("C{0}{2}{1}-yellow", (int)c1.WallPosition, (int)c1.CastlePosition, (int)c1.CastleFloor);
                    db.Entry(entity).Entity.StationNo = $"T00{stationNo}";
                }
                else if (liveStatus == LiveStatus.GoalSuccess)
                {
                    db.Entry(entity).Entity.R1 = String.Format("C{0}{2}{1}-green", (int)c1.WallPosition, (int)c1.CastlePosition, (int)c1.CastleFloor);
                }
                else if (liveStatus == LiveStatus.GoalUnSuccess)
                {
                    db.Entry(entity).Entity.R1 = String.Format("C{0}{2}{1}-red", (int)c1.WallPosition, (int)c1.CastlePosition, (int)c1.CastleFloor);
                    if (c2 != null)
                    {
                        db.Entry(entity).Entity.R2 = String.Format("C{0}{2}{1}-red", (int)c2.WallPosition, (int)c2.CastlePosition, (int)c2.CastleFloor);
                    }
                }
            }
            if (liveStatus == LiveStatus.End)
            {
                db.Entry(entity).Entity.isLive = false;
            }
            db.Entry(entity).Entity.S0C = _stations[0].BallCount.Value;
            db.Entry(entity).Entity.S1C = _stations[1].BallCount.Value;
            db.Entry(entity).Entity.S2C = _stations[2].BallCount.Value;
            db.Entry(entity).Entity.S3C = _stations[3].BallCount.Value;
            db.Entry(entity).Entity.S4C = _stations[4].BallCount.Value;
            db.Entry(entity).Entity.S5C = _stations[5].BallCount.Value;
            db.Entry(entity).Entity.S6C = _stations[6].BallCount.Value;
            db.Entry(entity).Entity.S7C = _stations[7].BallCount.Value;
            db.Entry(entity).Entity.isNew = false;
            db.Entry(entity).Entity.LiveStatus = liveStatus;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}