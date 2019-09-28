using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public static class ClientServiceProxy
    {
        public static AltitudeTypeApi AltitudeTypeService()
        {
            return new AltitudeTypeApi();
        }
        public static AngleTypeApi AngleTypeService()
        {
            return new AngleTypeApi();
        }
        public static CastleApi CastleService()
        {
            return new CastleApi();
        }
        public static CastleLdrPointApi CastleLdrPointService()
        {
            return new CastleLdrPointApi();
        }
        public static LdrApi LdrService()
        {
            return new LdrApi();
        }
        public static MotorApi MotorService()
        {
            return new MotorApi();
        }
        public static PlayerApi PlayerService()
        {
            return new PlayerApi();
        }
        public static PlayerTrainingApi PlayerTrainingService()
        {
            return new PlayerTrainingApi();
        }
        public static StationApi StationService()
        {
            return new StationApi();
        }
        public static TargetApi TargetService()
        {
            return new TargetApi();
        }
        public static ThrowBallAltitudeApi ThrowBallAltitudeService()
        {
            return new ThrowBallAltitudeApi();
        }
        public static ThrowBallAngleApi ThrowBallAngleService()
        {
            return new ThrowBallAngleApi();
        }
        public static ThrowingApi ThrowingService()
        {
            return new ThrowingApi();
        }
        public static TrainingApi TrainingService()
        {
            return new TrainingApi();
        }
        public static TrainLogApi TrainLogService()
        {
            return new TrainLogApi();
        }
        public static LiveTrainingApi LiveTrainingService()
        {
            return new LiveTrainingApi();
        }
        public static AccountApi AccountService()
        {
            return new AccountApi();
        }
        public static DllApi DllService()
        {
            return new DllApi();
        }
        public static DeviceInfoApi DeviceInfoService()
        {
            return new DeviceInfoApi();
        }
    }
}
