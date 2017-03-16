using System.Web.Mvc;

namespace MVC5.Areas.toobar
{
    public class toobarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "toobar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "toobar_default",
                "toobar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}