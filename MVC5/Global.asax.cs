using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using BLL;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using BLL.High;
using IBLL.High;

namespace MVC5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //  SetupResolveRules

            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // 在应用程序启动时运行的代码  
            System.Timers.Timer myTimer = new System.Timers.Timer(10000);
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            myTimer.Interval = 10000;
            myTimer.Enabled = true;

            
        }
        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
        }
        private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            var a = 1;
            SyncWhois model = SyncWhois.GetHandler();
            model.CheckWhois();
        }
    }
}