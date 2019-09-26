using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class PlayerApi : BaseApi<Player>
    {
        public PlayerApi():base("Player")
        {

        }
    }
}
