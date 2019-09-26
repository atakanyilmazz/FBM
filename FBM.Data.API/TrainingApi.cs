using FBM.Data.Entity.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.API
{
    public class TrainingApi : BaseApi<Training>
    {
        public TrainingApi():base("Training")
        {
            
        }
        
    }
}
