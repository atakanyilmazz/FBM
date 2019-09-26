using FBM.Data.Entity.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FBM.Data.Entity.Players;
using FBM.Data;
using FBM.Data.DTO;

namespace FBM.API.Controllers
{
    //[Authorize]
    public class PlayerTrainingController : BaseController<DbmDbContext, PlayerTraining>
    {
        public List<PlayerTraining> GetByPlayerId(Guid id)
        {
            return base.Context.PlayerTraining.Where(x => x.PlayerId == id).ToList();
        }

        public List<PlayerTraining> GetByTrainingId(Guid id)
        {
            return base.Context.PlayerTraining.Where(x => x.TrainingId == id).ToList();
        }

        public List<PlayerTrainingDTO> GetPlayerTrainingDTOByPlayerId(Guid id)
        {
            List<PlayerTrainingDTO> vm = new List<PlayerTrainingDTO>();
            vm = base.Context.PlayerTraining.Where(x => x.PlayerId == id).Select(x => new PlayerTrainingDTO()
            {
                Id = x.Id,
                PlayerId = x.PlayerId,
                PlayerName = x.Player.Name,
                TrainingId = x.TrainingId,
                TrainingName = x.Training.Name,
                TrainingDate = x.TrainingDate,
                SpeedScore = x.SpeedScore,
                TimeScore = x.TimeScore
            }).ToList();
            return (vm);
        }

        public List<PlayerTrainingDTO> GetPlayerTrainingDTOTrainingId(Guid id)
        {
            List<PlayerTrainingDTO> vm = new List<PlayerTrainingDTO>();
            vm = base.Context.PlayerTraining.Where(x => x.TrainingId == id).Select(x => new PlayerTrainingDTO()
            {
                Id = x.Id,
                PlayerName = x.Player.Name,
                TrainingName = x.Training.Name,
                TrainingDate = x.TrainingDate,
                SpeedScore = x.SpeedScore,
                TimeScore = x.TimeScore
            }).ToList();
            return (vm);
        }
    }
}
