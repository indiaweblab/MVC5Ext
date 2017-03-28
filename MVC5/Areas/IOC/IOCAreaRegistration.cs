using System.Web.Mvc;

namespace MVC5.Areas.IOC
{
    public class IOCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IOC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IOC_default",
                "IOC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}