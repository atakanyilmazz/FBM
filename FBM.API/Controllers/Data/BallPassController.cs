using FBM.Data;
using FBM.Data.DTO;
using FBM.Data.Entity.Station;
using FBM.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FBM.API.Controllers
{
    public class BallPassController : ApiController
    {
        DbmDbContext db = new DbmDbContext();
        [HttpPost]
        public Castle GetCastleByCastleLdrPoint(BallPassedDTO ballPassedDTO)
        {
            LdrController ldrRep = new LdrController();
            if (ballPassedDTO.BallPassedLdrItems.Count < 2)
            {
                throw new Exception("Hatalı nesne geçişi");
            }
            List<BallPassLdrPointItem> ballPassLdrPointItems = new List<BallPassLdrPointItem>() { new BallPassLdrPointItem(Axis.X), new BallPassLdrPointItem(Axis.Y) };
            foreach (BallPassedLdrItem ballPassedLdrItem in ballPassedDTO.BallPassedLdrItems.OrderBy(x => x.Ldr.LdrUnitNo).ToList())
            {
                int beforePoint = GetLdrBeforePoint(ballPassedLdrItem.Ldr);
                int startLdrPoint = beforePoint + ballPassedLdrItem.FirstLdrPoint;
                int LastLdrPoint = beforePoint + ballPassedLdrItem.LastLdrPoint;
                if (ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.FirstPoint < startLdrPoint).Any())
                {
                    ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.FirstPoint < startLdrPoint).FirstOrDefault().FirstPoint = startLdrPoint;
                }
                if (ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.LastPoint < LastLdrPoint).Any())
                {
                    ballPassLdrPointItems.Where(x => x.Axis == ballPassedLdrItem.Ldr.Axis && x.LastPoint < LastLdrPoint).FirstOrDefault().LastPoint = LastLdrPoint;
                }
            }
            if (ballPassLdrPointItems.Any(x => x.FirstPoint == 0 || x.LastPoint == 0))
            {
                throw new Exception("Hatalı nesne geçişi 2");
            }
            BallPassLdrPointItem xItem = ballPassLdrPointItems.Where(x => x.Axis == Axis.X).First();
            BallPassLdrPointItem yItem = ballPassLdrPointItems.Where(x => x.Axis == Axis.Y).First();
            List<Castle> castleList = new List<Castle>();
            castleList.AddRange(db.CastleLdrPoint.Where(x => x.Axis == xItem.Axis &&
            x.StartPoint <= xItem.FirstPoint && x.EndPoint >= xItem.FirstPoint &&
            x.StartPoint <= xItem.LastPoint && x.EndPoint >= xItem.LastPoint).Select(x => x.Castle).ToList());
            castleList.AddRange(db.CastleLdrPoint.Where(x => x.Axis == yItem.Axis &&
            x.StartPoint <= yItem.FirstPoint && x.EndPoint >= yItem.FirstPoint &&
            x.StartPoint <= yItem.LastPoint && x.EndPoint >= yItem.LastPoint).Select(x => x.Castle).ToList());
            Guid id = castleList.GroupBy(x => x.Id).Select(g => new { g.Key, Count = g.Count() }).ToList().Where(x => x.Count == 2).Select(x => x.Key).FirstOrDefault();
            if (id != null || id != Guid.Empty)
            {
                Castle castle = castleList.Where(x => x.Id == id).FirstOrDefault();
                return castle;
            }
            throw new Exception("Hatalı castle ve castle point eşleşmesi");
        }
        
        public int GetLdrBeforePoint(Ldr ldr)
        {
            int beforeLdrCount = db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition).Any() ? db.Ldr
                .Where(x => x.AxisOrder < ldr.AxisOrder && x.Axis == ldr.Axis && x.StationId == ldr.StationId
                && x.WallPosition == ldr.WallPosition)
                .Sum(x => x.LaserCount) : 0;
            return beforeLdrCount;
        }
    }
}
