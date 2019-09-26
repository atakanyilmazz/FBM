using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Train
{
    public class TargetMap : BaseEntityMap<Target>
    {
        public TargetMap()
        {
            ToTable("Target");
            Property(x => x.TrainingId).IsRequired();
            Property(x => x.ThrowingId).IsRequired();
            Property(x => x.CastleId).IsRequired();
            Property(x => x.ThrowingCount).IsRequired();

            HasRequired(x => x.Throwing).WithMany(x=>x.Target).HasForeignKey(x=>x.ThrowingId);
            HasRequired(x => x.Castle).WithMany(x => x.Target).HasForeignKey(x => x.CastleId).WillCascadeOnDelete(false);
            HasRequired(x => x.Training).WithMany(x => x.Target).HasForeignKey(x => x.TrainingId);
        }
    }
}
