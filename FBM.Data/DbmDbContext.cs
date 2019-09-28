using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBM.Data.Entity.Station;
using FBM.Data.Mapping.Station;
using FBM.Data.Entity.Train;
using FBM.Data.Mapping.Train;
using FBM.Data.Entity.Throw;
using System.Data.Entity.ModelConfiguration.Conventions;
using FBM.Data.Mapping.Throw;
using FBM.Data.Entity.Players;
using FBM.Data.Mapping.Players;
using Microsoft.AspNet.Identity.EntityFramework;
using FBM.Data.Entity;
using FBM.Data.Mapping;

namespace FBM.Data
{
    public class DbmDbContext : IdentityDbContext<User>
    {
        public DbmDbContext() : base("DbmDbContext", throwIfV1Schema: false)
        {

        }
        public IDbSet<Entity.Station.Station> Station { get; set; }
        public IDbSet<Castle> Castle { get; set; }
        public IDbSet<Ldr> Ldr { get; set; }
        public IDbSet<CastleLdrPoint> CastleLdrPoint { get; set; }
        public IDbSet<Training> Training { get; set; }
        public IDbSet<Motor> Motor { get; set; }
        public IDbSet<AltitudeType> AltitudeType { get; set; }
        public IDbSet<AngleType> AngleType { get; set; }
        public IDbSet<ThrowBallAltitude> ThrowBallAltitude { get; set; }
        public IDbSet<ThrowBallAngle> ThrowBallAngle { get; set; }
        public IDbSet<Throwing> Throwing { get; set; }
        public IDbSet<Target> Target { get; set; }
        public IDbSet<Player> Player { get; set; }
        public IDbSet<PlayerTraining> PlayerTraining { get; set; }
        public IDbSet<TrainLog> TrainLog { get; set; }
        public IDbSet<LiveTraining> LiveTraining { get; set; }
        public IDbSet<DeviceInfo> DeviceInfo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StationMap());
            modelBuilder.Configurations.Add(new CastleMap());
            modelBuilder.Configurations.Add(new LdrMap());
            modelBuilder.Configurations.Add(new CastleLdrPointMap());
            modelBuilder.Configurations.Add(new TrainingMap());
            modelBuilder.Configurations.Add(new MotorMap());
            modelBuilder.Configurations.Add(new AltitudeTypeMap());
            modelBuilder.Configurations.Add(new AngleTypeMap());
            modelBuilder.Configurations.Add(new ThrowBallAltitudeMap());
            modelBuilder.Configurations.Add(new ThrowBallAngleMap());
            modelBuilder.Configurations.Add(new ThrowingMap());
            modelBuilder.Configurations.Add(new TargetMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new PlayerTrainingMap());
            modelBuilder.Configurations.Add(new TrainLogMap());
            modelBuilder.Configurations.Add(new LiveTrainingMap());
            modelBuilder.Configurations.Add(new DeviceInfoMap());
            base.OnModelCreating(modelBuilder);
        }
        public static DbmDbContext Create()
        {
            return new DbmDbContext();
        }
    }
}
