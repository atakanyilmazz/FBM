namespace FBM.Data.Migrations
{
    using Entity.Players;
    using Entity.Throw;
    using Entity.Train;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FBM.Data.DbmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FBM.Data.DbmDbContext context)
        {
            context.AltitudeType.AddOrUpdate(
               x => x.Name,
               new AltitudeType { Name = "ToHeat", Desctription = "Kafa Hizasý" },
               new AltitudeType { Name = "ToChest", Desctription = "Göðüs Hizasý" },
               new AltitudeType { Name = "ToFoot", Desctription = "Ayak Hizasý" }
               );
            context.AngleType.AddOrUpdate(
                x => x.Name,
                new AngleType { Name = "ToLeft", Desctription = "Sola Falso" },
                new AngleType { Name = "ToRight", Desctription = "Saða Falso" },
                new AngleType { Name = "Straight", Desctription = "Düz Atýþ" }
                );
            //context.Player.AddOrUpdate(
            //    x => x.Name,
            //    new Player { Name = "FBM Player", Desctription = "DEMO" }
            //    );
            //context.Station.AddOrUpdate(
            //    x => x.Name,
            //    new Entity.Station.Station { Name = "FBM", Desctription = "DEMO" }
            //    );
            //context.Training.AddOrUpdate(
            //    x => x.Name,
            //    new Training { Name = "Starter Training", Desctription = "DEMO" }
            //    );

        }
    }
}
