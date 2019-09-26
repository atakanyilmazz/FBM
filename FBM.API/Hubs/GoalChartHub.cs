using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using FBM.Data.SqlServerNotifier;
using FBM.Data;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Train;

namespace FBM.Hubs
{
    public class GoalChartHub : Hub
    {
        DbmDbContext db = new DbmDbContext();
        internal NotifierEntity NotifierEntity { get; private set; }

        public void DispatchToClient()
        {
            Clients.All.broadcastMessage("Refresh");
        }

        public void Initialize()
        {
            var collection = db.TrainLog;
            NotifierEntity = db.GetNotifierEntity<TrainLog>(collection);
            if (NotifierEntity == null)
                return;
            Action<String> dispatcher = (t) => { DispatchToClient(); };
            PushSqlDependency.Instance(NotifierEntity, dispatcher);
        }
    }
}