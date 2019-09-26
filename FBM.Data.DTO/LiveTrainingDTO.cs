using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBM.Data.DTO
{
    public class LiveTrainingDTO
    {
        //public PlayerTraining PlayerTraining { get; set; }
        public Guid PlayerTrainingId { get; set; }
        public DateTime TrainingDate { get; set; }
        public string PlayerName { get; set; }
        public string TrainingName { get; set; }
        public List<TrainLogDTO> TrainLog { get; set; }
        public int SuccessGoalCount { get; set; }
        public int UnSuccessGoalCount { get; set; }
        public int[] Chart2List { get; set; }
        public int[] Chart3List { get; set; }
        public int TotalBallCount { get; set; }
    }
}
