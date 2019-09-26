using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Train
{
    public class TrainingMap : NamedEntityMap<Training>
    {
        public TrainingMap()
        {
            ToTable("Training");
            Property(x => x.ThrowWaitingTime).IsRequired();
        }
    }
}
