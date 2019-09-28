using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data.Entity.Train;
using FBM.Data;
using FBM.Data.Entity;
using System.Threading.Tasks;
using FBM.Data.DTO;
using FBM.Data.Entity.Players;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class LiveTrainingController : BaseController<DbmDbContext, LiveTraining>
    {
        public async virtual Task<LiveTrainingDTO> GetLiveTrainingDTO(Guid id)
        {
            LiveTrainingDTO dto = new LiveTrainingDTO();
            PlayerTraining pt = await base.Context.PlayerTraining.Where(x=>x.Id==id).FirstOrDefaultAsync();
            dto.PlayerTrainingId = pt.Id;
            dto.PlayerName = pt.Player.Name;
            dto.TrainingName = pt.Training.Name;
            dto.TrainingDate = pt.TrainingDate;

            List<TrainLog> temp = await base.Context.TrainLog.Where(x => x.PlayerTrainingId == id).ToListAsync();

            dto.TrainLog = temp.Where(x => x.PlayerTrainingId == id).Select(x => new TrainLogDTO()
            {
                isSuccess = x.isSuccess,
                Speed= x.Speed,
                Time=x.Time,
                SpeedScore = x.SpeedScore,
                TimeScore = x.TimeScore,
                OrderNo = x.OrderNo
            }).ToList();

            dto.SuccessGoalCount = temp.Where(x => x.isSuccess).Count();
            dto.UnSuccessGoalCount = temp.Where(x => x.isSuccess == false).Count();

            int[] chart2 = new int[6];
            chart2[0] = temp.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition < 4).Count();//sol Başarılı
            chart2[1] = temp.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition < 4).Count();//sol başarısız
            chart2[2] = temp.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition == 4).Count();//orta Başarılı
            chart2[3] = temp.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition == 4).Count();//orta Başarısız
            chart2[4] = temp.Where(x => x.isSuccess == true && (int)x.Target.Castle.CastlePosition > 4).Count();//sağ başarılı
            chart2[5] = temp.Where(x => x.isSuccess == false && (int)x.Target.Castle.CastlePosition > 4).Count();//sağ başarısız
            dto.Chart2List = chart2;

            int[] chart3 = new int[4];
            chart3[0] = temp.Where(x => x.isSuccess == true && x.Target.Castle.CastleFloor== FBM.Data.Enum.Floor.Top).Count();//Üst Başarılı
            chart3[1] = temp.Where(x => x.isSuccess == false && x.Target.Castle.CastleFloor == FBM.Data.Enum.Floor.Top).Count();//üst başarısız
            chart3[2] = temp.Where(x => x.isSuccess == true && x.Target.Castle.CastleFloor == FBM.Data.Enum.Floor.Bottom).Count();//alt Başarılı
            chart3[3] = temp.Where(x => x.isSuccess == false && x.Target.Castle.CastleFloor == FBM.Data.Enum.Floor.Bottom).Count();//alt Başarısız
            dto.Chart3List = chart3;
            List<Target> targetList = await base.Context.Target.Where(x => x.TrainingId == pt.TrainingId).ToListAsync();
            dto.TotalBallCount = Convert.ToInt32(targetList.Sum(x=>x.ThrowingCount));
            return dto;
        }

    }
}
