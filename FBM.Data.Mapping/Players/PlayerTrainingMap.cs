using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Players
{
    public class PlayerTrainingMap :BaseEntityMap<PlayerTraining>
    {
        public PlayerTrainingMap()
        {
            ToTable("PlayerTraining");
            Property(x => x.TrainingDate).IsRequired();

            HasRequired(x => x.Player).WithMany(x => x.PlayerTraining).HasForeignKey(x => x.PlayerId).WillCascadeOnDelete(false);
            HasRequired(x => x.Training).WithMany(x => x.PlayerTraining).HasForeignKey(x => x.TrainingId).WillCascadeOnDelete(false);
        }
    }
}
