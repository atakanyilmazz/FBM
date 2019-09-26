using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Train
{
    public class TrainLogMap : BaseEntityMap<TrainLog>
    {
        public TrainLogMap()
        {
            ToTable("TrainLog");
            Property(x => x.isSuccess).IsRequired();
            Property(x => x.Time).IsOptional();
            Property(x => x.SpeedScore).IsRequired();
            Property(x => x.TimeScore).IsRequired();
            Property(x => x.OrderNo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.PlayerTraining).WithMany(x => x.TrainLog).HasForeignKey(x => x.PlayerTrainingId).WillCascadeOnDelete(false);
            HasRequired(x => x.Target).WithMany(x => x.TrainLog).HasForeignKey(x => x.TargetId);
        }
    }
}
