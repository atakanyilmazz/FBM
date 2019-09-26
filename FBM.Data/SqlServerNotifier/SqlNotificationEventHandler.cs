using System.Data.SqlClient;

namespace FBM.Data.SqlServerNotifier
{
    public delegate void SqlNotificationEventHandler(object sender, SqlNotificationEventArgs e);
}