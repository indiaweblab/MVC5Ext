using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using BLL;
using MVC5.Controllers;

namespace MVC5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // 在应用程序启动时运行的代码  
            System.Timers.Timer myTimer = new System.Timers.Timer(60000);
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            myTimer.Interval = 60000;
            myTimer.Enabled = true;
        }
        private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            //同步域名
            //SyncWhois model = SyncWhois.GetHandler();
            //model.CheckWhois();
            AliYunController model = new AliYunController();
            model.Index();
        }
    }
}