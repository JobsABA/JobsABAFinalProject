using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new JobsInABA.DAL.Repositories.UsersRepo().GetUserByID(1);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (this.Context.Request.Path.Contains("signalr/negotiate"))
            {
                this.Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                this.Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                this.Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                this.Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            }
        }
    }
}
