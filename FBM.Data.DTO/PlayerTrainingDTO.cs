using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class PlayerTrainingDTO
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Guid TrainingId { get; set; }
        public string TrainingName { get; set; }
        public DateTime TrainingDate { get; set; }
        public decimal? TimeScore { get; set; }
        public decimal? SpeedScore { get; set; }
    }
}
