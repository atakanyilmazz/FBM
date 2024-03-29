﻿using FBM.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FBM.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected String SqlConnectionString { get; set; }
        protected void Application_Start()
        {
            using (var context = new DbmDbContext())
                SqlConnectionString = context.Database.Connection.ConnectionString;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);
        }
        protected void Application_End()
        {
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Stop(SqlConnectionString);
        }
    }
}
