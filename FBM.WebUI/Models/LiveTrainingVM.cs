using FBM.Data.Entity.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBM.WebUI.Models
{
    public class LiveTrainingVM
    {
        public PlayerTraining PlayerTraining { get; set; }
        public int SuccessGoalCount
        {
            get
            {
                if (PlayerTraining.TrainLog != null)
                {
                    return PlayerTraining.TrainLog.Where(x => x.isSuccess).Count();
                }
                return 0;
            }
        }
        public int UnSuccessGoalCount
        {
            get
            {
                if (PlayerTraining.TrainLog != null)
                {
                    return PlayerTraining.TrainLog.Where(x => x.isSuccess == false).Count();
                }
                return 0;
            }
        }
        public int[] Chart2List
        {
            get
            {
                if (PlayerTraining.TrainLog != null)
                {
                    int[] res = new int[6];
                    res[0] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition < 4).Count();//sol Başarılı
                    res[1] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition < 4).Count();//sol başarısız
                    res[2] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition == 4).Count();//orta Başarılı
                    res[3] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition == 4).Count();//orta Başarısız
                    res[4] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition > 4).Count();//sağ başarılı
                    res[5] = this.PlayerTraining.TrainLog.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition > 4).Count();//sağ başarısız
                    return res;
                }
                return new int[6] { 0, 0, 0, 0, 0, 0 };
            }
        }
    }
}