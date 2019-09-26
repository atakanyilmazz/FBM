using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Entity.Players
{
    public class Player : NamedEntity
    {
        public ICollection<PlayerTraining> PlayerTraining { get; set; }
    }
}
