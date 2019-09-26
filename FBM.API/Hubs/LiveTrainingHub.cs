using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using FBM.Data.SqlServerNotifier;
using FBM.Data;
using FBM.Data.Entity.Station;
using FBM.Data.Entity.Train;
using FBM.Data.Entity;

namespace FBM.Hubs
{
    public class LiveTrainingHub : Hub
    {
        DbmDbContext db = new DbmDbContext();
        internal NotifierEntity NotifierEntity { get; private set; }

        public void DispatchToClient()
        {
            Clients.All.broadcastMessage("HasChange");
        }

        public void Initialize()
        {
            var collection = db.LiveTraining;
            NotifierEntity = db.GetNotifierEntity<LiveTraining>(collection);
            if (NotifierEntity == null)
                return;
            Action<String> dispatcher = (t) => { DispatchToClient(); };
            PushSqlDependency.Instance(NotifierEntity, dispatcher);
        }
    }
}