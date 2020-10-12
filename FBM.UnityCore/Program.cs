using FBM.Data;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Throw;
using FBM.Data.Entity.Train;
using FBM.Data.Enum;
using FBM.Dll.Service;
using FBM.Dll.Struct;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FBM.UnityCore
{
    class Program
    {
        static DllFunctions _func = new DllFunctions();
        static DbmDbContext db = new DbmDbContext();
        static List<Station> _stations = new List<Station>();
        static List<LampsOnDTO> vm = new List<LampsOnDTO>();
        static List<LampsDTO> vm2 = new List<LampsDTO>();



        static TcpClient client;
        static NetworkStream stream;
        static StreamWriter writer;
        static StreamReader reader;
        static TcpListener listener;
        static void Main(string[] args)
        {
            vm = null;
            db.ThrowBallAngle.First();
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("192.168.1.200");
                listener = new TcpListener(localAddr, port);
                listener.Start();
                
                String data = null;
                while (true)
                {
                    Console.Write("Waiting for a connection...");
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);

                    // Send Feed Data
                    SendTCP(GetFeedData());
                    Console.WriteLine("-- Feed Sended --");
                    //

                    while (client.Connected)
                    {
                        if (vm != null)
                        {
                            Thread.Sleep(300);
                            GetVm2();
                            Thread.Sleep(300);
                            TaskDTO ltask = new TaskDTO();
                            ltask.taskType = TaskType.Lamps;
                            ltask.jSonValue = vm2;
                            SendTCP(JsonConvert.SerializeObject(ltask));
                            vm = null;
                            vm2 = null;
                            Thread.Sleep(300);
                        }
                        if (stream.DataAvailable)
                        {
                            data = reader.ReadLine();
                            Console.WriteLine("Get :" + data);
                            if (data != null)
                                readData(data);
                        }
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
        public static void SendTCP(string data)
        {
            if (client.Connected)
            {
                writer.WriteLine(data);
                writer.Flush();
                Console.WriteLine("Sended :" + data);
                data = null;
            }
        }
        public static void GetVm2()
        {
            vm2.Clear();
            foreach (var item in vm)
            {
                LampsDTO dto = new LampsDTO();
                dto.CastleNo = item.CastleNo;
                dto.R = item.Color.R;
                dto.G = item.Color.G;
                dto.B = item.Color.B;
                vm2.Add(dto);
            }
        }
        public static void readData(string data)
        {
            TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(data);
            Target target = new Target();
            switch (taskDTO.taskType)
            {
                case TaskType.ThrowSingleBallToCastle:
                    ThrowBallToCastleDTO throwBallToCastleDTO = JsonConvert.DeserializeObject<ThrowBallToCastleDTO>(taskDTO.jSonValue.ToString());
                    target = new Target();
                    target.Throwing = db.Throwing.Where(x => x.Id == throwBallToCastleDTO.throwID).FirstOrDefault();
                    target.Castle = db.Castle.Where(x => x.Id == throwBallToCastleDTO.castleID).FirstOrDefault();
                    //ThrowBall(target);
                    break;
                case TaskType.ThrowSingleBall:
                    ThrowBallDTO throwBallDTO = JsonConvert.DeserializeObject<ThrowBallDTO>(taskDTO.jSonValue.ToString());
                    throwBallDTO.Throwing = db.Throwing.Where(x => x.Id == throwBallDTO.ThrowingID).FirstOrDefault();
                    target = new Target();
                    target.Throwing = throwBallDTO.Throwing;
                    //ThrowBall(target);
                    break;
                case TaskType.Lamps:
                    vm2 = JsonConvert.DeserializeObject<List<LampsDTO>>(taskDTO.jSonValue.ToString());
                    vm = new List<LampsOnDTO>();
                    foreach (LampsDTO item in vm2)
                    {
                        LampsOnDTO lodto = new LampsOnDTO();
                        lodto.CastleNo = item.CastleNo;
                        lodto.Color = Color.FromArgb(item.R, item.G, item.B);
                        vm.Add(lodto);
                    }
                    //_func.LampsOff();
                    //_func.LampsOn(vm);
                    break;
                case TaskType.Kill:
                    client.Close();
                    break;
                default:
                    break;
            }

            
        }
        public static string GetFeedData()
        {
            TaskDTO taskDTO = new TaskDTO();
            taskDTO.taskType = TaskType.Feed;

            FeedDTO dto = new FeedDTO();
            dto.feedCastles = db.Castle.Select(x => new FeedCastleDTO { id = x.Id, CastleNo = x.CastleNo }).OrderBy(x => x.CastleNo).ToList();
            dto.feedMotors = db.Motor.Select(x => new FeedMotorDTO
            {
                id = x.Id,
                MotorNo = x.StationNo,
                feedThrowns = x.Throwing.Select(y => new FeedThrownDTO { id = y.Id }).ToList()
            }).OrderBy(x => x.MotorNo).ToList();
            foreach (FeedMotorDTO item1 in dto.feedMotors)
            {
                foreach (FeedThrownDTO item in item1.feedThrowns)
                {
                    Throwing xx = db.Throwing.Where(x => x.Id == item.id).FirstOrDefault();
                    item.name = xx.Name;
                }
            }
            taskDTO.jSonValue = dto;
            return JsonConvert.SerializeObject(taskDTO);
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
        private static void CheckBalls()
        {
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
        private static string GetCurrentBallCount(int? count)
        {
            return ((count < 0) ? "Bilinmiyor" : count.ToString());
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
        public static void MakeColor(Castle targetCastle, Castle goalCastle, BallStatus bs)
        {
            _func.LampsOff();
            vm = new List<LampsOnDTO>();
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
                    l2.Color = Color.Red;
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
        public static int _throwBall(Target target)
        {
            CheckBalls();
            SetMotor(target.Throwing);
            int time = 0;
            Console.WriteLine("\n");
            while (!CheckMotor(target.Throwing))
            {
                if (time > 5000)
                {
                    Console.WriteLine("Motorlar Istenilen Hıza Ulaşamadı");
                    return -1;
                }
                SetMotor(target.Throwing);
                Console.Write(".");
                Thread.Sleep(100);
                time += 100;
            }
            System.Console.WriteLine("Motorlar Istenen Hızda");
            bool status = ThrowBall(target).Result;
            if (status)
            {
                System.Console.WriteLine("Top Atıldı");
                _stations[target.Throwing.Motor.StationNo].BallCount--;
                FillBalls(target.Throwing.Motor.StationNo);

                if (target.Castle != null)
                {
                    BallStatus ballStatus = BallStatus.Thrown;
                    MakeColor(target.Castle, null, ballStatus);
                    DateTime thrownTime = DateTime.Now;
                }

            }
            return 1;
        }
    }
}
