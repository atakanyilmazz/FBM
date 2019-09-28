namespace FBM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.DeviceInfo",
               c => new
               {
                   Id = c.Guid(nullable: false, identity: true),
                   LdrCount = c.Int(nullable: false),
                   DeviceCount = c.Int(nullable: false),
                   Station_Id = c.Guid(),
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.Station", t => t.Station_Id)
               .Index(t => t.Station_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Throwing", "ThrowBallAngleId", "dbo.ThrowBallAngle");
            DropForeignKey("dbo.ThrowBallAngle", "AngleTypeId", "dbo.AngleType");
            DropForeignKey("dbo.Throwing", "ThrowBallAltitudeId", "dbo.ThrowBallAltitude");
            DropForeignKey("dbo.Throwing", "MotorId", "dbo.Motor");
            DropForeignKey("dbo.Motor", "StationId", "dbo.Station");
            DropForeignKey("dbo.Ldr", "StationId", "dbo.Station");
            DropForeignKey("dbo.DeviceInfo", "Station_Id", "dbo.Station");
            DropForeignKey("dbo.Target", "TrainingId", "dbo.Training");
            DropForeignKey("dbo.TrainLog", "TargetId", "dbo.Target");
            DropForeignKey("dbo.TrainLog", "PlayerTrainingId", "dbo.PlayerTraining");
            DropForeignKey("dbo.PlayerTraining", "TrainingId", "dbo.Training");
            DropForeignKey("dbo.PlayerTraining", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Target", "ThrowingId", "dbo.Throwing");
            DropForeignKey("dbo.Target", "CastleId", "dbo.Castle");
            DropForeignKey("dbo.Castle", "StationId", "dbo.Station");
            DropForeignKey("dbo.CastleLdrPoint", "CastleId", "dbo.Castle");
            DropForeignKey("dbo.ThrowBallAltitude", "AltitudeTypeId", "dbo.AltitudeType");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ThrowBallAngle", new[] { "AngleTypeId" });
            DropIndex("dbo.Ldr", new[] { "StationId" });
            DropIndex("dbo.DeviceInfo", new[] { "Station_Id" });
            DropIndex("dbo.TrainLog", new[] { "TargetId" });
            DropIndex("dbo.TrainLog", new[] { "PlayerTrainingId" });
            DropIndex("dbo.PlayerTraining", new[] { "TrainingId" });
            DropIndex("dbo.PlayerTraining", new[] { "PlayerId" });
            DropIndex("dbo.Target", new[] { "CastleId" });
            DropIndex("dbo.Target", new[] { "ThrowingId" });
            DropIndex("dbo.Target", new[] { "TrainingId" });
            DropIndex("dbo.CastleLdrPoint", new[] { "CastleId" });
            DropIndex("dbo.Castle", new[] { "StationId" });
            DropIndex("dbo.Motor", new[] { "StationId" });
            DropIndex("dbo.Throwing", new[] { "ThrowBallAltitudeId" });
            DropIndex("dbo.Throwing", new[] { "ThrowBallAngleId" });
            DropIndex("dbo.Throwing", new[] { "MotorId" });
            DropIndex("dbo.ThrowBallAltitude", new[] { "AltitudeTypeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LiveTrainings");
            DropTable("dbo.AngleType");
            DropTable("dbo.ThrowBallAngle");
            DropTable("dbo.Ldr");
            DropTable("dbo.DeviceInfo");
            DropTable("dbo.TrainLog");
            DropTable("dbo.Player");
            DropTable("dbo.PlayerTraining");
            DropTable("dbo.Training");
            DropTable("dbo.Target");
            DropTable("dbo.CastleLdrPoint");
            DropTable("dbo.Castle");
            DropTable("dbo.Station");
            DropTable("dbo.Motor");
            DropTable("dbo.Throwing");
            DropTable("dbo.ThrowBallAltitude");
            DropTable("dbo.AltitudeType");
        }
    }
}
