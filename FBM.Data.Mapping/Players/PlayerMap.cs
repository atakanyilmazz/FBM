using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.Mapping.Players
{
    public class PlayerMap : NamedEntityMap<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");
        }
    }
}
